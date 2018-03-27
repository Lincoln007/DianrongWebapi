using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dianrong.Data.Models;
using Dianrong.Data.Models.ReqModel;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Site.Common.Models;
using NLog;

namespace Site.Common.Helpers
{
    public static class DianrongHelper
    {
        private static string publicKeyFile = Path.Combine(AppContext.BaseDirectory, "rsa", "rsa_public_key.pem");
        private static string privateKeyFile = Path.Combine(AppContext.BaseDirectory, "rsa", "rsa_private_key.pem");

        private static ILogger reqLogger = LogManager.GetLogger("req");
        /*
nonce   随机生成8位长度的字节数组byte1，使用Base64编码byte1得到字符串随机数randomStr，通过RSA公钥加密该随机数randomStr得到字节数组byte2，最后用Base64编码byte2得到nonce，java示例
reqData 由reqData明细数据组装jsonString，简称reqDataJsonString 贷款申请接口示例，再通过DES算法加密reqDataJsonString得到，加密的key为之前的随机数randomStr,java示例
signature   通过RSA私钥签名算法，对reqDataJsonString进行私钥签名后得到,java示例
        */


        public static string GetNonce(string randomStr, bool javaSafe = true)
        {

            var maxBlock = 245;
            int offset =0;
            int i =0;
            var outBytes = new List<byte>();

            var pubKey = new PemReader(new StreamReader(publicKeyFile)).ReadObject() as AsymmetricKeyParameter;
            IBufferedCipher c = CipherUtilities.GetCipher("RSA/NONE/PKCS1PADDING");// 参数与JAVA中解密的参数一致
            c.Init(true,pubKey);
            var data = Encoding.UTF8.GetBytes(randomStr);
            var inputLength = data.Length;
            while (inputLength-offset>0)
            {
                if (inputLength-offset>maxBlock)
                {
                    outBytes.AddRange(c.DoFinal(data,offset,maxBlock));
                }else
                {
                    outBytes.AddRange(c.DoFinal(data,offset,inputLength-offset));
                }
                i++;
                offset=i*maxBlock;
            }
            return Convert.ToBase64String(outBytes.ToArray());
        }
        public static string GetRandomStr()
        {
            var random = new Random();
            var bs = new byte[8];
            random.NextBytes(bs);
            var randomStr = Convert.ToBase64String(bs);
            return randomStr;
        }
        /// <summary>
        /// 由reqData明细数据组装jsonString，简称reqDataJsonString 贷款申请接口示例，再通过DES算法加密reqDataJsonString得到，加密的key为之前的随机数randomStr
        /// </summary>
        /// <returns>The req data.</returns>
        /// <param name="reqObject">Req object.</param>
        /// <param name="randomStr">Random string.</param>
        public static string GetReqData(object reqObject, string randomStr)
        {
            reqObject.NotNull("reqObject参数");
            randomStr.NotNull("randomStr参数");
            var jsonStr = JsonConvert.SerializeObject(reqObject, Formatting.None);

            var bs = Encoding.UTF8.GetBytes(jsonStr);
            var decoded = Convert.FromBase64String(randomStr);
            // decoded = Encoding.UTF8.GetBytes(randomStr);
            var keyParam = ParameterUtilities.CreateKeyParameter("DES", decoded);
            var cipher = (BufferedBlockCipher)CipherUtilities.GetCipher("DES/NONE/PKCS5Padding");

            cipher.Init(true, keyParam);
            var rst = cipher.DoFinal(bs);
            // var asciiBs = Encoding.ASCII.GetBytes(Encoding.UTF8.GetString(rst));
            return Convert.ToBase64String(rst);
        }
        /// <summary>
        /// 通过RSA私钥签名算法，对reqDataJsonString进行私钥签名后得到
        /// </summary>
        /// <returns>The signature.</returns>
        public static string GetSignature(string text)
        {
            text.NotNull("待签名内容");
            var bsToEncrypt = Encoding.UTF8.GetBytes(text);
            PemReader pemReader = new PemReader(new StreamReader(privateKeyFile));
            var pem = (AsymmetricCipherKeyPair)pemReader.ReadObject();
            ISigner sig = SignerUtilities.GetSigner("MD5withRSA");
            sig.Init(true, pem.Private);
            sig.BlockUpdate(bsToEncrypt, 0, bsToEncrypt.Length);
            byte[] signature = sig.GenerateSignature();

            /* Base 64 encode the sig so its 8-bit clean */
            var signedString = Convert.ToBase64String(signature);

            return signedString;
        }


        /// <summary>
        /// 私钥解密返回的内容
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RSADecryptByPrivateKey(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            var bs = Convert.FromBase64String(text);
            var rst = new List<byte>();
            #region 分段解密 解决加密密文过长问题
            int len = 256;
            int m = bs.Length / len;
            if (m * len != bs.Length)
            {
                m = m + 1;
            }

            for (int i = 0; i < m; i++)
            {
                byte[] temp = new byte[256];

                if (i < m - 1)
                {
                    temp = bs.Skip(i * len).Take(len).ToArray();
                }
                else
                {
                    temp = new byte[bs.Length % len == 0 ? 1 * len : bs.Length % len];
                    bs.Skip(i * len).Take(bs.Length % len == 0 ? len : bs.Length % len).ToArray().CopyTo(temp, 0);
                }
                rst.AddRange(Decrypt(temp, privateKeyFile));
            }
            #endregion

            return Encoding.UTF8.GetString(rst.ToArray());

        }
        /// <summary>
        /// RSA解密操作 Decrypt方法
        /// </summary>
        /// <param name="input"></param>
        /// <param name="privateKeyPath"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private static byte[] Decrypt(byte[] input, string privateKeyPath)
        {
            PemReader r = new PemReader(new StreamReader(privateKeyPath));     //载入私钥
            var readObject = r.ReadObject();

            AsymmetricCipherKeyPair priKey = (AsymmetricCipherKeyPair)readObject;
            string mode = "RSA/NONE/PKCS1Padding";
            IBufferedCipher c = CipherUtilities.GetCipher(mode);
            c.Init(false, priKey.Private);

            byte[] outBytes = c.DoFinal(input);
            return outBytes;
        }
        /// <summary>
        /// 对应的org.apache.commons.codec.binary.Base64.encodeBase64URLSafeString
        /// </summary>
        /// <returns>The save URL.</returns>
        /// <param name="s">S.</param>
        private static string JavaEncodeBase64URLSafeString(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            return s.TrimEnd(new[] { '=' }).Replace('+', '-').Replace('/', '_');
        }


        /// <summary>
        /// 点融接口的请求对象,4个字段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static DianrongReqModel BuildReqModel(DianrongBaseReqModel model,string channelId)
        {
            var randomStr = GetRandomStr();
            var nonce = GetNonce(randomStr);
            var reqJsonStr = JsonConvert.SerializeObject(model, formatting: Formatting.None);
            // reqLogger.Trace($"请求参数：{reqJsonStr}");
            var reqModel = new DianrongReqModel(channelId)
            {
                Nonce = nonce,
                ReqData = GetReqData(model, randomStr),
                Signature = GetSignature(reqJsonStr)
            };
            return reqModel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reqModel"></param>
        /// <returns></returns>
        public async static Task<T> GetDianrongRsp<T>(string url, DianrongReqModel reqModel) where T : class
        {
            var rst = await HttpHelper.GetResultAsync<T>(new HttpReqModel() { Method = "post", ReqBody = reqModel, Url = url });
            
            // reqLogger.Info($"返回{JsonConvert.SerializeObject(rst)}")
            var contentProp = typeof(T).GetProperty("Content");
            var decryptedContent = DianrongHelper.RSADecryptByPrivateKey(Convert.ToString(contentProp?.GetValue(rst)));
            reqLogger.Info($"返回结果解码码后的结果:{decryptedContent}");
            var bodyProp = typeof(T).GetProperty("Body");
            bodyProp?.SetValue(rst, decryptedContent);
            var contentObjProp = typeof(T).GetProperty("ContentObj");

            //{\"code\":\"30000\",\"message\":\"RuntimeException:For input string: \\\"string\\\"\"}

            contentObjProp?.SetValue(rst, JsonConvert.DeserializeObject(decryptedContent, contentObjProp?.PropertyType));
            return rst;
        }

        public async static Task<T> GetDianrongRsp<T>(string url, DianrongBaseReqModel model,string channelId) where T : class
        {
            var reqModel = BuildReqModel(model,channelId);
            return await GetDianrongRsp<T>(url, reqModel);
        }

    }
}

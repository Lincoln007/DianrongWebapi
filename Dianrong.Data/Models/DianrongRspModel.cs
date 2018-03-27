using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dianrong.Data.Models
{
    /// <summary>
    /// 点融接口请求返回的对象（未解密)
    /// </summary>
    public class DianrongRspModel
    {
        /*
            20000    "success"
            30000   "internal error"
            40001   "Invalid Parameter"
            40002   "Invalid Operation"
            40003   "Auth failed"
            40004   "Data not found"
        */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, string> codeDic = new Dictionary<int, string>() {
            { 20000, "success" },
            { 30000, "internal error" },
            { 40001, "Invalid Parameter" },
            { 40002, "Invalid Operation" },
            { 40003, "Auth failed" },
            { 40004, "Data not found" },
        };
        
        /*
         {
  "result": "success", // or "fail"
  "errorMsg": "", //empty if result is success
  "errorCode": "", //empty if result is success
  "content": "encrypted json string"// RSA encrypted by public key, need decrypted by private key
} 
         */
        /// <summary>
        /// success 或 error
        /// </summary>
        /// <value>The result.</value>
        [JsonProperty("result")]
        public string Result
        {
            get;
            set;
        }
        /// <summary>
        /// 公钥加密的内容，用私钥解密
        /// </summary>
        /// <value>The content.</value>
        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }
    }
}
using System;
using Newtonsoft.Json;
namespace Dianrong.Data.Models
{
    /*
{
  "channelId": "000001",
  "signature": "signature of business datas’ json string",
  "nonce": "encrypted text of DES key",
  "reqData": "encrypted text of business datas’ json string"
}
    */
    /// <summary>
    /// 点融的最终的请求model(已加密)
    /// </summary>
    public class DianrongReqModel
    {
        public DianrongReqModel(string channelId)
        {
            this.ChannelId= channelId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("channelId")]
        public string ChannelId
        {
            get;set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("signature")]
        public string Signature
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("nonce")]
        public string Nonce
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("reqData")]
        public string ReqData
        {
            get;
            set;
        }

    }
}

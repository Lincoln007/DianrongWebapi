using Newtonsoft.Json;

namespace Dianrong.Data.Models.RspModel
{
    /// <summary>
    /// 
    /// </summary>
    public class RepaymentRsp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("channelId")]
        public string ChannelId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("nonce")]
        public string Nonce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("encrypt")]
        public string Encrypt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("url")]
        public string Url => $"{BaseUrl}?channelId={ChannelId}&nonce={Nonce}&encrypt={Encrypt}";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

    }
}
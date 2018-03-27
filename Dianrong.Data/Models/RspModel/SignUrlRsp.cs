using Newtonsoft.Json;

namespace Dianrong.Data.Models.RspModel
{
    /// <summary>
    /// 
    /// </summary>
    public class SignUrlRsp:DianrongBaseRspModel<SignUrlRspContent>
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    public class SignUrlRspContent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("code")]
        public int Code { get; set; }
        /// <summary>
        /// 在线签约URL
        /// </summary>
        /// <returns></returns>
        [JsonProperty("signUrl")]
        public string SignUrl { get; set; }
        /// <summary>
        /// 请求处理信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("messgae")]
        public string Message { get; set; }

    }
}
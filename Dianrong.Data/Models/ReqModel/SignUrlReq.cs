using Newtonsoft.Json;

namespace Dianrong.Data.Models.ReqModel
{
    /// <summary>
    /// 
    /// </summary>
    public class SignUrlReq:DianrongBaseReqModel
    {
        /// <summary>
        /// 贷款申请Id
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loanAppId")]
        public string LoanAppId { get; set; }
    }
}
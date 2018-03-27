using Newtonsoft.Json;

namespace Dianrong.Data.Models.ReqModel
{
    /// <summary>
    /// 还款
    /// </summary>
    public class RepaymentReq
    {
        /// <summary>
        /// 手机号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("encryptPhone")]
        public string Phone { get; set; }

    }
}
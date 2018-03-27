using Newtonsoft.Json;

namespace Dianrong.Data.Models.ReqModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckBlackListReq : DianrongBaseReqModel
    {
        /// <summary>
        /// 真实姓名
        /// </summary>
        /// <returns></returns>
        [JsonProperty("person_realName")]
        public string PersonRealName { get; set; }
        /// <summary>
        /// 身份证号码 正则格式要求：(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)
        /// </summary>
        /// <returns></returns>
        [JsonProperty("person_cardNum")]
        public string PersonCardNum { get; set; }
        /// <summary>
        /// 手机号码正则格式要求：^1[34578][0-9]{9}$
        /// </summary>
        /// <returns></returns>
        [JsonProperty("person_mobilePhone")]
        public string PersonMobilePhone { get; set; }

    }
}
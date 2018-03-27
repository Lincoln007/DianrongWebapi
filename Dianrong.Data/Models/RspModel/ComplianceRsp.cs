using Newtonsoft.Json;

namespace Dianrong.Data.Models.RspModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ComplianceRsp:DianrongBaseRspModel<ComplianceRspContent>
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    public class ComplianceRspContent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("code")]
        public int Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CodeDesc
        {
            get
            {
                if (DianrongRspModel.codeDic.ContainsKey(Code))
                {
                    return DianrongRspModel.codeDic[Code];
                }
                return "未知验证错误";
            }
        }
    }

}
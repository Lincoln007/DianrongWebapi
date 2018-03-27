using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dianrong.Data.Models.RspModel
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryRepaymentPlanRsp : DianrongBaseRspModel<QueryRepaymentPlanRspContent>
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class QueryRepaymentPlanRspContent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("code")]
        public string Code { get; set; }
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
        [JsonProperty("plans")]
        public List<QueryRepaymentPlanRspContentContentPlan> Plans { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class QueryRepaymentPlanRspContentContentPlan
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("index")]
        public int Index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("dueDate")]
        public long DueDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("duePrincipal")]
        public double DuePrincipal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("dueInterest")]
        public double DueInterest { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("dueManagementFee")]
        public double DueManagementFee { get; set; }
    }
}
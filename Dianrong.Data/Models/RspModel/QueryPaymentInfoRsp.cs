using System.Collections.Generic;
using Dianrong.Data.Enums;
using Newtonsoft.Json;

namespace Dianrong.Data.Models.RspModel
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryPaymentInfoRsp:DianrongBaseRspModel<QueryPaymentInfoRspContent>
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    public class QueryPaymentInfoRspContent
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
        /// 返回的还款信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("repaymentInfos")]
        public List<RepaymentInfo> RepaymentInfos { get; set; }
        
    }
    /// <summary>
    /// 
    /// </summary>
    public class RepaymentInfo
    {
        /// <summary>
        /// 借款日
        /// </summary>
        /// <returns></returns>
        [JsonProperty("borrowDate")]
        public long BorrowDate { get; set; }
        /// <summary>
        /// 应还日期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("dueDate")]
        public long DueDate { get; set; }
        /// <summary>
        /// 实际还款日期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("payDate")]
        public long? PayDate { get; set; }
        /// <summary>
        /// 应还本金
        /// </summary>
        /// <returns></returns>
        [JsonProperty("duePrincipal")]
        public long DuePrincipal { get; set; }
        /// <summary>
        /// 已还本金
        /// </summary>
        /// <returns></returns>
        [JsonProperty("receivedPrincipal")]
        public long ReceivedPrincipal { get; set; }
        /// <summary>
        /// 应还利息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("dueInterest")]
        public long DueInterest { get; set; }
        /// <summary>
        /// 已还利息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("receivedInterest")]
        public long ReceivedInterest { get; set; }
        /// <summary>
        /// 应还罚息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("duePenaltyInterest")]
        public long DuePenaltyInterest { get; set; }
        /// <summary>
        /// 已还罚息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("receivedPenaltyInterest")]
        public long ReceivedPenaltyInterest { get; set; }
        /// <summary>
        /// 应还管理费
        /// </summary>
        /// <returns></returns>
        [JsonProperty("dueManagementFee")]
        public long? DueManagementFee { get; set; }
        /// <summary>
        /// 已还管理费
        /// </summary>
        /// <returns></returns>
        [JsonProperty("receivedManagementFee")]
        public long ReceivedManagementFee { get; set; }
        /// <summary>
        /// 还款状态
        /// </summary>
        /// <returns></returns>
        [JsonProperty("payStatus")]
        public PayStatus PayStatus { get; set; }
    }
}
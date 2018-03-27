using System.Collections.Generic;
using Dianrong.Data.Enums;
using Newtonsoft.Json;

namespace Dianrong.Data.Models.RspModel
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryLoanInfoRsp : DianrongBaseRspModel<QueryLoanInfoRspContent>
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class QueryLoanInfoRspContent
    {
        private static Dictionary<string, string> paymentMethodDic = new Dictionary<string, string>(){
            {"AMORTIZATION","等额本息"},
            {"EQUAL_PRINCIPAL_INTEREST","等本等息"},
            {"SESSION_PERIOD","每月还息，按季度还本"},
            {"HALF_YEAR_PERIOD","每月还息，按半年还本"},
            {"PAY_AT_THE_END","每月还息，到期一次性还本"},
            {"BULLET","到期一次性还本付息"},
            {"PAY_AT_THE_END","每月还息，到期一次性还本"},
            {"BULLET_FIXED_INTEREST","到期一次性还本付息,固定利息"},
            {"AMORTIZATION_CONFIGURATION","等额本息,支持进位"}
        };
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
        /// <summary>
        /// 请求处理信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// 申请金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("appAmount")]
        public double AppAmount { get; set; }
        /// <summary>
        /// 还款方式
        /// </summary>
        /// <returns></returns>
        [JsonProperty("paymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PaymentMethodDesc
        {
            get
            {
                return PaymentMethod.GetDesc();
                // return paymentMethodDic.GetValueOrDefault(method);
            }
        }
        /// <summary>
        /// 还款周期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("maturity")]
        public int Maturity { get; set; }
        /// <summary>
        /// 还款周期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("maturityType")]
        public MaturityType MaturityType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MaturityTypeDesc => MaturityType.GetDesc();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("status")]
        public LoanStatus Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string StatusDesc => Status.GetDesc();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("interestDate")]
        public string InterestDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("rejectReason")]
        public string RejectReason { get; set; }

    }
}
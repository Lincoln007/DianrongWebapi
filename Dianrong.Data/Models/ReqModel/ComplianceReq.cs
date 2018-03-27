using Newtonsoft.Json;

namespace Dianrong.Data.Models.ReqModel
{
    /// <summary>
    /// 合规补充信息
    /// </summary>
    public class ComplianceReq : DianrongBaseReqModel
    {
        /// <summary>
        /// 贷款申请 id
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loanAppId")]
        public string LoanAppId { get; set; }
        /// <summary>
        /// 自然人、法人或其他组织，个人默认“自然人”，企业默认“法人或其他组织”
        /// </summary>
        /// <returns></returns>
        [JsonProperty("user_borrowerProperty")]
        public string UserBorrowerProperty { get; set; }
        /// <summary>
        /// 工作性质 （账户类型=个人时必须）
        /// </summary>
        /// <returns></returns>
        [JsonProperty("job_occupation")]
        public string JobOccupation =>"商人";
        /// <summary>
        /// 行业分类（账户类型=个人时必须）
        /// </summary>
        /// <returns></returns>
        [JsonProperty("job_companySegment")]
        public string JobCompanySegment { get; set; }
        /// <summary>
        /// 年收入（账户类型=个人时必须）
        /// </summary>
        /// <returns></returns>
        [JsonProperty("person_annualIncome")]
        public string PersonAnnualIncome { get; set; }
        /// <summary>
        /// 行业（账户类型=企业时必须）
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_segment")]
        public string CompanySegment { get; set; }
        /// <summary>
        /// 年收入（账户类型=企业时必须）
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_totalIncome")]
        public string CompanyTotalIncome { get; set; }
        /// <summary>
        /// 总负债
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_allDeptAmt")]
        public string FinanceAllDeptAmt { get; set; }
        /// <summary>
        /// 其他网贷平台数量
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_otherLoanPlatformNum")]
        public string FinanceOtherLoanPlatformNum { get; set; }
        /// <summary>
        /// 其他网贷平台金额	
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_otherLoanPlatformAmt")]
        public string FinanceOtherLoanPlatformAmt { get; set; }
        /// <summary>
        /// 近6个月逾期笔数
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_delinquent180Num")]
        public string Financedelinquent180Num { get; set; }
        /// <summary>
        /// 近6个月逾期金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_delinquent180Amt")]
        public string FinanceDelinquent180Amt { get; set; }
        /// <summary>
        /// 近6个月逾期账户数
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_delinquent180AccountNum")]
        public string FinanceDelinquent180AccountNum { get; set; }
    }
}
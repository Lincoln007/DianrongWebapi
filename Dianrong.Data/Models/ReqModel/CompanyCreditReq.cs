using System;
using Newtonsoft.Json;
namespace Dianrong.Data.Models.ReqModel
{
    /*
{
"rc_info": {
  "rc_date": "xxx",//评级日期
  "rc_level": "xxx",//评级等级
  "apply_rc_purpose":"xxxx",//申请授信用途
  "suggest_amount": "xxx",//建议授信额度
  "loan_period": "xxx",//最长贷款周期
  "repayment_method": "xxx"//偿还方式
},
"enterprise_info": {
  "registration_date": "xxx",//平台注册日期
  "enterprise_name": "xxx",//主体企业名称
  "enterprise_no": "xxx",//营业证件号
  "business_address": "xxx",//经营地址
  "legal_person": "xxx",//法定代表人
  "legal_person_id_card": "xxx",//法人身份证号
  "legal_person_phone": "xxx",//法人手机
  "contact_person": "xxx",//实际控制人姓名
  "contact_person_id_card": "xxx",//实际控制人身份证号
  "contact_person_phone": "xxx",//实际控制人手机
  "associated_person": "xxx",//放款关联人姓名
  "associated_person_id_card": "xxx",//放款关联人身份证号
  "associated_person_phone": "xxx",//放款关联人手机
  "affiliated_partner": "xxx",//所属合作商
  "machine_nums": "xxx",//机器台次
  "total_annual_revenue": "xxx",//年度总收入
  "total_annual_debt": "xxx",//年度总负债
  "enterprise_industry": "xxx"//所属行业
},
"history_info":{
  "trade_total":"",//累计交易总金额
  "trade_frequency":"",//累计下单次数
  "avg_ttl_halfyear":"",//近6个月交易额平均值
  "avg_ttl_quarter":"",//近3个月交易额平均值
  "avg_frq_halfyear":"",//近6个月下单次数平均值
  "avg_frq_quarter":"",//近3个月下单次数平均值
  "avg_cpow_halfyear":"",//近6个月平均用电量
  "avg_cpow_quarter":"",//近3个月平均用电量
  "payment_days":""//账期
},
"bank_info":{
  "bank_account_name":"",//银行账号户名
  "bank_name":"",//开户行名称
  "bank_account_number":""//开户行账号
},
"other_info":{
  "pedestrians_credit_halfyear":"",//人行征信近6个月内逾期情况
  "other_platforms_nums":"",//其它互金平台借款平台数
  "other_platforms_amount":""//其它互金平台借款金额
},
"register_type": 1
}
    */
    /// <summary>
    /// 
    /// </summary>
    public class CompanyCreditReq : DianrongBaseReqModel
    {
        /// <summary>
        /// 企业授信数据表
        /// </summary>
        /// <returns></returns>
        [JsonProperty("rc_info")]
        public CompanyCreditReqRcInfo RcInfo { get; set; }
        /// <summary>
        /// 企业基本信息表
        /// </summary>
        /// <returns></returns>
        [JsonProperty("enterprise_info")]
        public CompanyCreditReqEnterpriseInfo EnterpriseInfo { get; set; }
        /// <summary>
        /// 历史交易数据表
        /// </summary>
        /// <returns></returns>
        [JsonProperty("history_info")]
        public CompanyCreditReqHistoryInfo HistoryInfo { get; set; }
        /// <summary>
        /// 放款银行信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_info")]
        public CompanyCreditBankInfo BankInfo { get; set; }
        /// <summary>
        /// 其它监管要求
        /// </summary>
        /// <returns></returns>
        [JsonProperty("other_info")]
        public CompanyCreditOtherInfo OtherInfo { get; set; }
        /// <summary>
        /// 授信类型，默认传1
        /// </summary>
        /// <returns></returns>

        [JsonProperty("register_type")]
        public string RegisterType { get { return "1"; } }
    }
    /// <summary>
    /// 企业授信数据表
    /// </summary>
    public class CompanyCreditReqRcInfo
    {
        /*
    rc_date	String	Y	评级日期	格式"2017-11-15"
    rc_level	String	Y	评级等级	"A1,B1,C1,D1..."
    apply_rc_purpose	String	Y	申请授信用途	
    suggest_amount	String	Y	建议授信额度	2000
    loan_period	String	Y	最长贷款周期	
    repayment_method	String	Y	偿还方式	
         */
        /// <summary>
        /// 评级日期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("rc_date")]
        public string RcDate
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 评级等级
        /// </summary>
        /// <returns></returns>
        [JsonProperty("rc_level")]
        public string RcLevel
        {
            get; set;
        }
        /// <summary>
        /// 申请授信用途
        /// </summary>
        /// <returns></returns>
        [JsonProperty("apply_rc_purpose")]
        public string RcPurpose
        {
            get
            {
                return "原材料采购";
            }
        }
        /// <summary>
        /// 建议授信额度
        /// </summary>
        /// <returns></returns>
        [JsonProperty("suggest_amount")]
        public string SuggestAmount { get; set; }
        /// <summary>
        /// 最长贷款周期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loan_period")]
        public string LoanPeriod { get; set; }
        /// <summary>
        /// 偿还方式
        /// </summary>
        /// <returns></returns>
        [JsonProperty("repayment_method")]
        public string RepaymentMethod { get { return "到期一次性还本付息"; } }

    }
    /// <summary>
    /// 企业基本信息表
    /// </summary>
    public class CompanyCreditReqEnterpriseInfo
    {
        /*
    "registration_date": "xxx",//平台注册日期
    "enterprise_name": "xxx",//主体企业名称
    "enterprise_no": "xxx",//营业证件号
    "business_address": "xxx",//经营地址
    "legal_person": "xxx",//法定代表人
    "legal_person_id_card": "xxx",//法人身份证号
    "legal_person_phone": "xxx",//法人手机
    "contact_person": "xxx",//实际控制人姓名
    "contact_person_id_card": "xxx",//实际控制人身份证号
    "contact_person_phone": "xxx",//实际控制人手机
    "associated_person": "xxx",//放款关联人姓名
    "associated_person_id_card": "xxx",//放款关联人身份证号
    "associated_person_phone": "xxx",//放款关联人手机
    "affiliated_partner": "xxx",//所属合作商
    "machine_nums": "xxx",//机器台次
    "total_annual_revenue": "xxx",//年度总收入
    "total_annual_debt": "xxx",//年度总负债
    "enterprise_industry": "xxx"//所属行业
         */
        /// <summary>
        /// 平台注册日期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("registration_date")]
        public string RegistrationDate { get { return DateTime.Now.ToString("yyyy-MM-dd"); } }
        /// <summary>
        /// 主体企业名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty("enterprise_name")]
        public string EnterpriseName { get; set; }
        /// <summary>
        /// 营业证件号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("enterprise_no")]
        public string EnterpriseNo { get; set; }
        /// <summary>
        /// 经营地址
        /// </summary>
        /// <returns></returns>
        [JsonProperty("business_address")]
        public string BusinessAddress { get; set; }
        /// <summary>
        /// 法定代表人
        /// </summary>
        /// <returns></returns>
        [JsonProperty("legal_person")]
        public string LegalPerson { get; set; }
        /// <summary>
        /// 法人身份证号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("legal_person_id_card")]
        public string LegalPersonIdCard { get; set; }
        /// <summary>
        /// 法人手机
        /// </summary>
        /// <returns></returns>
        [JsonProperty("legal_person_phone")]
        public string LegalPersonPhone { get; set; }
        /// <summary>
        /// 实际控制人姓名
        /// </summary>
        /// <returns></returns>
        [JsonProperty("contact_person")]
        public string ContactPerson { get; set; }
        /// <summary>
        /// 实际控制人身份证号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("contact_person_id_card")]
        public string ContactPersonIdCard { get; set; }
        /// <summary>
        /// 实际控制人手机
        /// </summary>
        /// <returns></returns>
        [JsonProperty("contact_person_phone")]
        public string ContactPersonPhone { get; set; }
        /// <summary>
        /// 放款关联人姓名
        /// </summary>
        /// <returns></returns>
        [JsonProperty("associated_person")]
        public string AssociatedPerson { get; set; }
        /// <summary>
        /// 放款关联人身份证号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("associated_person_id_card")]
        public string AssociatedPersonIdCard { get; set; }
        /// <summary>
        /// 放款关联人手机
        /// </summary>
        /// <returns></returns>
        [JsonProperty("associated_person_phone")]
        public string AssociatedPersonPhone { get; set; }
        /// <summary>
        /// 所属合作商
        /// </summary>
        /// <returns></returns>
        [JsonProperty("affiliated_partner")]
        public string AffiliatedPartner { get; set; }
        /// <summary>
        /// 机器台次
        /// </summary>
        /// <returns></returns>
        [JsonProperty("machine_nums")]
        public string MachineNums { get; set; }
        /// <summary>
        /// 年度总收入
        /// </summary>
        /// <returns></returns>
        [JsonProperty("total_annual_debt")]
        public string TotalAnnualDebt { get; set; }
        /// <summary>
        /// 年度总负债
        /// </summary>
        /// <returns></returns>
        [JsonProperty("total_annual_revenue")]
        public string TotalAnnualRevenue { get; set; }
        /// <summary>
        /// 所属行业
        /// </summary>
        /// <returns></returns>
        [JsonProperty("enterprise_industry")]
        public string EnterpriseIndustry { get { return "制造业"; } }


    }
    /// <summary>
    /// 
    /// </summary>
    public class CompanyCreditReqHistoryInfo
    {
        /*
        "trade_total":"",//累计交易总金额
        "trade_frequency":"",//累计下单次数
        "avg_ttl_halfyear":"",//近6个月交易额平均值
        "avg_ttl_quarter":"",//近3个月交易额平均值
        "avg_frq_halfyear":"",//近6个月下单次数平均值
        "avg_frq_quarter":"",//近3个月下单次数平均值
        "avg_cpow_halfyear":"",//近6个月平均用电量
        "avg_cpow_quarter":"",//近3个月平均用电量
        "payment_days":""//账期
         */
        /// <summary>
        /// 累计交易总金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trade_total")]
        public string TradeTotal { get; set; }
        /// <summary>
        /// 累计下单次数
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trade_frequency")]
        public string TradeFrequency { get; set; }
        /// <summary>
        /// 近6个月交易额平均值
        /// </summary>
        /// <returns></returns>
        [JsonProperty("avg_ttl_halfyear")]
        public string AvgTtlHalfyear { get; set; }
        /// <summary>
        /// 近3个月交易额平均值
        /// </summary>
        /// <returns></returns>
        [JsonProperty("avg_ttl_quarter")]
        public string AvgTtlQuarter { get; set; }
        /// <summary>
        /// 近6个月下单次数平均值
        /// </summary>
        /// <returns></returns>
        [JsonProperty("avg_frq_halfyear")]
        public string AvgFrqHalfyear { get; set; }
        /// <summary>
        /// 近3个月下单次数平均值
        /// </summary>
        /// <returns></returns>
        [JsonProperty("avg_frq_quarter")]
        public string AvgFrqQuarter { get; set; }
        /// <summary>
        /// 近6个月平均用电量
        /// </summary>
        /// <returns></returns>
        [JsonProperty("avg_cpow_halfyear")]
        public string AvgCpowHalfyear { get; set; }
        /// <summary>
        /// 近3个月平均用电量
        /// </summary>
        /// <returns></returns>
        [JsonProperty("avg_cpow_quarter")]
        public string AvgCpowQuarter { get; set; }
        /// <summary>
        /// 账期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("payment_days")]
        public string PaymentDays { get; set; }


    }
    /// <summary>
    /// 
    /// </summary>
    public class CompanyCreditBankInfo
    {
        /// <summary>
        /// 银行账号户名
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_account_name")]
        public string BankAccountName { get; set; }
        /// <summary>
        /// 开户行名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_name")]
        public string BankName { get; set; }
        /// <summary>
        /// 开户行账号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_account_number")]
        public string BankAccountNumber { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CompanyCreditOtherInfo
    {
        /// <summary>
        /// 人行征信近6个月内逾期情况
        /// </summary>
        /// <returns></returns>
        [JsonProperty("pedestrians_credit_halfyear")]
        public string PedestriansCreditHalfyear { get; set; }
        /// <summary>
        /// 其它互金平台借款平台数
        /// </summary>
        /// <returns></returns>
        [JsonProperty("other_platforms_nums")]
        public string OtherPlatformNums { get; set; }
        /// <summary>
        /// 其它互金平台借款金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("other_platforms_amount")]
        public string OtherPlatformAmount { get; set; }

    }
}
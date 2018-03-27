using System.Collections.Generic;
using Dianrong.Data.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dianrong.Data.Models.ReqModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ScpChainReq : DianrongBaseReqModel
    {
        /// <summary>
        /// 贷款信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("sCP_CHAIN_loanApp")]
        public ScpChainReqLoanApp ScpChainLoanApp { get; set; }

        /// <summary>
        /// 个人信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("sCP_CHAIN_personalInfo")]
        public ScpChainReqPersonInfo ScpChainReqPersonInfo { get; set; }
        /// <summary>
        /// 企业信息 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("sCP_CHAIN_companyInfo")]
        public ScpChainReqCompanyInfo ScpChainReqCompanyInfo { get; set; }
        /// <summary>
        /// 银行信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("sCP_CHAIN_bankAccountInfo")]
        public List<ScpChainReqBankAccountInfo> ScpChainReqBankAccountInfo { get; set; }
        /// <summary>
        /// 补充信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("additional_info")]
        public ScpChainReqAdditionalInfo AdditionalInfo { get; set; }
        /// <summary>
        /// 合规信息
        /// </summary>
        [JsonProperty("compliance_info")]
        public ComplianceInfo ComplianceInfo { get; set; }

        /// <summary>
        /// 外部交易id
        /// </summary>
        /// <returns></returns>
        [JsonProperty("extend_trade_id")]
        public string ExtendTradeId { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ScpChainReqLoanApp
    {

        /*
        loan_appAmount	String	Y	申请金额	请填写100至500万且为1倍数的金额
        loan_purpose	String	Y	贷款目的	见附件“LoanAppConfigEnums.java”【传值：对应该class的内部枚举类的name属性】
        loan_maturityType	String	Y	贷款期限单位	见附件“LoanAppConfigEnums.java”【传值：对应该class的内部枚举类的name属性】
        loan_maturity	String	loan_maturityType=按月，则必需	贷款期限(按月)	见附件“LoanAppConfigEnums.java”【传值：对应该class的内部枚举类的name属性】
        loan_maturityDaily	String	loan_maturityType=按天，则必需	贷款期限天（新增）	请输入1-30之间的整数，正则格式要求：(^[1-9]$)|(^[1-2]\d$)|(^30$)
        loan_paymentMethod	String	Y	还款方式	见附件“LoanAppConfigEnums.java”【传值：对应该class的内部枚举类的name属性】
        loan_title	String	Y	贷款标题	
        loan_description	String	Y	贷款描述	
         */
        /// <summary>
        /// 申请金额	请填写100至500万且为1倍数的金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loan_appAmount")]
        public string LoanAppAmount { get; set; }
        /// <summary>
        /// 贷款目的
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loan_purpose")]
        //  public string LoanPurpose { get; set; }
        public string LoanPurpose
        {
            get
            {
                return "原材料采购";
            }
        }
        /// <summary>
        /// 贷款期限单位
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loan_maturityType")]
        public string LoanMaturityType { get { return "按天"; } }
        /// <summary>
        /// 贷款期限(按月)
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loan_maturity")]
        public string LoanMaturity { get { return null; } }

        /// <summary>
        /// 贷款期限天 1-30 (^[1-9]$)|(^[1-2]\d$)|(^30$)
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loan_maturityDaily")]
        public string LoanMaturityDaily { get; set; }
        /// <summary>
        /// 还款方式
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loan_paymentMethod")]
        public string LoanPaymentMethod { get { return "到期一次性还本付息"; } }
        /// <summary>
        /// 贷款标题
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loan_title")]
        public string LoanTitle { get; set; }
        /// <summary>
        /// 贷款描述
        /// </summary>
        /// <returns></returns>
        [JsonProperty("loan_description")]
        public string LoanDescription { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ScpChainReqPersonInfo
    {
        /// <summary>
        /// 用户主体类型
        /// </summary>
        /// <returns></returns>
        [JsonProperty("user_subjectType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubjectType UserSubjectType { get; set; }
        /// <summary>
        /// 真实姓名 user_subjectType=个人，则必需
        /// </summary>
        /// <returns></returns>
        [JsonProperty("user_realName")]
        public string UserRealName { get; set; }
        /// <summary>
        /// 身份证号码 user_subjectType=个人，则必需
        /// </summary>
        /// <returns></returns>
        [JsonProperty("user_cardNum")]
        public string UserCardNum { get; set; }
        /// <summary>
        /// 年收入	请填写0-10000000000之间的数字，正则格式要求：^([1-9]\d{0,9}|10{10}|0)(\.\d{1,4})?$
        /// </summary>
        /// <returns></returns>
        [JsonProperty("person_annualIncome")]
        public string PersonAnnualIncome { get; set; }
        /// <summary>
        /// 手机号码	正则格式要求：^1[34578][0-9]{9}$
        /// </summary>
        /// <returns></returns>
        [JsonProperty("person_mobilePhone")]
        public string PersonMobilePhone { get; set; }
        /// <summary>
        /// 居住地址
        /// </summary>
        /// <returns></returns>
        [JsonProperty("person_residenceAddr")]
        public Address PersonResidenceAddr { get; set; }
        /// <summary>
        /// 婚姻情况	见附件“LoanAppConfigEnums.java”【传值：对应该class的内部枚举类的name属性】
        /// </summary>
        /// <returns></returns>
        [JsonProperty("person_maritalStatus")]
        public MaritalStatus PersonMaritalStatus { get; set; }
        /// <summary>
        /// 受托人姓名	
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trustee_name")]
        public string TrusteeName { get; set; }
        /// <summary>
        /// 受托人身份证号码	正则格式要求：(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trustee_cardNum")]
        public string TrusteeCardNum { get; set; }
        /// <summary>
        /// 受托人居住地址
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trustee_residenceAddr")]
        public Address TrusteeResidenceAddr { get; set; }
        /// <summary>
        /// 是否为法人	见附件“LoanAppConfigEnums.java”【传值：对应该class的内部枚举类的name属性】
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trustee_isRep")]
        public IsRep TrusteeIsRep { get; set; }
        /// <summary>
        /// 受托人年收入
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trustee_annualIncome")]
        public string TrusteeAnnualIncome { get; set; }
        /// <summary>
        /// 受托人手机号码	正则格式要求： ^1[34578][0-9]{9}$
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trustee_mobile")]
        public string TrusteeMobile { get; set; }
        /// <summary>
        /// 受托人现单位工作年限
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trustee_jobTenureYears")]
        public string TrusteeJobTenureYears { get; set; }
        /// <summary>
        /// 受托人现任职位
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trustee_jobTitle")]
        public string TrusteeJobTitle { get; set; }
        /// <summary>
        /// 受托人婚姻情况
        /// </summary>
        /// <returns></returns>
        [JsonProperty("trustee_maritalStatus")]
        public string TrusteeMaritalStatus { get; set; }
        /// <summary>
        /// 做四要素认证银行卡号	银行卡类型：储蓄卡，详见bank_account_no字段说明
        /// 1、当user_subjectType=个人，bank_account_no为借款人【user_realName】的银行卡号
        /// 2、当user_subjectType=企业，bank_account_no为受托人【trustee_name】的银行卡号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_account_no")]
        public string BankAccountNo { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ScpChainReqCompanyInfo
    {
        /// <summary>
        /// 公司名字
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司成立日期	示例：1494314142835
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_establishDate")]
        public string CompanyEstablishDate { get; set; }
        /// <summary>
        /// 企业行业分类	见附件“LoanAppConfigEnums.java”【传值：对应该class的内部枚举类的name属性】
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_segment")]
        public string CompanySegment { get { return "制造业"; } }
        /// <summary>
        /// 公司规模	见附件“LoanAppConfigEnums.java”【传值：对应该class的内部枚举类的name属性】
        /// 10人以下，20人以下，10-19人，20-49人，50-99人，100-199人，200-299人，300-499人，500-999人，1000人以下，上市公司，中国500强，世界500强
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_size")]
        public string CompanySize { get; set; }
        /// <summary>
        /// 电话	(xxx-xxxxxxxx) 正则格式要求：^0[0-9]{2,3}-[0-9]{7,8}$
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_telephone")]
        public string CompanyTelephone { get; set; }
        /// <summary>
        /// 工商注册号码	正则格式要求：^[A-Za-z0-9]{0,32}$
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_businessLicenseNum")]
        public string CompanyBusinessLicenseNum { get; set; }
        /// <summary>
        /// 注册资本	请填写0-10000000000之间的数字， 正则格式要求：^([1-9]\d{0,9}|10{10}|0)(\.\d{1,2})?$
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_registeredCapital")]
        public string CompanyRegisteredCapital { get; set; }
        /// <summary>
        /// 运营地址
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_operationAddress")]
        public Address CompanyOperationAddress { get; set; }
        /// <summary>
        /// 注册地址
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_registeredAddress")]
        public Address CompanyRegisteredAddress { get; set; }
        /// <summary>
        /// 运营地址
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_legalRepresentative")]
        public string CompanyLegalRepresentative { get; set; }
        /// <summary>
        /// 受托人婚姻情况
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_legalRepresentativeCardNumber")]
        public string CompanyLegalRepresentativeCardNumber { get; set; }
        /// <summary>
        /// 受托人婚姻情况
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_businessScope")]
        public string CompanyBusinessScope { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ScpChainReqBankAccountInfo
    {
        /// <summary>
        /// 账户名称	
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_accountName")]
        public string BankAccountName { get; set; }
        /// <summary>
        /// 支行名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_branch")]
        public string BankBranch { get; set; }
        /// <summary>
        /// 收款账户类型
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_type")]
        public BankType BankType { get; set; }
        /// <summary>
        /// 	开户行所在市
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_bankCity")]
        public string BankBankCity { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_bank")]
        public BankBank BankBank { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_accountNum")]
        public string BankAccountNum { get; set; }
        /// <summary>
        /// 开户行所在省
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_bankProvince")]
        public string BankBankProvince { get; set; }
        /// <summary>
        /// 账户持有人类型
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_ownerType")]
        public OwnerType BankOwnerType => OwnerType.受托人;
        /// <summary>
        /// 受托支付账号手机号码，即bank_accountNum的预留手机 正则格式要求：^1[34578][0-9]{9}$
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bank_bankPhone")]
        public string BankBankPhone { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class ScpChainReqAdditionalInfo
    {
        /// <summary>
        /// 聚化网年利率
        /// </summary>
        [JsonProperty("jhw_loan_intRate")]
        public string JhwLoanIntRate => "0.132";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("order_info")]
        public AdditionalInfoOrderInfo OrderInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("logistics_info")]
        public AdditionalInfoLogisticsInfo LogisticsInfo => new AdditionalInfoLogisticsInfo();
        /// <summary>
        /// 提供下载链接url
        /// </summary>
        /// <returns></returns>
        [JsonProperty("files")]
        public AdditionalInfoFiles Files { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("issued_confirm_info")]
        public IssuedConfirmInfo IssuedConfirmInfo { get; set; }

    }
    /// <summary>
    /// 地址信息
    /// </summary>
    public class Address
    {
        /// <summary>
        /// 省
        /// </summary>
        /// <returns></returns>
        [JsonProperty("province")]
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        /// <returns></returns>
        [JsonProperty("city")]
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        /// <returns></returns>
        [JsonProperty("district")]
        public string District { get; set; }
        /// <summary>
        /// 街道（详细到门牌号)
        /// </summary>
        /// <returns></returns>
        [JsonProperty("detailedAddress")]
        public string DetailedAddress { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class AdditionalInfoOrderInfo
    {
        /// <summary>
        /// 合同编号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("contract_no")]
        public string ContractNo { get; set; }
        /// <summary>
        /// 合同日期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("contract_date")]
        public string ContractDate { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty("goods_name")]
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品型号/规格
        /// </summary>
        /// <returns></returns>
        [JsonProperty("goods_marque")]
        public string GoodsMarque { get; set; }
        /// <summary>
        /// 商品单位
        /// </summary>
        /// <returns></returns>
        [JsonProperty("goods_unit")]
        public string GoodsUnit { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        /// <returns></returns>
        [JsonProperty("goods_price")]
        public string GoodsPrice { get; set; }
        /// <summary>
        /// 合同总额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("contract_total")]
        public string ContractTotal { get; set; }
        /// <summary>
        /// 提货地点
        /// </summary>
        /// <returns></returns>
        [JsonProperty("pickup_address")]
        public string PickupAddress { get; set; }
        /// <summary>
        /// 提货日期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("pickup_date")]
        public string PickupDate { get; set; }
        /// <summary>
        /// 运输方式
        /// </summary>
        /// <returns></returns>
        [JsonProperty("transport_mode")]
        public string TransportMode { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        /// <returns></returns>
        [JsonProperty("payment_mode")]
        public string PaymentMode { get; set; }
        /// <summary>
        /// 履约保证金
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bid_bound")]
        public string BidBound { get; set; }
        /// <summary>
        /// 保证金比例
        /// </summary>
        /// <returns></returns>
        [JsonProperty("bid_rate")]
        public double BidRate { get; set; }
        /// <summary>
        /// 结算价格
        /// </summary>
        /// <returns></returns>
        [JsonProperty("settlement_price")]
        public string SettlementPrice { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class AdditionalInfoLogisticsInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public AdditionalInfoLogisticsInfo()
        {
            this.DeliveryAddress = "";
            this.DeliveryDate = "";
            this.DeliveryName = "";
            this.LogisticsCompany = "";
            this.ReceiverAddress = "";
            this.ReceiverName = "";
            this.TrackNo = "";
        }
        /// <summary>
        /// 物流公司名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty("logistics_company")]
        public string LogisticsCompany { get; set; }
        /// <summary>
        /// 物流单号
        /// </summary>
        /// <returns></returns>
        [JsonProperty("track_no")]
        public string TrackNo { get; set; }
        /// <summary>
        /// 发货日期
        /// </summary>
        /// <returns></returns>
        [JsonProperty("delivery_date")]
        public string DeliveryDate { get; set; }
        /// <summary>
        /// 发货人名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty("delivery_name")]
        public string DeliveryName { get; set; }
        /// <summary>
        /// 发货地址
        /// </summary>
        /// <returns></returns>
        [JsonProperty("delivery_address")]
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 收货人名称
        /// </summary>
        /// <returns></returns>
        [JsonProperty("receiver_name")]
        public string ReceiverName { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        /// <returns></returns>
        [JsonProperty("receiver_address")]
        public string ReceiverAddress { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AdditionalInfoFiles
    {
        /// <summary>
        /// 下游采购合同
        /// </summary>
        /// <returns></returns>
        [JsonProperty("purchase_contract")]
        public string PurchaseContract { get; set; }
        /// <summary>
        /// 送货签收单
        /// </summary>
        /// <returns></returns>
        [JsonProperty("cargo_receipt")]
        public string CargoReceipt { get; set; }

    }
    /// <summary>
    /// 核实资金用途
    /// </summary>
    public class IssuedConfirmInfo
    {
        /// <summary>
        /// 核实资金用途
        /// </summary>
        /// <returns></returns>
        [JsonProperty("capital_use")]
        public string CapitalUse => "塑料商品制造";

    }

    /// <summary>
    /// 合规信息
    /// </summary>
    public class ComplianceInfo
    {
        /// <summary>
        /// 合规信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("personal_compliance_info")]
        public PersonComplianceDetail PersonComplianceInfo { get; set; }

        /// <summary>
        /// 合规信息
        /// </summary>
        [JsonProperty("company_compliance_info")]
        public CompanyComplianceDetail CompanyComplianceDetail { get; set; }
    }
    /// <summary>
    /// 个人合规信息
    /// </summary>
    // [JsonProperty("")]
    public class PersonComplianceDetail
    {
        /// <summary>
        /// 主体性质
        /// 选项为：自然人、法人或其他组织，个人默认“自然人”，企业默认“法人或其他组织”
        /// </summary>
        /// <returns></returns>
        [JsonProperty("user_borrowerProperty")]
        public string UserBorrowProperty { get; set; }
        /// <summary>
        /// 总负债 double格式的金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_allDeptAmt")]
        public string FinanceAllDeptAmt { get; set; }
        /// <summary>
        /// 其他网络借贷平台数量 整型数字
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_otherLoanPlatformNum")]
        public string FinanceOtherLoanPlatformNum => "0";
        /// <summary>
        /// 其他网络借贷平台金额	double格式的金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_otherLoanPlatformAmt")]
        public string FinanceOtherLoanPlatformAmt => "0.00";
        /// <summary>
        /// 行业分类
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_segment")]
        public string CompanySegment => "制造业";
        /// <summary>
        /// 年收入	0-10000000000之间的数字
        /// </summary>
        /// <returns></returns>
        [JsonProperty("person_annualIncome")]
        public string PersonAnnualIncome { get; set; }

    }
    /// <summary>
    /// 公司合规信息 
    /// </summary>
    public class CompanyComplianceDetail
    {
        /// <summary>
        /// 主体性质
        /// 选项为：自然人、法人或其他组织，个人默认“自然人”，企业默认“法人或其他组织”
        /// </summary>
        /// <returns></returns>
        [JsonProperty("user_borrowerProperty")]
        public string UserBorrowProperty { get; set; }
        /// <summary>
        /// 总负债 double格式的金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_allDeptAmt")]
        public string FinanceAllDeptAmt { get; set; }
        /// <summary>
        /// 其他网络借贷平台数量 整型数字
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_otherLoanPlatformNum")]
        public string FinanceOtherLoanPlatformNum => "0";
        /// <summary>
        /// 其他网络借贷平台金额	double格式的金额
        /// </summary>
        /// <returns></returns>
        [JsonProperty("finance_otherLoanPlatformAmt")]
        public string FinanceOtherLoanPlatformAmt => "0.00";
        /// <summary>
        /// 行业分类
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_segment")]
        public string CompanySegment => "制造业";
        /// <summary>
        /// 总营业收入	0-10000000000之间的数字
        /// </summary>
        /// <returns></returns>
        [JsonProperty("company_totalIncome")]
        public string CompanyTotalIncome { get; set; }
    }
}
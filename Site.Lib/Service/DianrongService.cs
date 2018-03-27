using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Dianrong.Data.Enums;
using Dianrong.Data.Models;
using Dianrong.Data.Models.ReqModel;
using Dianrong.Data.Models.RspModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Site.Common.Helpers;
using Site.Common.Models;
using Site.Lib.IService;
using Site.Lib.Model.ConfigModel;

namespace Site.Lib.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class DianrongService : IDianrongService
    {
        private readonly DianrongConfigModel configModel;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public DianrongService(IOptions<DianrongConfigModel> config)
        {
            this.configModel = config.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CompanyCreditRsp> CompanyCredit(CompanyCreditReq req)
        {
            var reqModel = DianrongHelper.BuildReqModel(req, configModel.ChannelId);
            var rst = await DianrongHelper.GetDianrongRsp<CompanyCreditRsp>(configModel.CompanyCreditUrl, reqModel);
            return rst;

        }
        /// <summary>
        /// 查询贷款信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<QueryLoanInfoRsp> QueryLoanInfo(QueryLoanInfoReq req)
        {
            req.LoanAppId.NotNull("贷款申请编号");
            var reqModel = DianrongHelper.BuildReqModel(req, configModel.ChannelId);
            var rst = await DianrongHelper.GetDianrongRsp<QueryLoanInfoRsp>(configModel.QueryLoanInfoUrl, reqModel);
            return rst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ScpChainRsp> ScpChain(ScpChainReq req)
        {
            #region 参数验证
            req.NotNull("贷款申请请求参数");
            req.ScpChainLoanApp.NotNull("贷款信息");
            req.ScpChainReqPersonInfo.NotNull("个人信息");
            if (req.ScpChainReqPersonInfo.UserSubjectType == SubjectType.企业)
            {
                req.ScpChainReqCompanyInfo.NotNull("企业信息");
            }
            req.ScpChainReqBankAccountInfo.NotNull("银行信息");
            req.AdditionalInfo.NotNull("补充信息");
            req.ExtendTradeId.NotNull("外部交易id");

            #region loanApp
            var loanApp = req.ScpChainLoanApp;
            loanApp.LoanMaturityDaily.RegexValid("(^[1-9]$)|(^[1-2]\\d$)|(^30$)", "贷款期限天");
            #endregion
            #region PersonInfo
            var personInfo = req.ScpChainReqPersonInfo;
            personInfo.UserSubjectType.EnumValueValid("用户主体类型");
            personInfo.BankAccountNo.NotNull("银行卡号");
            if (req.ScpChainReqPersonInfo.UserSubjectType == SubjectType.个人)
            {
                personInfo.UserRealName.NotNull("真实姓名");
                personInfo.UserCardNum.RegexValid("(^\\d{15}$)|(^\\d{18}$)|(^\\d{17}(\\d|X|x)$)", "身份证号码");
                personInfo.PersonAnnualIncome.RegexValid("^([1-9]\\d{0,9}|10{10}|0)(\\.\\d{1,4})?$", "年收入");
                personInfo.PersonMobilePhone.RegexValid("^1[34578][0-9]{9}$", "手机号码");
                personInfo.PersonResidenceAddr.NotNull("居住地址");
                var redisenceAddr = personInfo.PersonResidenceAddr;
                redisenceAddr.Province.NotNull("省");
                redisenceAddr.City.NotNull("市");
                redisenceAddr.District.NotNull("区");
                redisenceAddr.DetailedAddress.NotNull("街道");

                personInfo.PersonMaritalStatus.EnumValueValid("婚姻状况");

                //写个默认值,以后改掉
                req.ComplianceInfo = new ComplianceInfo()
                {
                    PersonComplianceInfo = new PersonComplianceDetail()
                    {
                        UserBorrowProperty = "自然人",
                        PersonAnnualIncome = "100000",
                        FinanceAllDeptAmt = "0.00",
                    }
                };
            }
            else if (req.ScpChainReqPersonInfo.UserSubjectType == SubjectType.企业)
            {
                personInfo.TrusteeName.NotNull("受托人姓名");
                personInfo.TrusteeCardNum.RegexValid("(^\\d{15}$)|(^\\d{18}$)|(^\\d{17}(\\d|X|x)$)", "受托人身份证号码");
                var trusteeAddr = personInfo.TrusteeResidenceAddr;
                trusteeAddr.NotNull("省");
                trusteeAddr.NotNull("市");
                trusteeAddr.NotNull("区");
                trusteeAddr.NotNull("街道");

                personInfo.TrusteeIsRep.EnumValueValid("是否为法人");
                personInfo.TrusteeMobile.RegexValid("^1[34578][0-9]{9}$", "受托人手机号码");
                personInfo.TrusteeJobTitle.NotNull("受托人现任职位");

                req.ComplianceInfo = new ComplianceInfo()
                {
                    CompanyComplianceDetail = new CompanyComplianceDetail()
                    {
                        CompanyTotalIncome = "1000000",
                        FinanceAllDeptAmt = "0",
                        UserBorrowProperty = "法人或其他组织"
                    }
                };
            }
            #endregion
            #region CompanyInfo
            if (req.ScpChainReqPersonInfo.UserSubjectType == SubjectType.企业)
            {
                var companyInfo = req.ScpChainReqCompanyInfo;
                companyInfo.CompanyBusinessLicenseNum.RegexValid("^[A-Za-z0-9]{0,32}$", "工商注册号码");
                companyInfo.CompanyRegisteredCapital.RegexValid("^([1-9]\\d{0,9}|10{10}|0)(\\.\\d{1,2})?$", "注册资本");
                companyInfo.CompanyLegalRepresentativeCardNumber.RegexValid("(^\\d{15}$)|(^\\d{18}$)|(^\\d{17}(\\d|X|x)$)", "法人身份证号");

                //写个默认值,以后改掉
                req.ComplianceInfo = new ComplianceInfo()
                {
                    CompanyComplianceDetail = new CompanyComplianceDetail()
                    {
                        UserBorrowProperty = "法人或其他组织",
                        CompanyTotalIncome = "1000000",
                        FinanceAllDeptAmt = "0.00"
                    }
                };
            }
            #endregion
            #region BankAccountInfo
            foreach (var bankInfo in req.ScpChainReqBankAccountInfo)
            {
                bankInfo.BankType.EnumValueValid("收款账户类型");
                bankInfo.BankBank.EnumValueValid("开户行");
                bankInfo.BankOwnerType.EnumValueValid("账户持有人类型");
            }

            #endregion
            #region 合规信息

            #endregion
            #endregion


            var reqModel = DianrongHelper.BuildReqModel(req, configModel.ChannelId);
            var rst = await DianrongHelper.GetDianrongRsp<ScpChainRsp>(configModel.ScpChainUrl, reqModel);
            return rst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<SignUrlRsp> SignUrl(SignUrlReq req)
        {
            return await DianrongHelper.GetDianrongRsp<SignUrlRsp>(configModel.SignUrl, req,configModel.ChannelId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<QueryPaymentInfoRsp> QueryPaymentInfo(QueryPaymentInfoReq req)
        {
            return await DianrongHelper.GetDianrongRsp<QueryPaymentInfoRsp>(configModel.QueryPaymentInfoUrl, req, configModel.ChannelId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<QueryRepaymentPlanRsp> QueryRepaymentPlan(QueryRepaymentPlanReq req)
        {
            return await DianrongHelper.GetDianrongRsp<QueryRepaymentPlanRsp>(configModel.QueryRepaymentPlanUrl, req, configModel.ChannelId);
        }
        /// <summary>
        /// 还款界面
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<RepaymentRsp> DianRongRepayment(RepaymentReq req)
        {
            req.NotNull("请求参数");
            req.Phone.NotNull("手机号");
            var channelId = configModel.ChannelId;
            var randomStr = DianrongHelper.GetRandomStr();
            // randomStr = "6rCnR0dVCVw=";
            var nonce = DianrongHelper.GetNonce(randomStr, false);
            var reqData = new Dictionary<string, object>() { { "encryptPhone", req.Phone }, { "channelId", channelId } };
            var encryptReqData = DianrongHelper.GetReqData(reqData, randomStr);
            var sign = JsonConvert.SerializeObject(reqData, Formatting.None).GetMd5String(true);
            var reqData2 = new Dictionary<string, string>(){
                {"encryptReqData",encryptReqData},
                {"sign",sign}
            };
            var encryptData = DianrongHelper.GetReqData(reqData2, randomStr);

            return new RepaymentRsp()
            {
                BaseUrl = configModel.GetRepaymentUrl,
                ChannelId = channelId,
                Encrypt = WebUtility.UrlEncode(encryptData),
                Nonce = WebUtility.UrlEncode(nonce)
            };
        }
        /// <summary>
        /// 补充合规信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ComplianceRsp> Compliance(ComplianceReq req)
        {
            return await DianrongHelper.GetDianrongRsp<ComplianceRsp>(configModel.ComplianceUrl, req, configModel.ChannelId);
        }
        /// <summary>
        /// 黑名单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<CheckBlackListRsp> CheckBlackList(CheckBlackListReq req)
        {
            req.NotNull("请求参数");
            req.PersonCardNum.NotNull("身份证号码");
            req.PersonCardNum.RegexValid("(^\\d{15}$)|(^\\d{18}$)|(^\\d{17}(\\d|X|x)$)","身份证号码");
            req.PersonMobilePhone.NotNull("手机号码");
            req.PersonMobilePhone.RegexValid("^1[34578][0-9]{9}$","手机号");
            req.PersonRealName.NotNull("真实姓名");
            return await DianrongHelper.GetDianrongRsp<CheckBlackListRsp>(configModel.CheckBlackListUrl,req,configModel.ChannelId);
        }
    }
}
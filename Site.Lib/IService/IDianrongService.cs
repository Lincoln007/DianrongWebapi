using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dianrong.Data.Models;
using Dianrong.Data.Models.ReqModel;
using Dianrong.Data.Models.RspModel;

namespace Site.Lib.IService
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDianrongService
    {
        /// <summary>
        /// 企业基本信息推送接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<CompanyCreditRsp> CompanyCredit(CompanyCreditReq req);
        /// <summary>
        /// 贷款申请接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ScpChainRsp> ScpChain(ScpChainReq req);
        /// <summary>
        /// 查询贷款信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<QueryLoanInfoRsp> QueryLoanInfo(QueryLoanInfoReq req);
        /// <summary>
        /// 获取在线签约URL
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<SignUrlRsp> SignUrl(SignUrlReq req);
        /// <summary>
        /// 查询还款信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<QueryPaymentInfoRsp> QueryPaymentInfo(QueryPaymentInfoReq req);
        /// <summary>
        /// 还款计划查询接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<QueryRepaymentPlanRsp> QueryRepaymentPlan(QueryRepaymentPlanReq req);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<RepaymentRsp> DianRongRepayment(RepaymentReq req);
        /// <summary>
        /// 补充合规信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ComplianceRsp> Compliance(ComplianceReq req);
        /// <summary>
        /// 黑名单查询接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<CheckBlackListRsp> CheckBlackList(CheckBlackListReq req);
    }
}

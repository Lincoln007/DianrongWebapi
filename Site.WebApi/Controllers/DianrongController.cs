using System.Threading.Tasks;
using Dianrong.Data.Models.ReqModel;
using Dianrong.Data.Models.RspModel;
using Microsoft.AspNetCore.Mvc;
using Site.Lib.IService;

namespace Site.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DianrongController : Controller
    {
        private readonly IDianrongService dianrongService;
        public DianrongController(IDianrongService dianrongService)
        {
            this.dianrongService = dianrongService;
        }
        /// <summary>
        /// 企业基本信息推送接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost, Route("CompanyCredit")]
        [ProducesResponseType(typeof(CompanyCreditRsp), 200)]
        public async Task<IActionResult> CompanyCredit([FromBody]CompanyCreditReq req)
        {
            var rst = await dianrongService.CompanyCredit(req);
            return Ok(rst);
        }
        /// <summary>
        /// 贷款申请
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost, Route("ScpChainReq")]
        [ProducesResponseType(typeof(ScpChainRsp), 200)]
        public async Task<IActionResult> ScpChain([FromBody] ScpChainReq req)
        {
            var rst = await dianrongService.ScpChain(req);
            return Ok(rst);
        }
        /// <summary>
        /// 查询贷款信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost, Route("QueryLoanInfo")]
        [ProducesResponseType(typeof(QueryLoanInfoRsp), 200)]
        public async Task<IActionResult> QueryLoanInfo([FromBody] QueryLoanInfoReq req)
        {
            var rst = await dianrongService.QueryLoanInfo(req);
            return Ok(rst);
        }

        /// <summary>
        /// 查询还款信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost, Route("QueryPaymentInfo")]
        [ProducesResponseType(typeof(QueryPaymentInfoRsp), 200)]
        public async Task<IActionResult> QueryPaymentInfo([FromBody] QueryPaymentInfoReq req)
        {
            var rst = await dianrongService.QueryPaymentInfo(req);
            return Ok(rst);
        }
        /// <summary>
        /// 还款计划查询接口
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost, Route("QueryRepaymentPlan")]
        [ProducesResponseType(typeof(QueryRepaymentPlanRsp), 200)]
        public async Task<IActionResult> ScpChain([FromBody] QueryRepaymentPlanReq req)
        {
            var rst = await dianrongService.QueryRepaymentPlan(req);
            return Ok(rst);
        }
        /// <summary>
        /// 获取在线签约URL
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost, Route("SignUrl")]
        [ProducesResponseType(typeof(SignUrlRsp), 200)]
        public async Task<IActionResult> ScpChain([FromBody] SignUrlReq req)
        {
            var rst = await dianrongService.SignUrl(req);
            return Ok(rst);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost, Route("GetRepaymentUrl")]
        public async Task<IActionResult> GetRepaymentUrl ([FromBody] RepaymentReq req)
        {
            var rst = await dianrongService.DianRongRepayment(req);

            return Ok(rst);
        }
        /// <summary>
        /// 补充合规信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost, Route("Compliance")]
        [ProducesResponseType(typeof(ComplianceRsp),200)]
        public async Task< IActionResult> Compliance([FromBody] ComplianceReq req)
        {
            var rst = await dianrongService.Compliance(req);
            return Ok(rst);
        }
        /// <summary>
        /// 黑名单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost,Route("CheckBlackList")]
        [ProducesResponseType(typeof(CheckBlackListRsp),200)]
        public async Task<IActionResult> CheckBlackList([FromBody] CheckBlackListReq req)
        {
            return Ok(await dianrongService.CheckBlackList(req));
        }
    }
}
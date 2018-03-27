namespace Site.Lib.Model.ConfigModel
{
    /// <summary>
    /// 点融url配置
    /// </summary>
    public class DianrongConfigModel
    {
        /// <summary>
        /// 通道id
        /// </summary>
        /// <returns></returns>
        public string ChannelId { get; set; }
        /// <summary>
        /// 企业基本信息推送接口
        /// </summary>
        /// <returns></returns>
        public string CompanyCreditUrl { get; set; }
        /// <summary>
        /// 贷款申请接口
        /// </summary>
        /// <returns></returns>
        public string ScpChainUrl { get; set; }
        /// <summary>
        /// 贷款状态查询
        /// </summary>
        /// <returns></returns>
        public string QueryLoanInfoUrl { get; set; }
        /// <summary>
        /// 获取在线签约URL
        /// </summary>
        /// <returns></returns>
        public string SignUrl { get; set; }
        /// <summary>
        /// 查询还款信息
        /// </summary>
        /// <returns></returns>
        public string QueryPaymentInfoUrl { get; set; }
        /// <summary>
        /// 还款计划查询接口
        /// </summary>
        /// <returns></returns>
        public string QueryRepaymentPlanUrl { get; set; }
        /// <summary>
        /// 还款界面url
        /// </summary>
        /// <returns></returns>
        public string GetRepaymentUrl { get; set; }
        /// <summary>
        /// 合规信息
        /// </summary>
        /// <returns></returns>
        public string ComplianceUrl { get; set; }
        /// <summary>
        /// 黑名单查询接口
        /// </summary>
        /// <returns></returns>
        public string CheckBlackListUrl { get; set; }

    }
}
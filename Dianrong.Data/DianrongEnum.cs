using System;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
// using System.ComponentModel.DataAnnotations;
namespace Dianrong.Data.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public static class DianrongEnumHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetDesc<T>(this T t) where T : struct
        {
            var memberInfo = typeof(T).GetMember(t.ToString()).FirstOrDefault();
            if (memberInfo != null)
            {
                var attr = (memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), true) as DescriptionAttribute[]).FirstOrDefault();
                return attr.Description;
            }
            return "未知";
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum SubjectType
    {
        ///
        企业,
        ///
        个人

    }
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaritalStatus
    {
        ///未婚
        未婚,
        ///已婚
        已婚,
        ///离异
        离异,
        ///其他
        其他
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BankType
    {
        ///
        企业,
        ///
        个人

    }
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BankBank
    {
        ///
        中国工商银行,
        ///
        华夏银行,
        ///
        中国建设银行,
        ///
        中国民生银行,
        ///
        招商银行,
        ///
        兴业银行,
        ///
        中国银行,
        ///
        中国农业银行
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OwnerType
    {
        ///
        借款人,
        ///
        受托人
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod
    {
        ///等额本息
        [Description("等额本息")]
        AMORTIZATION = 1,
        ///等本等息
        [Description("等本等息")]
        EQUAL_PRINCIPAL_INTEREST = 2,
        ///每月还息，按季度还本
        [Description("每月还息，按季度还本")]
        SESSION_PERIOD = 3,
        ///每月还息，按半年还本
        [Description("每月还息，按半年还本")]
        HALF_YEAR_PERIOD = 4,
        ///每月还息，到期一次性还本
        [Description("每月还息，到期一次性还本")]
        PAY_AT_THE_END = 5,
        ///到期一次性还本付息
        [Description("到期一次性还本付息")]
        BULLET = 6,
        ///到期一次性还本付息,固定利息
        [Description("到期一次性还本付息,固定利息")]
        BULLET_FIXED_INTEREST = 7,
        ///等额本息,支持进位
        [Description("等额本息,支持进位")]
        AMORTIZATION_CONFIGURATION = 8
    }
    /// <summary>
    /// 周期类型
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MaturityType
    {
        ///月
        [Description("月")]
        MONTHLY = 1,
        ///天
        [Description("天")]
        DAILY = 2,
        ///周
        [Description("周")]
        WEEKLY = 3
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LoanStatus
    {
        ///未提交
        [Description("未提交")]
        NEW = 1,
        ///投资中
        [Description("投资中")]
        IN_FUNDING = 2,
        ///审批拒绝
        [Description("审批拒绝")]
        REJECTED = 3,
        ///已放款
        [Description("已放款")]
        ISSUED = 4,
        ///等待客户确认
        [Description("等待客户确认")]
        APPROVED = 5,
        ///签约完成
        [Description("签约完成")]
        ACCEPTED = 6,
        ///贷款取消
        [Description("贷款取消")]
        WITHDRAWN = 7,
        ///已提交
        [Description("已提交")]
        SUBMITTED = 8,
        ///审批中
        [Description("审批中")]
        IN_REVIEW = 9,
        ///需补件
        [Description("需补件")]
        HOLD = 10,
        ///客户接受贷款
        [Description("客户接受贷款")]
        OFFER_ACCEPTED = 11,
        ///放款中
        [Description("放款中")]
        ISSUING = 12
    }
    /// <summary>
    /// 还款状态
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PayStatus
    {
        ///未还款
        [Description("未还款")]
        UNPAID = 1,
        ///已还款
        [Description("	已还款")]
        PAID = 2,
        ///逾期,宽限期中
        [Description("逾期,宽限期中")]
        GRACE_PERIOD = 3,
        ///逾期,超过宽限期
        [Description("逾期,超过宽限期")]
        OUTOF_GRACE = 4,
        ///逾期未还款
        [Description("逾期未还款")]
        CLOSED_UNPAID = 5
    }
    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IsRep
    {
        ///
        是,
        ///
        否
    }

}
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dianrong.Data.Models.RspModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CompanyCreditRsp : DianrongBaseRspModel<CompanyCreditContent>
    {

    }
    /// <summary>
    /// 
    /// </summary>
    public class CompanyCreditContent
    {
        /// <summary>
        /// 
        /// </summary>
        public CompanyCreditContent()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("code")]
        public int Code
        {
            get;
            set;
        }
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
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonProperty("message")]
        public string Message
        {
            get;
            set;
        }


    }
}

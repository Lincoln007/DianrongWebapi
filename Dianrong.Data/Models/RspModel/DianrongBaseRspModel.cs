using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dianrong.Data.Models.RspModel
{
    /// <summary>
    /// 解密对象
    /// </summary>
    public class DianrongBaseRspModel<T> : DianrongRspModel where T : class
    {


        /// <summary>
        /// 
        /// </summary>
        public DianrongBaseRspModel()
        {
        }

        /// <summary>
        /// 实际model
        /// </summary>
        /// <value>The content object.</value>
        public T ContentObj { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Body { get; set; }
    }
}

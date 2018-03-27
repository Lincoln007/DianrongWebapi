using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Site.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Site.Common.Helpers;
using System.Net.Http;
using System.IO;

namespace Site.WebApi.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private const string MSG = "网络异常，请重试";
        private readonly ILogger logger;
        private readonly ILogger bizLogger;
        /// <summary>
        /// 
        /// </summary>
        public ApiExceptionFilterAttribute()
        {
            this.logger = LogManager.GetCurrentClassLogger();
            this.bizLogger = LogManager.GetLogger("bizError");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        protected ApiExceptionFilterAttribute(ILogger logger)
        {
            this.logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var reqBody = "";
            var path = context.HttpContext.Request.Path.ToString();
            if (context.HttpContext.Request.Method == HttpMethod.Post.ToString())
            {
                context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                using (var sr = new StreamReader(context.HttpContext.Request.Body))
                {
                    reqBody = await sr.ReadToEndAsync();
                    reqBody = reqBody.Replace("\r", "").Replace("\n", "");
                }
            }

            context.ExceptionHandled = true;
            if (context.Exception is BizException)
            {
                var bizError = context.Exception as BizException;
                context.Result = new ContentResult() { Content = new { contentObj = new { message = bizError.BizMsg }, result = "error", code = bizError.BizErrorId }.ToJsonString(), ContentType = "application/json", StatusCode = 200 };
                bizLogger.Info(bizError, () => $"业务异常，地址{path},参数{reqBody},异常信息: {bizError.BizMsg},{bizError.HiddenMsg}");
            }
            else if (context.Exception is DbUpdateException)
            {
                var dbError = context.Exception as DbUpdateException;
                context.Result = new ContentResult() { Content = new { contentObj = new { message = MSG }, result = "error" }.ToJsonString(), ContentType = "application/json", StatusCode = 500 };
                logger.Error(dbError, () => $"数据库异常,地址{path},参数{reqBody},异常信息:{dbError.Message},{dbError.InnerException?.Message},{dbError.StackTrace}");
            }
            else
            {
                var ex = context.Exception;
                context.Result = new ContentResult() { Content = new { contentObj = new { message = MSG }, result = "error" }.ToJsonString(), ContentType = "applicatio/json", StatusCode = 500 };
                logger.Error(ex, () => $"系统异常，地址{path},参数{reqBody},异常信息:{ex.Message},{ex.StackTrace}");
            }

        }
    }
}

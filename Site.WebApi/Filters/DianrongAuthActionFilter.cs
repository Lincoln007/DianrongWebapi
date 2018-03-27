using Dianrong.Data.Models.RspModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Site.WebApi.Filters
{
    public class DianrongAuthActionFilter : IActionFilter
    {
        private const string TOKEN_KEY="DianrongToken";
        public string Token { get; set; }
        public DianrongAuthActionFilter(string token)
        {
            this.Token = token;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var isContain = context.HttpContext.Request.Headers.TryGetValue(TOKEN_KEY,out StringValues token);

            if (!isContain || token!= Token)
            {
                context.Result = new ContentResult(){
                    StatusCode = 401,
                    Content =JsonConvert.SerializeObject(new DianrongBaseRspModel<dynamic>(){
                        Result="error",
                        ContentObj= new {
                            Code="999401",
                            Message="点融：非法请求"
                        }
                    }),
                    ContentType = "application/json"
                };
            }
        }
    }
}
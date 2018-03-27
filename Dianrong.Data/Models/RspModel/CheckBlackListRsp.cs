using Newtonsoft.Json;

namespace Dianrong.Data.Models.RspModel
{
    public class CheckBlackListRsp : DianrongBaseRspModel<CheckBlackListContent>
    {

    }
    public class CheckBlackListContent
    {
        /// <summary>
        /// 20000	"success"
        /// 30000	"internal error"
        /// 40001	"Invalid Parameter"
        /// 40002	"Invalid Operation"
        /// 40003	"Auth failed"
        /// 40004	"Data not found"
        /// </summary>
        /// <returns></returns>
        [JsonProperty("code")]
        public string Code { get; set; }
        /// <summary>
        /// 请求处理信息
        /// </summary>
        /// <returns></returns>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
namespace OpenseaBlzui.Models
{
    public class HttpRequestInfo
    {
        /// <summary>
        /// Route 信息
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        /// 连接标识
        /// </summary>
        public string Flag { get; set; }

        /// <summary>
        /// 响应内容
        /// </summary>
        public dynamic Content { get; set; }

        /// <summary>
        /// Http Method
        /// </summary>
        public HttpMethod MethodRequst { get; set; }
    }
}

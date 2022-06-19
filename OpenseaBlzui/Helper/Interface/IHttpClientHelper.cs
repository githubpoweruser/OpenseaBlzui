using OpenseaBlzui.Models;

namespace OpenseaBlzui.Helper.Interface
{
    public interface IHttpClientHelper
    {
        Task<string> HttpClientGetAsync(HttpRequestInfo httpRequestInfo);
        Task<string> HttpClientPostAsync(HttpRequestInfo httpRequestInfo);
        Task<string> HttpClientPutAsync(HttpRequestInfo httpRequestInfo);
        Task<string> HttpClientDeleteAsync(HttpRequestInfo httpRequestInfo);
        Task<string> HttpClientSendAsync(HttpRequestInfo httpRequestInfo);
    }
}
using OpenseaBlzui.Helper.Interface;
using OpenseaBlzui.Models;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace OpenseaBlzui.Helper
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientHelper(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Http Client Get
        /// </summary>
        /// <typeparam name="T">接收数据的类型</typeparam>
        /// <param name="content">Http连接基本数据</param>
        /// <returns>接收数据的类型对象</returns>
        public async Task<string> HttpClientGetAsync(HttpRequestInfo httpRequestInfo)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(httpRequestInfo.Flag);
                using var httpResponseMessage = await httpClient.GetAsync(httpRequestInfo.Route);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                }
                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Http Client Post
        /// </summary>
        /// <param name="content">Http连接基本数据</param>
        /// <returns></returns>
        public async Task<string> HttpClientPostAsync(HttpRequestInfo httpRequestInfo)
        {
            try
            {
                var stringContent = new StringContent(JsonSerializer.Serialize(httpRequestInfo.Content), Encoding.UTF8, Application.Json);
                var httpClient = _httpClientFactory.CreateClient(httpRequestInfo.Flag);
                using var httpResponseMessage = await httpClient.PostAsync(httpRequestInfo.Route, stringContent);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                }
                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Http Client Put
        /// </summary>
        /// <param name="content">Http连接基本数据</param>
        /// <returns></returns>
        public async Task<string> HttpClientPutAsync(HttpRequestInfo httpRequestInfo)
        {
            try
            {
                var stringContent = new StringContent(JsonSerializer.Serialize(httpRequestInfo.Content), Encoding.UTF8, Application.Json);
                var httpClient = _httpClientFactory.CreateClient(httpRequestInfo.Flag);
                using var httpResponseMessage = await httpClient.PutAsync(httpRequestInfo.Route, stringContent);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                }
                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Http Client Delete
        /// </summary>
        /// <param name="content">Http连接基本数据</param>
        /// <returns></returns>
        public async Task<string> HttpClientDeleteAsync(HttpRequestInfo httpRequestInfo)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient(httpRequestInfo.Flag);
                using var httpResponseMessage = await httpClient.DeleteAsync(httpRequestInfo.Route);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                }
                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> HttpClientSendAsync(HttpRequestInfo httpRequestInfo)
        {
            try
            {
                var stringContent = new StringContent(JsonSerializer.Serialize(httpRequestInfo.Content), Encoding.UTF8, Application.Json);
                var httpClient = _httpClientFactory.CreateClient(httpRequestInfo.Flag);
                var httpRequestMessage = new HttpRequestMessage()
                {
                    Method = httpRequestInfo.MethodRequst,
                    Content = stringContent,
                    RequestUri = new Uri(httpClient.BaseAddress + httpRequestInfo.Route)
                };
                using var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return await httpResponseMessage.Content.ReadAsStringAsync();
                }
                return default;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright
{
    /// <summary>
    /// 提供网络请求相关的实用方法
    /// </summary>
    public static class NetworkUtils
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// 发送HTTP GET请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="timeout">超时时间(毫秒)</param>
        /// <returns>响应内容字符串</returns>
        /// <exception cref="HttpRequestException">当请求失败时抛出</exception>
        public static async Task<string> GetAsync(string url, int timeout = 30000)
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"GET请求失败: {url}", ex);
            }
        }

        /// <summary>
        /// 发送HTTP POST请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="data">POST数据</param>
        /// <param name="timeout">超时时间(毫秒)</param>
        /// <returns>响应内容字符串</returns>
        public static async Task<string> PostAsync(string url, string data, int timeout = 30000)
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);
                var content = new StringContent(data);
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"POST请求失败: {url}", ex);
            }
        }
    }
}

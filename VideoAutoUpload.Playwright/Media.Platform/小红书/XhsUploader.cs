
//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.Playwright;
//using System.Net.Http;
//using System.Text.Json;
//namespace VideoAutoUpload.Playwright
//{
//    /// <summary>
//    /// 小红书平台视频上传器
//    /// </summary>
//    internal class XhsUploader : BaseSocialUploader
//    {
//        private readonly string _accountFile;
//        private readonly string _signServerUrl;

//        /// <summary>
//        /// 初始化小红书上载器
//        /// </summary>
//        /// <param name="accountFile">账号Cookie文件路径</param>
//        /// <param name="signServerUrl">签名服务URL(可选)</param>
//        public XhsUploader(string accountFile, string signServerUrl = null)
//        {
//            _accountFile = FileTimeUtils.GetAbsolutePath(accountFile, "xhs_uploader");
//            _signServerUrl = signServerUrl;
//        }

//        /// <summary>
//        /// 获取签名
//        /// </summary>
//        private async Task<SignResult> GetSignAsync(string uri, string data = null)
//        {
//            if (!string.IsNullOrEmpty(_signServerUrl))
//            {
//                return await GetRemoteSignAsync(uri, data);
//            }
//            return await GetLocalSignAsync(uri, data);
//        }

//        /// <summary>
//        /// 从远程签名服务获取签名
//        /// </summary>
//        private async Task<SignResult> GetRemoteSignAsync(string uri, string data)
//        {
//            try
//            {
//                using var client = new HttpClient();
//                var content = new StringContent(JsonSerializer.Serialize(new
//                {
//                    uri,
//                    data,
//                    a1 = "",
//                    web_session = ""
//                }));

//                var response = await client.PostAsync($"{_signServerUrl}/sign", content);
//                response.EnsureSuccessStatusCode();

//                var json = await response.Content.ReadAsStringAsync();
//                return JsonSerializer.Deserialize<SignResult>(json);
//            }
//            catch (Exception ex)
//            {
//                LogUtils.Error($"远程签名失败: {ex.Message}");
//                throw;
//            }
//        }

//        /// <summary>
//        /// 本地生成签名
//        /// </summary>
//        private async Task<SignResult> GetLocalSignAsync(string uri, string data)
//        {
//            try
//            {
//                await InitializeAsync();
//                await SetupContextAsync();

//                await Page.GotoAsync("https://www.xiaohongshu.com");
//                await Page.EvaluateAsync(@"([url, data]) => {
//                // 这里需要实现小红书的签名算法
//                // 实际项目中应该替换为正确的签名逻辑
//                return {
//                    'X-s': 'local_signature',
//                    'X-t': Date.now().toString()
//                };
//            }", new[] { uri, data });

//                return new SignResult
//                {
//                    X_s = "local_signature",
//                    X_t = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString()
//                };
//            }
//            catch (Exception ex)
//            {
//                LogUtils.Error($"本地签名失败: {ex.Message}");
//                throw;
//            }
//        }

//        /// <summary>
//        /// 上传视频到小红书平台
//        /// </summary>
//        public override async Task UploadVideoAsync(string VideoPath, string title, string[] tags, DateTime? publishTime = null)
//        {
//            try
//            {
//                await InitializeAsync(false); // 非无头模式
//                await SetupContextAsync(_accountFile);

//                LogUtils.Info($"正在上传视频到小红书: {title}");
//                await Page.GotoAsync("https://creator.xiaohongshu.com/publish/publish");

//                // 这里实现具体的上传逻辑
//                // 包括文件选择、表单填写等操作

//                LogUtils.Success("视频上传完成");
//            }
//            catch (Exception ex)
//            {
//                LogUtils.Error($"视频上传失败: {ex.Message}");
//                throw;
//            }
//        }

//        public override Task LoginPlatformAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public override Task InitPlatformAsync(string browserPath)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// 签名结果
//        /// </summary>
//        private class SignResult
//        {
//            public string X_s { get; set; }
//            public string X_t { get; set; }
//        }
//    }
//}
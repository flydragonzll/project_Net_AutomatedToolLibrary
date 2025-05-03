
//using System;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.Playwright;
//using System.Collections.Generic;
//using System.Text.Json;
//namespace VideoAutoUpload.Playwright
//{
//    /// <summary>
//    /// 哔哩哔哩平台视频上传器
//    /// </summary>
//    internal class BilibiliUploader : BaseSocialUploader
//    {
//        private readonly string _cookieFile;
//        private readonly Dictionary<string, string> _cookieData;

//        /// <summary>
//        /// 初始化哔哩哔哩上传器
//        /// </summary>
//        /// <param name="cookieFile">Cookie文件路径</param>
//        public BilibiliUploader(string cookieFile)
//        {
//            _cookieFile = FileTimeUtils.GetAbsolutePath(cookieFile, "bilibili_uploader");
//            _cookieData = ExtractCookieData(_cookieFile);
//        }

//        /// <summary>
//        /// 从Cookie文件提取关键数据
//        /// </summary>
//        private Dictionary<string, string> ExtractCookieData(string filePath)
//        {
//            try
//            {
//                var json = File.ReadAllText(filePath);
//                using var doc = JsonDocument.Parse(json);
//                var root = doc.RootElement;

//                var cookieData = new Dictionary<string, string>();
//                var keysToExtract = new[] { "SESSDATA", "bili_jct", "DedeUserID__ckMd5", "DedeUserID", "access_token" };

//                // 提取Cookie信息
//                if (root.TryGetProperty("cookie_info", out var cookieInfo) &&
//                    cookieInfo.TryGetProperty("cookies", out var cookies))
//                {
//                    foreach (var cookie in cookies.EnumerateArray())
//                    {
//                        if (cookie.TryGetProperty("name", out var name) &&
//                            cookie.TryGetProperty("value", out var value))
//                        {
//                            var nameStr = name.GetString();
//                            if (Array.Exists(keysToExtract, k => k == nameStr))
//                            {
//                                cookieData[nameStr] = value.GetString();
//                            }
//                        }
//                    }
//                }

//                // 提取Token信息
//                if (root.TryGetProperty("token_info", out var tokenInfo) &&
//                    tokenInfo.TryGetProperty("access_token", out var accessToken))
//                {
//                    cookieData["access_token"] = accessToken.GetString();
//                }

//                return cookieData;
//            }
//            catch (Exception ex)
//            {
//                LogUtils.Error($"解析Cookie文件失败: {ex.Message}");
//                throw;
//            }
//        }

//        /// <summary>
//        /// 上传视频到哔哩哔哩平台
//        /// </summary>
//        public override async Task UploadVideoAsync(string VideoPath, string title, string[] tags, DateTime? publishTime = null)
//        {
//            try
//            {
//                await InitializeAsync();
//                await SetupContextAsync();

//                LogUtils.Info($"准备上传视频: {title}");
//                await Page.GotoAsync("https://member.bilibili.com/platform/upload/Video/frame");

//                // 这里需要实现具体的哔哩哔哩上传逻辑
//                // 包括文件选择、表单填写等操作
//                // 由于哔哩哔哩的上传流程较为复杂，建议使用官方API

//                LogUtils.Success("视频上传完成");
//            }
//            catch (Exception ex)
//            {
//                LogUtils.Error($"视频上传失败: {ex.Message}");
//                throw;
//            }
//        }

//        /// <summary>
//        /// 生成随机emoji
//        /// </summary>
//        private string RandomEmoji()
//        {
//            var emojis = new[] { "🍏", "🍎", "🍊", "🍋", "🍌", "🍉", "🍇", "🍓", "🍈", "🍒", "🍑", "🍍", "🥭", "🥥", "🥝",
//                  "🍅", "🍆", "🥑", "🥦", "🥒", "🥬", "🌶", "🌽", "🥕", "🥔", "🍠", "🥐", "🍞", "🥖", "🥨", "🥯", "🧀", "🥚", "🍳", "🥞",
//                  "🥓", "🥩", "🍗", "🍖", "🌭", "🍔", "🍟", "🍕", "🥪", "🥙", "🌮", "🌯", "🥗", "🥘", "🥫", "🍝", "🍜", "🍲", "🍛", "🍣",
//                  "🍱", "🥟", "🍤", "🍙", "🍚", "🍘", "🍥", "🥮", "🥠", "🍢", "🍡", "🍧", "🍨", "🍦", "🥧", "🍰", "🎂", "🍮", "🍭", "🍬",
//                  "🍫", "🍿", "🧂", "🍩", "🍪", "🌰", "🥜", "🍯", "🥛", "🍼", "☕️", "🍵", "🥤", "🍶", "🍻", "🥂", "🍷", "🥃", "🍸", "🍹",
//                  "🍾", "🥄", "🍴", "🍽", "🥣", "🥡", "🥢"};
//            return emojis[new Random().Next(emojis.Length)];
//        }

//        public override Task LoginPlatformAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public override Task InitPlatformAsync(string browserPath)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
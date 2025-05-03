
//using System;
//using System.Threading.Tasks;
//using Microsoft.Playwright;
//namespace VideoAutoUpload.Playwright
//{
//    /// <summary>
//    /// 抖音平台视频上传器
//    /// </summary>
//    internal class DouyinUploader : BaseSocialUploader
//    {
//        private readonly string _accountFile;
//        private readonly string _thumbnailPath;

//        /// <summary>
//        /// 初始化抖音上传器
//        /// </summary>
//        /// <param name="accountFile">账号Cookie文件路径</param>
//        /// <param name="thumbnailPath">封面图片路径(可选)</param>
//        public DouyinUploader(string accountFile, string thumbnailPath = null)
//        {
//            _accountFile = FileTimeUtils.GetAbsolutePath(accountFile, "douyin_uploader");
//            _thumbnailPath = thumbnailPath;
//        }

//        /// <summary>
//        /// 验证Cookie是否有效
//        /// </summary>
//        public async Task<bool> ValidateCookieAsync()
//        {
//            await InitializeAsync();
//            await SetupContextAsync(_accountFile);

//            try
//            {
//                await Page.GotoAsync("https://creator.douyin.com/creator-micro/content/upload");
//                await Page.WaitForURLAsync("https://creator.douyin.com/creator-micro/content/upload",
//                    new PageWaitForURLOptions { Timeout = 5000 });

//                // 检查登录状态
//                if (await Page.GetByText("手机号登录").CountAsync() > 0 ||
//                    await Page.GetByText("扫码登录").CountAsync() > 0)
//                {
//                    LogUtils.Info("[+] 等待5秒 cookie 失效");
//                    return false;
//                }

//                LogUtils.Info("[+] cookie 有效");
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        /// <summary>
//        /// 获取新的Cookie(通过扫码登录)
//        /// </summary>
//        public async Task GetNewCookieAsync()
//        {
//            await InitializeAsync(false); // 非无头模式
//            await SetupContextAsync();

//            LogUtils.Info("[+] cookie文件不存在或已失效，即将自动打开浏览器，请扫码登录");
//            await Page.GotoAsync("https://creator.douyin.com/");
//            await Page.PauseAsync();
//            await Context.StorageStateAsync(new BrowserContextStorageStateOptions
//            {
//                Path = _accountFile
//            });
//        }

//        /// <summary>
//        /// 上传视频到抖音平台
//        /// </summary>
//        public override async Task UploadVideoAsync(string VideoPath, string title, string[] tags, DateTime? publishTime = null)
//        {
//            try
//            {
//                await InitializeAsync(false); // 非无头模式
//                await SetupContextAsync(_accountFile);

//                LogUtils.Info($"正在上传视频: {title}");
//                await Page.GotoAsync("https://creator.douyin.com/creator-micro/content/upload");

//                // 上传视频文件
//                await Page.Locator("div[class^='container'] input").SetInputFilesAsync(VideoPath);

//                // 等待进入发布页面
//                await WaitForPublishPage();

//                // 填写标题
//                await FillTitle(title);

//                // 添加标签
//                await AddTags(tags);

//                // 上传封面
//                if (!string.IsNullOrEmpty(_thumbnailPath))
//                {
//                    await SetThumbnail(_thumbnailPath);
//                }

//                // 设置地理位置
//                await SetLocation("杭州市");

//                // 设置定时发布
//                if (publishTime.HasValue)
//                {
//                    await SetScheduleTime(publishTime.Value);
//                }

//                // 发布视频
//                await PublishVideo();

//                LogUtils.Success("视频发布成功");
//            }
//            catch (Exception ex)
//            {
//                LogUtils.Error($"视频上传失败: {ex.Message}");
//                throw;
//            }
//        }

//        private async Task WaitForPublishPage()
//        {
//            int retryCount = 0;
//            while (retryCount < 10)
//            {
//                //if (await Page.URL.Contains("publish") || await Page.URL.Contains("post/Video"))
//                //{
//                //    LogUtils.Info("成功进入发布页面");
//                //    return;
//                //}
//                await Task.Delay(500);
//                retryCount++;
//            }
//            throw new TimeoutException("进入发布页面超时");
//        }

//        private async Task FillTitle(string title)
//        {
//            LogUtils.Info("正在填充标题...");
//            var titleContainer = Page.GetByText("作品标题").Locator("..")
//                .Locator("xpath=following-sibling::div[1]").Locator("input");

//            if (await titleContainer.CountAsync() > 0)
//            {
//                await titleContainer.FillAsync(title.Substring(0, Math.Min(title.Length, 30)));
//            }
//            else
//            {
//                var titleBox = Page.Locator(".notranslate");
//                await titleBox.ClickAsync();
//                await Page.Keyboard.PressAsync("Control+A");
//                await Page.Keyboard.PressAsync("Delete");
//                await Page.Keyboard.TypeAsync(title);
//            }
//        }

//        private async Task AddTags(string[] tags)
//        {
//            LogUtils.Info($"正在添加{tags.Length}个话题...");
//            foreach (var tag in tags)
//            {
//                await Page.TypeAsync(".zone-container", "#" + tag);
//                await Page.PressAsync(".zone-container", "Space");
//                await Task.Delay(500);
//            }
//        }

//        private async Task SetThumbnail(string thumbnailPath)
//        {
//            LogUtils.Info("正在设置封面...");
//            await Page.ClickAsync("text=\"选择封面\"");
//            await Page.WaitForSelectorAsync("div.semi-modal-content:visible");
//            await Page.ClickAsync("text=\"设置竖封面\"");
//            await Task.Delay(2000);
//            await Page.Locator("div[class^='semi-upload upload'] >> input.semi-upload-hidden-input")
//                .SetInputFilesAsync(thumbnailPath);
//            await Task.Delay(2000);
//            await Page.Locator("div[class^='extractFooter'] button:visible:has-text('完成')").ClickAsync();
//        }

//        private async Task SetLocation(string location)
//        {
//            LogUtils.Info("正在设置地理位置...");
//            await Page.Locator("div.semi-select span:has-text(\"输入地理位置\")").ClickAsync();
//            await Page.Keyboard.PressAsync("Backspace");
//            await Task.Delay(2000);
//            await Page.Keyboard.TypeAsync(location);
//            await Page.WaitForSelectorAsync("div[role='listbox'] [role='option']",
//                new PageWaitForSelectorOptions { Timeout = 5000 });
//            await Page.Locator("div[role='listbox'] [role='option']").First.ClickAsync();
//        }

//        private async Task SetScheduleTime(DateTime publishTime)
//        {
//            LogUtils.Info("设置定时发布时间...");
//            await Page.Locator("[class^='radio']:has-text('定时发布')").ClickAsync();
//            await Task.Delay(1000);
//            await Page.Locator(".semi-input[placeholder=\"日期和时间\"]").ClickAsync();
//            await Page.Keyboard.PressAsync("Control+A");
//            await Page.Keyboard.TypeAsync(publishTime.ToString("yyyy-MM-dd HH:mm"));
//            await Page.Keyboard.PressAsync("Enter");
//        }

//        private async Task PublishVideo()
//        {
//            LogUtils.Info("正在发布视频...");
//            var publishButton = Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "发布", Exact = true });
//            await publishButton.ClickAsync();
//            //await Page.WaitForURLAsync(new Regex("https://creator.douyin.com/creator-micro/content/manage.*"),
//            //    new PageWaitForURLOptions { Timeout = 5000 });
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
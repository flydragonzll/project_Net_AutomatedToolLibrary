
//using System;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using Microsoft.Playwright;
//namespace VideoAutoUpload.Playwright
//{
//    /// <summary>
//    /// 百家号平台视频上传器
//    /// </summary>
//    internal class BaijiahaoUploader : BaseSocialUploader
//    {
//        private readonly string _accountFile;
//        private readonly string _proxySetting;

//        /// <summary>
//        /// 初始化百家号上传器
//        /// </summary>
//        /// <param name="accountFile">账号Cookie文件路径</param>
//        /// <param name="proxySetting">代理设置(可选)</param>
//        public BaijiahaoUploader(string accountFile, string proxySetting = null)
//        {
//            _accountFile = FileTimeUtils.GetAbsolutePath(accountFile, "baijiahao_uploader");
//            _proxySetting = proxySetting;
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
//                await Page.GotoAsync("https://baijiahao.baidu.com/builder/rc/home");
//                await Task.Delay(5000); // 等待5秒

//                if (await Page.GetByText("注册/登录百家号").CountAsync() > 0)
//                {
//                    LogUtils.Info("[+] 等待5秒 cookie 失效");
//                    return false;
//                }

//                LogUtils.Success("[+] cookie 有效");
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
//            var options = new BrowserTypeLaunchOptions
//            {
//                Headless = false,
//                Args = new[] { "--lang en-GB" },
//                Proxy = string.IsNullOrEmpty(_proxySetting) ? null : new Proxy { Server = _proxySetting }
//            };

//            //await InitializeAsync(options);
//            await SetupContextAsync();

//            LogUtils.Info("[+] cookie文件不存在或已失效，即将自动打开浏览器，请扫码登录");
//            await Page.GotoAsync("https://baijiahao.baidu.com/builder/theme/bjh/login");
//            await Page.PauseAsync();
//            await Context.StorageStateAsync(new BrowserContextStorageStateOptions
//            {
//                Path = _accountFile
//            });
//            LogUtils.Success("cookie保存成功");
//        }

//        /// <summary>
//        /// 上传视频到百家号平台
//        /// </summary>
//        public override async Task UploadVideoAsync(string VideoPath, string title, string[] tags, DateTime? publishTime = null)
//        {
//            try
//            {
//                var launchOptions = new BrowserTypeLaunchOptions
//                {
//                    Headless = false,
//                    ExecutablePath = Config.LocalChromePath,
//                    Proxy = string.IsNullOrEmpty(_proxySetting) ? null : new Proxy { Server = _proxySetting }
//                };

//                //await InitializeAsync(launchOptions);

//                var contextOptions = new BrowserNewContextOptions
//                {
//                    StorageStatePath = _accountFile,
//                    UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.4324.150 Safari/537.36"
//                };

//                //await SetupContextAsync(contextOptions);
//                await Context.GrantPermissionsAsync(new[] { "geolocation" });

//                LogUtils.Info($"正在上传视频: {title}");
//                await Page.GotoAsync("https://baijiahao.baidu.com/builder/rc/edit?type=VideoV2",
//                    new PageGotoOptions { Timeout = 60000 });

//                // 上传视频文件
//                await Page.Locator("div[class^='Video-main-container'] input").SetInputFilesAsync(VideoPath);

//                // 等待进入发布页面
//                while (true)
//                {
//                    try
//                    {
//                        await Page.WaitForSelectorAsync("div#formMain:visible");
//                        break;
//                    }
//                    catch
//                    {
//                        LogUtils.Info("正在等待进入视频发布页面...");
//                        await Task.Delay(100);
//                    }
//                }

//                // 填写标题
//                await FillTitle(title);

//                // 检查上传状态
//                var uploadStatus = await CheckUploadStatus();
//                if (!uploadStatus)
//                {
//                    LogUtils.Error($"上传失败: {VideoPath}");
//                    throw new Exception("视频上传失败");
//                }

//                // 等待封面生成
//                await WaitForThumbnail();

//                // 发布视频
//                await PublishVideo(publishTime);

//                LogUtils.Success("视频发布成功");
//            }
//            catch (Exception ex)
//            {
//                LogUtils.Error($"视频上传失败: {ex.Message}");
//                throw;
//            }
//        }

//        private async Task FillTitle(string title)
//        {
//            LogUtils.Info("正在填写标题...");
//            if (title.Length <= 8)
//            {
//                title += " 你不知道的";
//            }

//            var titleInput = Page.GetByPlaceholder("添加标题获得更多推荐");
//            await titleInput.FillAsync(title.Substring(0, Math.Min(title.Length, 30)));
//        }

//        private async Task<bool> CheckUploadStatus()
//        {
//            LogUtils.Info("检查上传状态...");
//            int retryCount = 0;
//            while (retryCount < 30) // 最多等待60秒
//            {
//                var uploadFailed = await Page.Locator("div .cover-overlay:has-text('上传失败')").CountAsync();
//                if (uploadFailed > 0)
//                {
//                    LogUtils.Error("发现上传错误");
//                    return false;
//                }

//                var uploading = await Page.Locator("div .cover-overlay:has-text('上传中')").CountAsync();
//                if (uploading == 0)
//                {
//                    LogUtils.Success("视频上传完成");
//                    return true;
//                }

//                LogUtils.Info("视频上传中...");
//                await Task.Delay(2000);
//                retryCount++;
//            }
//            return false;
//        }

//        private async Task WaitForThumbnail()
//        {
//            LogUtils.Info("等待封面生成...");
//            int retryCount = 0;
//            while (retryCount < 30) // 最多等待60秒
//            {
//                if (await Page.Locator("div.cheetah-spin-container img").CountAsync() > 0)
//                {
//                    LogUtils.Success("封面已生成");
//                    return;
//                }
//                await Task.Delay(2000);
//                retryCount++;
//            }
//            throw new TimeoutException("封面生成超时");
//        }

//        private async Task PublishVideo(DateTime? publishTime)
//        {
//            if (publishTime.HasValue && publishTime.Value != DateTime.MinValue)
//            {
//                await SetSchedulePublish(publishTime.Value);
//            }
//            else
//            {
//                await DirectPublish();
//            }

//            // 检查安全验证
//            if (await Page.Locator("div.passMod_dialog-container >> text=百度安全验证:visible").CountAsync() > 0)
//            {
//                throw new Exception("出现验证码，需要人工干预");
//            }

//            await Page.WaitForURLAsync(new Regex("https://baijiahao.baidu.com/builder/rc/clue.*"),
//                new PageWaitForURLOptions { Timeout = 5000 });
//        }

//        private async Task SetSchedulePublish(DateTime publishTime)
//        {
//            LogUtils.Info("设置定时发布时间...");
//            int retryCount = 0;
//            while (retryCount < 3)
//            {
//                try
//                {
//                    var scheduleButton = Page.Locator("div.op-btn-outter-content >> text=定时发布").Locator("..")
//                        .Locator("button");
//                    await scheduleButton.ClickAsync();
//                    await Page.WaitForSelectorAsync("div.select-wrap:visible", new PageWaitForSelectorOptions { Timeout = 3000 });
//                    await Task.Delay(2000);

//                    // 设置日期和时间
//                    await SetScheduleTime(publishTime);
//                    return;
//                }
//                catch (Exception ex)
//                {
//                    LogUtils.Error($"定时发布设置失败: {ex.Message}");
//                    retryCount++;
//                    await Task.Delay(1000);
//                }
//            }
//            throw new Exception("定时发布设置失败");
//        }

//        private async Task SetScheduleTime(DateTime publishTime)
//        {
//            // 设置日期
//            var monthStr = publishTime.Month > 9 ? $"{publishTime.Month}月" : $"0{publishTime.Month}月";
//            var dayStr = publishTime.Day > 9 ? $"{publishTime.Day}日" : $"0{publishTime.Day}日";
//            var dateStr = $"{monthStr}{dayStr}";

//            await Page.Locator("div.select-wrap").Nth(0).ClickAsync();
//            await Page.WaitForSelectorAsync("div.rc-virtual-list div.cheetah-select-item:visible");
//            await Task.Delay(2000);
//            await Page.Locator($"div.rc-virtual-list div.cheetah-select-item >> text={dateStr}").ClickAsync();
//            await Task.Delay(2000);

//            // 设置时间(随机选择)
//            await Page.Locator("div.select-wrap").Nth(1).ClickAsync();
//            await Page.WaitForSelectorAsync("div.rc-virtual-list div.rc-virtual-list-holder-inner:visible");
//            var timeOptions = await Page.Locator("div.rc-virtual-list:visible div.cheetah-select-item-option").CountAsync();
//            var randomIndex = new Random().Next(1, Math.Min(timeOptions, 6));
//            await Page.Locator($"div.rc-virtual-list:visible div.cheetah-select-item-option").Nth(randomIndex).ClickAsync();
//            await Task.Delay(2000);

//            // 确认定时发布
//            await Page.Locator("button >> text=定时发布").ClickAsync();
//        }

//        private async Task DirectPublish()
//        {
//            LogUtils.Info("立即发布视频...");
//            var publishButton = Page.Locator("button >> text=发布");
//            await publishButton.ClickAsync();
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
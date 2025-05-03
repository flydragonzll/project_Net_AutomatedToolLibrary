
using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
namespace VideoAutoUpload.Playwright
{
    /// <summary>
    /// 快手平台视频上传器
    /// </summary>
    internal class KuaishouUploader : BaseSocialUploader
    {
        private static string _cookieFile;
        
        public KuaishouUploader()
        {
        }
        #region 浏览器初始化和上下文管理
        /// <summary>
        /// 初始化快手上传器并创建浏览器实例
        /// </summary>
        /// <param name="browserPath">浏览器可执行文件路径</param>
        /// <remarks>
        /// 1. 初始化Cookie存储文件
        /// 2. 启动Playwright浏览器实例
        /// 3. 创建浏览器上下文和页面
        /// 4. 配置默认超时和重试策略
        /// </remarks>
        public override async Task InitPlatformAsync(string browserPath)
        {
            // 验证浏览器路径
            if (!File.Exists(browserPath))
            {
                throw new FileNotFoundException($"浏览器可执行文件未找到: {browserPath}");
            }
            // 初始化Cookie文件路径
            _cookieFile = FileTimeUtils.GetAbsolutePath("cookie.json", "ks_uploader");
            
            try
            {
                // 确保Cookie目录存在
                string directoryPath = Path.GetDirectoryName(_cookieFile);
                Directory.CreateDirectory(directoryPath);
                
                // 创建空Cookie文件(如果不存在)
                if (!File.Exists(_cookieFile))
                {
                    await File.WriteAllTextAsync(_cookieFile, "{}");
                    LogUtils.Info($"初始化Cookie文件: {_cookieFile}");
                }
                
                await InitializeAsync(browserPath, _cookieFile);
                
                LogUtils.Success("浏览器实例初始化完成");
            }
            catch (Exception ex)
            {
                LogUtils.Error($"浏览器初始化失败: {ex.Message}");
                throw new Exception("无法启动浏览器实例", ex);
            }
        }
        #endregion 浏览器初始化和上下文管理
        public override async Task LoginPlatformAsync()
        {
            try
            {
                // 1. 检查Cookie文件是否存在且有内容
                bool hasCookie = File.Exists(_cookieFile) && new FileInfo(_cookieFile).Length > 0;
                
                if (hasCookie)
                {
                    // 2. 使用现有Cookie尝试登录
                    LogUtils.Info("检测到Cookie文件，尝试使用现有Cookie登录...");
                    if (await ValidateCookieAsync())
                    {
                        LogUtils.Success("Cookie验证通过，登录成功");
                        return;
                    }
                    LogUtils.Warning("Cookie已过期或无效");
                }

                // 3. 需要重新登录
                LogUtils.Info(hasCookie ? "Cookie已过期，需要重新登录" : "未找到有效Cookie，需要登录");
                await GetNewCookieAsync();

                // 4. 验证新Cookie是否有效
                if (!await ValidateCookieAsync())
                {
                    throw new Exception("登录失败，无法获取有效Cookie");
                }
                LogUtils.Success("登录成功并保存新Cookie");
            }
            catch (Exception ex)
            {
                LogUtils.Error($"登录过程中出错: {ex.Message}");
                throw;
            }
        }
        #region 登录Cookie校验及本地保存
        /// <summary>
        /// 验证Cookie是否有效
        /// </summary>
        /// <remarks>
        /// 通过多种方式综合判断登录状态：
        /// 1. 检查用户头像等登录元素是否存在
        /// 2. 检查上传功能是否可用
        /// 3. 检查是否有登录提示
        /// </remarks>
        public async Task<bool> ValidateCookieAsync()
        {
            try
            {
                if (!File.Exists(_cookieFile) || new FileInfo(_cookieFile).Length == 0)
                {
                    LogUtils.Warning("Cookie文件不存在或为空");
                    return false;
                }

                // 导航到发布页面
                await Page.GotoAsync("https://cp.kuaishou.com/article/publish/Video");
                // 检查明确的登录成功元素（用户头像、上传按钮等）
                var loggedInElements = new[]
                {
                    "text='龙宝日常护理'" // 登录提示
                    //"div.user-avatar", // 用户头像
                    //"button[class^='_upload-btn_']", // 上传按钮
                    //"div.names div.container div.name:text('机构服务')" // 机构服务菜单
                };

                // 检查明确的未登录元素
                var notLoggedInElements = new[]
                {
                    "text='立即登录'"
                };

                // 等待页面稳定
                await Task.Delay(2000);

                // 检查是否有明确的登录成功元素
                bool isLoggedIn = false;
                foreach (var selector in loggedInElements)
                {
                    if (await Page.Locator(selector).CountAsync() > 0)
                    {
                        isLoggedIn = true;
                        break;
                    }
                }

                // 如果没有找到登录成功元素，再检查是否有明确的未登录元素
                if (!isLoggedIn)
                {
                    foreach (var selector in notLoggedInElements)
                    {
                        if (await Page.Locator(selector).CountAsync() > 0)
                        {
                            isLoggedIn = false;
                            LogUtils.Info($"检测到未登录状态元素: {selector}");
                            break;
                        }
                    }
                }

                LogUtils.Info($"Cookie验证结果: {(isLoggedIn ? "有效" : "无效")}");
                return isLoggedIn;
            }
            catch (Exception ex)
            {
                LogUtils.Error($"验证Cookie时出错: {ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// 获取新的Cookie(支持扫码/账号密码登录)
        /// </summary>
        public async Task GetNewCookieAsync()
        {
            try
            {
                LogUtils.Info("正在打开登录页面，请扫码或使用账号密码登录...");
                await Page.GotoAsync("https://passport.kuaishou.com/pc/account/login");

                // 如果有账号密码，自动获取账号密码并登录

                //var loginNowButton = Page.GetByText("立即登录");
                //if (await loginNowButton.CountAsync() > 0)
                //{
                //    await loginNowButton.ClickAsync();
                //}

                var scanCodeLoginButton = Page.GetByText("扫码登录");
                if (await scanCodeLoginButton.CountAsync() > 0)
                {
                    await scanCodeLoginButton.ClickAsync();
                }

                // 等待登录成功(最多5分钟)
                await Page.WaitForURLAsync(
                    url => !url.Contains("login"),
                    new PageWaitForURLOptions { Timeout = 300000 });

                await Page.GotoAsync("https://cp.kuaishou.com/article/publish/Video");

                await SaveCookieAsync(_cookieFile);
            }
            catch (Exception ex)
            {
                await SaveCookieAsync(_cookieFile);
                LogUtils.Error($"获取新Cookie时出错: {ex.Message}");
                throw;
            }
        }
        #endregion 登录Cookie校验及本地保存
        /// <summary>
        /// 上传视频到快手平台
        /// </summary>
        public override async Task UploadVideoAsync(string VideoPath, string title, string[] tags, DateTime? publishTime = null)
        {
            try
            {

                LogUtils.Info($"正在上传视频: {title}");
                // 上传视频文件
                var uploadButton = Page.Locator("button[class^='_upload-btn_1gutt_77']");
                await uploadButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

                var fileChooser = await Page.RunAndWaitForFileChooserAsync(async () =>
                {
                    await uploadButton.ClickAsync();
                });
                await fileChooser.SetFilesAsync(VideoPath);

                // 处理新手引导
                var newFeatureButton = Page.Locator("button[type='button'] span:text('我知道了')");
                if (await newFeatureButton.CountAsync() > 0)
                {
                    await newFeatureButton.ClickAsync();
                }

                // 填写标题
                await Page.GetByText("描述").Locator("xpath=following-sibling::div").ClickAsync();
                await Page.Keyboard.PressAsync("Control+A");
                await Page.Keyboard.PressAsync("Delete");
                await Page.Keyboard.TypeAsync(title);
                await Page.Keyboard.PressAsync("Enter");

                // 添加标签(最多3个)
                for (int i = 0; i < Math.Min(tags.Length, 3); i++)
                {
                    LogUtils.Info($"正在添加第{i + 1}个话题: {tags[i]}");
                    await Page.Keyboard.TypeAsync($"#{tags[i]} ");
                    await Task.Delay(2000);
                }

                // 设置定时发布
                if (publishTime.HasValue)
                {
                    await SetScheduleTime(publishTime.Value);
                }

                // 发布视频
                await PublishVideo();
            }
            catch (Exception ex)
            {
                LogUtils.Error($"视频上传失败: {ex.Message}");
                throw;
            }
        }
        private async Task SetScheduleTime(DateTime publishTime)
        {
            LogUtils.Info("设置定时发布时间");
            await Page.Locator("label:text('发布时间')")
                .Locator("xpath=following-sibling::div")
                .Locator(".ant-radio-input")
                .Nth(1)
                .ClickAsync();

            await Page.Locator("div.ant-picker-input input[placeholder='选择日期时间']").ClickAsync();
            await Page.Keyboard.PressAsync("Control+A");
            await Page.Keyboard.TypeAsync(publishTime.ToString("yyyy-MM-dd HH:mm:ss"));
            await Page.Keyboard.PressAsync("Enter");
        }

        private async Task PublishVideo()
        {
            var maxRetries = 60;
            for (int retry = 0; retry < maxRetries; retry++)
            {
                if (await Page.Locator("text=上传中").CountAsync() == 0)
                {
                    LogUtils.Success("视频上传完毕");
                    break;
                }

                if (retry % 5 == 0)
                {
                    LogUtils.Info("正在上传视频中...");
                }
                await Task.Delay(2000);
            }

            var publishButton = Page.GetByText("发布", new PageGetByTextOptions { Exact = true });
            if (await publishButton.CountAsync() > 0)
            {
                await publishButton.ClickAsync();
            }

            var confirmButton = Page.GetByText("确认发布");
            if (await confirmButton.CountAsync() > 0)
            {
                await confirmButton.ClickAsync();
            }

            await Page.WaitForURLAsync(
                "https://cp.kuaishou.com/article/manage/Video?status=2&from=publish",
                new PageWaitForURLOptions { Timeout = 5000 });

            LogUtils.Success("视频发布成功");
            //await Context.StorageStateAsync(new BrowserContextStorageStateOptions
            //{
            //    Path = _cookieFile
            //});
        }

               /// <summary>
        /// 验证Cookie是否有效
        /// </summary>
        /// <param name="validateUrl">验证URL</param>
        /// <param name="successSelector">成功选择器</param>
        /// <param name="timeout">超时时间(毫秒)</param>
        protected async Task<bool> ValidateCookieAsync(string validateUrl, string successSelector, int timeout = 5000)
        {
            try
            {
                //await Page.GotoAsync(validateUrl);
                //await Page.WaitForSelectorAsync(successSelector, new PageWaitForSelectorOptions
                //{
                //    Timeout = timeout
                //});
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
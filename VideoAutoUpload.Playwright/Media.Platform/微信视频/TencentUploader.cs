
//using System;
//using System.Threading.Tasks;
//using Microsoft.Playwright;
//using System.Text.RegularExpressions;
//namespace VideoAutoUpload.Playwright
//{
//    /// <summary>
//    /// 腾讯(微信视频号)平台视频上传器
//    /// </summary>
//    internal class TencentUploader : BaseSocialUploader
//    {
//        private readonly string _accountFile;
//        private readonly string _category;

//        /// <summary>
//        /// 初始化腾讯上传器
//        /// </summary>
//        /// <param name="accountFile">账号Cookie文件路径</param>
//        /// <param name="category">视频分类(可选)</param>
//        public TencentUploader(string accountFile, string category = null)
//        {
//            _accountFile = FileTimeUtils.GetAbsolutePath(accountFile, "tencent_uploader");
//            _category = category;
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
//                await Page.GotoAsync("https://channels.weixin.qq.com/platform/post/create");
//                await Page.WaitForSelectorAsync("div.title-name:has-text('微信小店')",
//                    new PageWaitForSelectorOptions { Timeout = 5000 });

//                LogUtils.Info("[+] 等待5秒 cookie 失效");
//                return false;
//            }
//            catch
//            {
//                LogUtils.Success("[+] cookie 有效");
//                return true;
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
//            await Page.GotoAsync("https://channels.weixin.qq.com");
//            await Page.PauseAsync();
//            await Context.StorageStateAsync(new BrowserContextStorageStateOptions
//            {
//                Path = _accountFile
//            });
//        }

//        /// <summary>
//        /// 上传视频到腾讯平台
//        /// </summary>
//        public override async Task UploadVideoAsync(string VideoPath, string title, string[] tags, DateTime? publishTime = null)
//        {
//            try
//            {
//                await InitializeAsync(false); // 非无头模式
//                await SetupContextAsync(_accountFile);

//                LogUtils.Info($"正在上传视频: {title}");
//                await Page.GotoAsync("https://channels.weixin.qq.com/platform/post/create");
//                await Page.WaitForURLAsync("https://channels.weixin.qq.com/platform/post/create");

//                // 上传视频文件
//                await Page.Locator("input[type='file']").SetInputFilesAsync(VideoPath);

//                // 填写标题和标签
//                await AddTitleAndTags(title, tags);

//                // 添加到合集
//                await AddToCollection();

//                // 声明原创
//                await DeclareOriginal();

//                // 添加短标题
//                await AddShortTitle(title);

//                // 检测上传状态
//                await CheckUploadStatus();

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

//        private async Task AddTitleAndTags(string title, string[] tags)
//        {
//            LogUtils.Info("正在填写标题和标签...");
//            await Page.Locator("div.input-editor").ClickAsync();
//            await Page.Keyboard.TypeAsync(title);
//            await Page.Keyboard.PressAsync("Enter");

//            foreach (var tag in tags)
//            {
//                await Page.Keyboard.TypeAsync("#" + tag);
//                await Page.Keyboard.PressAsync("Space");
//                await Task.Delay(200);
//            }
//            LogUtils.Info($"成功添加{tags.Length}个标签");
//        }

//        private async Task AddToCollection()
//        {
//            LogUtils.Info("正在添加到合集...");
//            var collectionElements = Page.GetByText("添加到合集").Locator("..")
//                .Locator("xpath=following-sibling::div").Locator(".option-list-wrap > div");

//            if (await collectionElements.CountAsync() > 1)
//            {
//                await Page.GetByText("添加到合集").Locator("..")
//                    .Locator("xpath=following-sibling::div").ClickAsync();
//                await collectionElements.First.ClickAsync();
//            }
//        }

//        private async Task DeclareOriginal()
//        {
//            LogUtils.Info("正在声明原创...");
//            if (await Page.GetByLabel("视频为原创").CountAsync() > 0)
//            {
//                await Page.GetByLabel("视频为原创").CheckAsync();
//            }

//            var termsLabel = Page.Locator("label:has-text('我已阅读并同意 《视频号原创声明使用条款》')");
//            if (await termsLabel.CountAsync() > 0)
//            {
//                await termsLabel.ClickAsync();
//                await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "声明原创" }).ClickAsync();
//            }

//            // 新版原创声明流程
//            if (!string.IsNullOrEmpty(_category) &&
//                await Page.Locator("div.label span:has-text('声明原创')").CountAsync() > 0)
//            {
//                var checkbox = Page.Locator("div.declare-original-checkbox input.ant-checkbox-input");
//                if (!await checkbox.IsDisabledAsync())
//                {
//                    await checkbox.ClickAsync();

//                    var dialogCheckbox = Page.Locator("div.declare-original-dialog input.ant-checkbox-input:visible");
//                    //if (await dialogCheckbox.CountAsync() > 0 &&
//                    //    !await Page.Locator("div.declare-original-dialog label.ant-checkbox-wrapper-checked:visible").CountAsync() > 0)
//                    //{
//                    //    await dialogCheckbox.ClickAsync();
//                    //}

//                    await Page.Locator("div.form-content:visible").ClickAsync();
//                    await Page.Locator($"div.form-content:visible ul.weui-desktop-dropdown__list li:has-text('{_category}')")
//                        .First.ClickAsync();
//                    await Task.Delay(1000);

//                    await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "声明原创" }).ClickAsync();
//                }
//            }
//        }

//        private async Task AddShortTitle(string title)
//        {
//            LogUtils.Info("正在添加短标题...");
//            var shortTitleElement = Page.GetByText("短标题", new PageGetByTextOptions { Exact = true })
//                .Locator("..").Locator("xpath=following-sibling::div").Locator("span input[type='text']");

//            if (await shortTitleElement.CountAsync() > 0)
//            {
//                var shortTitle = FormatShortTitle(title);
//                await shortTitleElement.FillAsync(shortTitle);
//            }
//        }

//        private string FormatShortTitle(string title)
//        {
//            // 定义允许的特殊字符
//            const string allowedChars = "《》“”:+?%°";
//            var result = new System.Text.StringBuilder();

//            foreach (var c in title)
//            {
//                if (char.IsLetterOrDigit(c) || allowedChars.Contains(c))
//                {
//                    result.Append(c);
//                }
//                else if (c == ',')
//                {
//                    result.Append(' ');
//                }
//            }

//            var formatted = result.ToString();
//            return formatted.Length > 16 ? formatted.Substring(0, 16) : formatted;
//        }

//        private async Task CheckUploadStatus()
//        {
//            LogUtils.Info("检查上传状态...");
//            while (true)
//            {
//                var publishButton = Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "发表" });
//                var isDisabled = await publishButton.GetAttributeAsync("class") is string attr &&
//                                attr.Contains("weui-desktop-btn_disabled");

//                if (!isDisabled)
//                {
//                    LogUtils.Info("视频上传完成");
//                    break;
//                }

//                // 检查上传错误
//                if (await Page.Locator("div.status-msg.error").CountAsync() > 0 &&
//                    await Page.Locator("div.media-status-content div.tag-inner:has-text('删除')").CountAsync() > 0)
//                {
//                    LogUtils.Error("发现上传错误，准备重试...");
//                    await HandleUploadError();
//                }

//                await Task.Delay(2000);
//                LogUtils.Info("视频上传中...");
//            }
//        }

//        private async Task HandleUploadError()
//        {
//            await Page.Locator("div.media-status-content div.tag-inner:has-text('删除')").ClickAsync();
//            await Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "删除", Exact = true }).ClickAsync();
//            await Page.Locator("input[type='file']").SetInputFilesAsync(_accountFile);
//        }

//        private async Task SetScheduleTime(DateTime publishTime)
//        {
//            LogUtils.Info("设置定时发布时间...");
//            await Page.Locator("label").Filter(new LocatorFilterOptions { HasText = "定时" }).Nth(1).ClickAsync();
//            await Page.ClickAsync("input[placeholder='请选择发表时间']");

//            var monthStr = publishTime.Month > 9 ? $"{publishTime.Month}月" : $"0{publishTime.Month}月";
//            var pageMonth = await Page.InnerTextAsync("span.weui-desktop-picker__panel__label:has-text('月')");

//            if (pageMonth != monthStr)
//            {
//                await Page.ClickAsync("button.weui-desktop-btn__icon__right");
//            }

//            var dayElements = await Page.QuerySelectorAllAsync("table.weui-desktop-picker__table a");
//            foreach (var element in dayElements)
//            {
//                if (await element.GetAttributeAsync("class") is string cls && cls.Contains("weui-desktop-picker__disabled"))
//                    continue;

//                var text = await element.InnerTextAsync();
//                if (text.Trim() == publishTime.Day.ToString())
//                {
//                    await element.ClickAsync();
//                    break;
//                }
//            }

//            await Page.ClickAsync("input[placeholder='请选择时间']");
//            await Page.Keyboard.PressAsync("Control+A");
//            await Page.Keyboard.TypeAsync(publishTime.Hour.ToString());
//            await Page.Locator("div.input-editor").ClickAsync(); // 使时间选择生效
//        }

//        private async Task PublishVideo()
//        {
//            LogUtils.Info("正在发布视频...");
//            var publishButton = Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "发表" });
//            await publishButton.ClickAsync();

//            while (true)
//            {
//                try
//                {
//                    await Page.WaitForURLAsync(new Regex("https://channels.weixin.qq.com/platform/post/list"),
//                        new PageWaitForURLOptions { Timeout = 1500 });
//                    break;
//                }
//                catch
//                {
//                    if (Page.Url.Contains("platform/post/list"))
//                        break;

//                    LogUtils.Info("视频发布中...");
//                    await Task.Delay(500);
//                }
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
//    }
//}
//// 引入必要的命名空间
//using Microsoft.Playwright; // Playwright 浏览器自动化框架
//using System;              // 核心功能（如 Task, Exception 等）
//using System.Collections.Generic; // 集合类支持（List、Dictionary等）
//using System.IO;           // 文件操作相关（如 File.ReadAllTextAsync）
//using System.Text.Json;    // JSON 序列化与反序列化
//using System.Threading.Tasks; // 支持异步编程
//using VideoAutoUpload.Playwright.Models; // 自定义模型类（Config、Step 等）

//namespace VideoAutoUpload.Playwright
//{

//    /// <summary>
//    /// 多平台自动化任务执行器，支持根据配置文件对多个平台进行自动化操作（如登录、上传视频等）
//    /// </summary>
//    public class MultiPlatformAutomationExecutor
//    {
//        /// <summary>
//        /// 根据指定的 JSON 配置文件路径执行多平台自动化任务
//        /// </summary>
//        /// <param name="jsonFilePath">JSON 配置文件路径</param>
//        public async Task ExecuteSteps(string jsonFilePath)
//        {
//            // 读取配置文件内容为字符串
//            string json = await File.ReadAllTextAsync(jsonFilePath);

//            // 将 JSON 字符串反序列化为 Config 对象（包含多个平台信息）
//            var config = JsonSerializer.Deserialize<PlatformsConfig>(json);

//            // 遍历每个平台节点（如 Kuaishou、AnotherPlatform 等）
//            foreach (var platform in config.Platforms)
//            {
//                // 获取当前平台名称（用于初始化对应的上传器）
//                string platformName = platform.Name;

//                // 遍历该平台下的所有账号配置
//                foreach (var account in platform.Accounts)
//                {
//                    // 获取 Cookie 文件路径（用于登录状态保持）
//                    string cookieFile = account.CookieFile;

//                    // 获取当前账号的任务步骤列表（goto、click、input 等操作）
//                    var steps = account.Steps;

//                    // 获取错误处理策略（重试次数、延迟、出错处理方式等）
//                    var errorHandling = account.ErrorHandling;

//                    // 获取日志记录配置（日志级别、输出文件等）
//                    var logging = account.Logging;

//                    // 获取调度策略（开始时间、频率等）
//                    var scheduling = account.Scheduling;

//                    // 判断当前时间是否满足调度条件（如定时执行）
//                    if (!ShouldExecuteTask(scheduling.StartTime, scheduling.Frequency))
//                    {
//                        // 不满足执行条件，跳过当前账号
//                        continue;
//                    }

//                    // 获取对应平台的上传器实例（如 KuaishouUploader）
//                    var uploader = GetUploader(platformName);

//                    // 初始化浏览器平台（启动浏览器、加载 Cookie、设置默认行为等）
//                    await uploader.InitPlatformAsync("path/to/browser.exe");

//                    // 执行登录流程（使用 Cookie 或扫码/密码登录）
//                    await uploader.LoginPlatformAsync();

//                    // 获取当前浏览器页面对象（用于后续操作）
//                    //var page = uploader.Page;
//                    IPage page = null;
//                    // 遍历该账号下要上传的所有视频
//                    foreach (var video in account.Videos)
//                    {
//                        // 获取视频文件路径
//                        string videoPath = video.VideoPath;

//                        // 获取视频标题
//                        string title = video.Title;

//                        // 获取视频标签并转换为数组形式
//                        var tags = video.Tags.ToArray();

//                        // 获取可选的定时发布时间
//                        DateTime? publishTime = video.PublishTime;

//                        // 当前重试次数计数器
//                        int currentRetry = 0;

//                        // 标记是否成功完成上传
//                        bool success = false;

//                        // 开始执行上传任务，并根据错误处理策略进行重试
//                        while (currentRetry <= errorHandling.RetryCount && !success)
//                        {
//                            try
//                            {
//                                // 遍历并执行每一步操作（如 goto、click、input、upload_file 等）
//                                foreach (var step in steps)
//                                {
//                                    // 替换步骤中的占位符变量（如 {videoPath}, {title}）
//                                    string processedStep = ReplacePlaceholders(step, videoPath, title);

//                                    // 将替换后的步骤字符串反序列化为 Step 对象
//                                    var processedStepObj = JsonSerializer.Deserialize<Step>(processedStep);

//                                    // 根据步骤类型执行对应操作
//                                    switch (processedStepObj.Type)
//                                    {
//                                        case "goto":
//                                            // 跳转到指定 URL，支持自定义等待时机（load / domcontentloaded 等）
//                                            string url = processedStepObj.Url;
//                                            string waitUntil = processedStepObj.WaitUntil ?? "load";
//                                            //await page.GotoAsync(url, new PageGotoOptions { WaitUntil = waitUntil });
//                                            break;
//                                        case "wait":
//                                            // 等待某个选择器出现，或等待指定毫秒数
//                                            if (processedStepObj.Condition == "selector")
//                                            {
//                                                string selector = processedStepObj.Selector;
//                                                await page.WaitForSelectorAsync(selector);
//                                            }
//                                            else
//                                            {
//                                                int waitTime = processedStepObj.WaitTime.Value;
//                                                await Task.Delay(waitTime);
//                                            }
//                                            break;
//                                        case "click":
//                                            // 点击指定选择器元素，支持多次点击（ClickCount）
//                                            string clickSelector = processedStepObj.Selector;
//                                            int clickCount = processedStepObj.ClickCount ?? 1;
//                                            var clickLocator = page.Locator(clickSelector);
//                                            await clickLocator.ClickAsync(new LocatorClickOptions { ClickCount = clickCount });
//                                            break;
//                                        case "input":
//                                            // 在指定输入框中填写内容，支持清空原有内容
//                                            string inputSelector = processedStepObj.Selector;
//                                            string value = processedStepObj.Value;
//                                            bool clearBefore = processedStepObj.ClearBefore ?? true;
//                                            var inputLocator = page.Locator(inputSelector);
//                                            if (clearBefore)
//                                            {
//                                                await inputLocator.ClearAsync();
//                                            }
//                                            await inputLocator.FillAsync(value);
//                                            break;
//                                        case "upload_file":
//                                            // 上传文件到指定的文件输入框
//                                            string uploadSelector = processedStepObj.Selector;
//                                            string filePath = processedStepObj.FilePath;
//                                            var fileInput = page.Locator(uploadSelector);
//                                            await fileInput.SetInputFilesAsync(filePath);
//                                            break;
//                                        case "select_option":
//                                            // 选择下拉框选项
//                                            string selectSelector = processedStepObj.Selector;
//                                            string optionValue = processedStepObj.Value;
//                                            var selectLocator = page.Locator(selectSelector);
//                                            await selectLocator.SelectOptionAsync(optionValue);
//                                            break;
//                                        case "check":
//                                            // 勾选复选框
//                                            string checkSelector = processedStepObj.Selector;
//                                            var checkLocator = page.Locator(checkSelector);
//                                            await checkLocator.CheckAsync();
//                                            break;
//                                        case "uncheck":
//                                            // 取消勾选复选框
//                                            string uncheckSelector = processedStepObj.Selector;
//                                            var uncheckLocator = page.Locator(uncheckSelector);
//                                            await uncheckLocator.UncheckAsync();
//                                            break;
//                                        case "hover":
//                                            // 鼠标悬停
//                                            string hoverSelector = processedStepObj.Selector;
//                                            var hoverLocator = page.Locator(hoverSelector);
//                                            await hoverLocator.HoverAsync();
//                                            break;
//                                        //case "scroll":
//                                        //    // 滚动页面
//                                        //    int? x = processedStepObj.X;
//                                        //    int? y = processedStepObj.Y;
//                                        //    await page.EvaluateAsync($"window.scrollTo({x ?? 0}, {y ?? 0})");
//                                        //    break;
//                                        case "double_click":
//                                            string doubleClickSelector = processedStepObj.Selector;
//                                            var doubleClickLocator = page.Locator(doubleClickSelector);
//                                            await doubleClickLocator.DblClickAsync();
//                                            break;
//                                        case "right_click":
//                                            string rightClickSelector = processedStepObj.Selector;
//                                            var rightClickLocator = page.Locator(rightClickSelector);
//                                            await rightClickLocator.ClickAsync(new LocatorClickOptions { Button = MouseButton.Right });
//                                            break;
//                                        //case "drag_drop":
//                                        //    string fromSelector = processedStepObj.FromSelector;
//                                        //    string toSelector = processedStepObj.ToSelector;
//                                        //    var fromLocator = page.Locator(fromSelector);
//                                        //    var toLocator = page.Locator(toSelector);
//                                        //    await fromLocator.DragToAsync(toLocator);
//                                        //    break;
//                                        //case "key_press":
//                                        //    string key = processedStepObj.Key;
//                                        //    await page.Keyboard.PressAsync(key);
//                                        //    break;
//                                        case "refresh":
//                                            await page.ReloadAsync();
//                                            break;
//                                        case "close_tab":
//                                            await page.CloseAsync();
//                                            break;
//                                        //case "switch_tab":
//                                        //    int tabIndex = processedStepObj.TabIndex;
//                                        //    var allPages = page.Context.Pages;
//                                        //    if (tabIndex < allPages.Count)
//                                        //    {
//                                        //        page = allPages[tabIndex];
//                                        //    }
//                                        //    break;
//                                        //case "assert_text":
//                                        //    string assertSelector = processedStepObj.Selector;
//                                        //    string expectedText = processedStepObj.ExpectedText;
//                                        //    var assertLocator = page.Locator(assertSelector);
//                                        //    string actualText = await assertLocator.TextContentAsync();
//                                        //    if (actualText != expectedText)
//                                        //    {
//                                        //        throw new Exception($"Text assertion failed. Expected: {expectedText}, Actual: {actualText}");
//                                        //    }
//                                        //    break;
//                                        //case "assert_attribute":
//                                        //    string attributeSelector = processedStepObj.Selector;
//                                        //    string attributeName = processedStepObj.AttributeName;
//                                        //    string expectedAttributeValue = processedStepObj.ExpectedValue;
//                                        //    var attributeLocator = page.Locator(attributeSelector);
//                                        //    string actualAttributeValue = await attributeLocator.GetAttributeAsync(attributeName);
//                                        //    if (actualAttributeValue != expectedAttributeValue)
//                                        //    {
//                                        //        throw new Exception($"Attribute assertion failed. Expected: {expectedAttributeValue}, Actual: {actualAttributeValue}");
//                                        //    }
//                                        //    break;
//                                        default:
//                                            // 不支持的步骤类型，抛出异常
//                                            throw new Exception($"Unknown step type: {processedStepObj.Type}");
//                                    }
//                                }

//                                // 执行实际的视频上传操作（包括标题、标签、定时发布等）
//                                await uploader.UploadVideoAsync(videoPath, title, tags, publishTime);

//                                // 标记上传成功
//                                success = true;
//                            }
//                            catch (Exception ex)
//                            {
//                                // 捕获异常并处理
//                                currentRetry++;
//                                if (currentRetry <= errorHandling.RetryCount)
//                                {
//                                    // 未达到最大重试次数，等待后继续尝试
//                                    LogError(logging.Level, logging.File, $"视频上传失败，正在重试第 {currentRetry} 次: {ex.Message}");
//                                    await Task.Delay(errorHandling.RetryDelay);
//                                }
//                                else
//                                {
//                                    // 已达到最大重试次数，根据策略处理错误
//                                    if (errorHandling.OnError == "skip")
//                                    {
//                                        // 跳过当前任务
//                                        LogError(logging.Level, logging.File, $"视频上传失败，跳过此任务: {ex.Message}");
//                                        break;
//                                    }
//                                    else if (errorHandling.OnError == "abort")
//                                    {
//                                        // 终止整个任务并抛出异常
//                                        LogError(logging.Level, logging.File, $"视频上传失败，终止任务: {ex.Message}");
//                                        throw;
//                                    }
//                                }
//                            }
//                        }
//                    }

//                    // 释放上传器资源（关闭浏览器上下文等）
//                    uploader.Dispose();
//                }
//            }
//        }

//        /// <summary>
//        /// 替换步骤中的占位符变量（如 {videoPath}, {title}）
//        /// </summary>
//        private string ReplacePlaceholders(Step step, string videoPath, string title)
//        {
//            string stepJson = JsonSerializer.Serialize(step);
//            stepJson = stepJson.Replace("{videoPath}", videoPath);
//            stepJson = stepJson.Replace("{title}", title);
//            return stepJson;
//        }

//        /// <summary>
//        /// 判断当前任务是否应该被执行（基于开始时间和频率）
//        /// </summary>
//        private bool ShouldExecuteTask(DateTime startTime, string frequency)
//        {
//            // 实现任务调度逻辑
//            return true;
//        }

//        /// <summary>
//        /// 获取对应平台的上传器实例
//        /// </summary>
//        private BaseSocialUploader GetUploader(string platformName)
//        {
//            switch (platformName)
//            {
//                case "Kuaishou":
//                    return new KuaishouUploader();
//                case "AnotherPlatform":
//                    // 实现另一个平台的上传器
//                    return null;
//                default:
//                    throw new Exception($"不支持的平台: {platformName}");
//            }
//        }

//        /// <summary>
//        /// 记录错误日志
//        /// </summary>
//        private void LogError(string logLevel, string logFile, string message)
//        {
//            // 实现日志记录逻辑
//            Console.WriteLine(message);
//        }
//    }
//}
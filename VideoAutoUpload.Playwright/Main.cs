using Microsoft.Playwright;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright
{
    /// <summary>
    /// 社交媒体自动上传程序主入口
    /// </summary>
    public class Main
    {

        private async Task demo(List<string> platformList, string browserPath, string videoPath, string title, string tags, bool headless = false)
        {
            IPlaywright Playwright;
            IBrowser Browser;
            IBrowserContext Context;
            IPage Page;
            
            // 验证浏览器路径
            if (!File.Exists(browserPath))
            {
                throw new FileNotFoundException($"浏览器可执行文件不存在: {browserPath}");
            }

            try
            {
                LogUtils.Info("正在初始化Playwright...");
                Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
                
                // 浏览器启动配置
                var launchOptions = new BrowserTypeLaunchOptions
                {
                    ExecutablePath = browserPath,
                    Headless = headless,
                    Timeout = 6000, // 6秒启动超时
                    Args = new[] { "--start-maximized" } // 默认最大化窗口
                };
                
                LogUtils.Info($"正在启动Chromium浏览器(无头模式: {headless})...");
                Browser = await Playwright.Chromium.LaunchAsync(launchOptions);
                LogUtils.Success($"浏览器已成功启动，版本: {Browser.Version}");
            }
            catch (Exception ex)
            {
                LogUtils.Error($"浏览器启动失败: {ex.Message}");
                throw new Exception($"VideoAutoUpload.Playwright-BaseSocialUploader-InitializeAsync: {ex.Message}");
            }

            try
            {
                // 配置上下文选项
                var contextOptions = new BrowserNewContextOptions
                {
                    ViewportSize = ViewportSize.NoViewport, // 禁用固定视口
                    IgnoreHTTPSErrors = true, // 忽略HTTPS错误
                    AcceptDownloads = true // 允许文件下载
                };

                // 创建新上下文
                Context = await Browser.NewContextAsync(contextOptions);
                
                // 加载stealth脚本
                var stealthPath = "utils/stealth.min.js";
                if (!File.Exists(stealthPath))
                {
                    LogUtils.Warning($"防检测脚本不存在: {stealthPath}, 将跳过加载");
                }
                else
                {
                    LogUtils.Info("正在加载防检测脚本...");
                    try
                    {
                        await Context.AddInitScriptAsync(await File.ReadAllTextAsync(stealthPath));
                        LogUtils.Success("防检测脚本加载完成");
                    }
                    catch (Exception ex)
                    {
                        LogUtils.Error($"防检测脚本加载失败: {ex.Message}");
                        throw new Exception($"VideoAutoUpload.Playwright-BaseSocialUploader-SetupContextAsync: 防检测脚本加载失败 - {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtils.Error($"上下文设置失败: {ex.Message}");
                throw new Exception($"VideoAutoUpload.Playwright-BaseSocialUploader-SetupContextAsync: {ex.Message}");
            }

            try
            {
                Page = await Context.NewPageAsync();
                // 配置默认超时
                Page.SetDefaultTimeout(3000); // 3秒操作超时
                Page.SetDefaultNavigationTimeout(6000); // 6秒页面加载超时
                // 配置页面行为
                await Page.SetExtraHTTPHeadersAsync(new Dictionary<string, string>
                {
                    ["Accept-Language"] = "zh-CN,zh;q=0.9" // 设置中文语言偏好
                });
            }
            catch (Exception ex)
            {
                throw new Exception("无法启动浏览器实例", ex);
            }
        }

        /// <summary>
        /// 程序主入口
        /// </summary>
        /// <param name="platformList">上传平台名称(如: KuaishouUploader)</param>
        /// <param name="browserPath">浏览器可执行文件路径</param>
        /// <param name="videoPath">要上传的视频文件路径</param>
        /// <param name="title">视频标题</param>
        /// <param name="tags">视频标签(多个标签用逗号分隔)</param>
        /// <returns>表示异步操作的任务</returns>
        public async Task Run(List<string> platformList, string browserPath, string videoPath, string title, string tags, bool headless = false)
        {
            //await demo(platformList, browserPath, videoPath, title, tags, headless);
            try
            {
                if (!platformList.Any())
                {
                    ShowHelp();
                    return;
                }
                // 三步骤 1、初始化   2、登录   3、上传
                List<BaseSocialUploader> baseSocialUploaderList = new List<BaseSocialUploader>();
                foreach (var platform in platformList)
                { 
                    var uploader = await CreateUploader(platform, browserPath);

                    if (uploader == null)
                    {
                        LogUtils.Error($"不支持的平台: {platform}");
                        return;
                    }
                    baseSocialUploaderList.Add(uploader);
                }
                foreach (var baseSocialUploader in baseSocialUploaderList)
                {
                    await LoginPlatform(baseSocialUploader);
                }
                foreach (var baseSocialUploader in baseSocialUploaderList)
                {
                    var tagArray = string.IsNullOrEmpty(tags) ? new[] { "测试", "示例" } : tags.Split('|');
                    await UploadVideo(baseSocialUploader, videoPath, title, tagArray);
                }
            }
            catch (Exception ex)
            {
                LogUtils.Error($"程序运行出错: {ex.Message}");
            }
        }

        /// <summary>
        /// 创建指定平台的上传器实例
        /// </summary>
        private static async Task<BaseSocialUploader> CreateUploader(string platform,string browserPath)
        {
            switch (platform)
            {
                case "KuaishouUploader":
                    var kuaishouUploader = new KuaishouUploader();
                    await  kuaishouUploader.InitPlatformAsync(browserPath);
                    return kuaishouUploader;
                // 其他平台上传器...
                default:
                    return null;
            }
        }
        /// <summary>
         /// 执行平台登录流程
         /// </summary>
        private static async Task LoginPlatform(BaseSocialUploader uploader)
        {

            try
            {
                await uploader.LoginPlatformAsync();
                LogUtils.Success("平台登录完成");
            }
            catch (Exception ex)
            {
                LogUtils.Error($"平台登录失败: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// 执行视频上传流程
        /// </summary>
        private static async Task UploadVideo(BaseSocialUploader uploader, string VideoPath, string title, string[] tags)
        {
            LogUtils.Info($"开始上传视频到 {uploader.GetType().Name}");
            LogUtils.Info($"视频路径: {VideoPath}");
            LogUtils.Info($"视频标题: {title}");
            LogUtils.Info($"视频标签: {string.Join(", ", tags)}");

            try
            {
                await uploader.UploadVideoAsync(VideoPath, title, tags);
                LogUtils.Success("视频上传完成");
            }
            catch (Exception ex)
            {
                LogUtils.Error($"视频上传失败: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// 显示帮助信息
        /// </summary>
        private static void ShowHelp()
        {
            Console.WriteLine("社交媒体自动上传工具");
            Console.WriteLine("用法: SocialAutoUpload [平台] [视频路径] [标题] [标签]");
            Console.WriteLine();
            Console.WriteLine("参数:");
            Console.WriteLine("  平台       支持的平台: kuaishou(ks)");
            Console.WriteLine("  视频路径   要上传的视频文件路径(默认: Videos/demo.mp4)");
            Console.WriteLine("  标题       视频标题(默认: 测试视频)");
            Console.WriteLine("  标签       逗号分隔的视频标签(默认: 测试,示例)");
            Console.WriteLine();
            Console.WriteLine("示例:");
            Console.WriteLine("  SocialAutoUpload ks myVideo.mp4 \"我的视频\" \"科技,教程\"");
        }
    }
}

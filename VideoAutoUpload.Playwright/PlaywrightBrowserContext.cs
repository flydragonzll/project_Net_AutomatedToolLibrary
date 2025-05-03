using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright
{
    public class PlaywrightBrowserContext
    {
        #region 属性
        /// <summary>
        /// Playwright实例，用于浏览器自动化控制
        /// </summary>
        private static IPlaywright Playwright;

        /// <summary>
        /// 浏览器实例，表示一个浏览器进程
        /// </summary>
        private static IBrowser Browser;

        /// <summary>
        /// 浏览器上下文，包含独立的cookie和缓存
        /// </summary>
        private static IBrowserContext Context;
        #endregion
        #region 基础方法
        /// <summary>
        /// 初始化浏览器实例
        /// </summary>
        /// <param name="browserPath">浏览器可执行文件路径</param>
        /// <param name="_cookieFile">cookie存储文件路径</param>
        /// <param name="headless">是否使用无头模式</param>
        /// <returns>初始化完成的页面实例</returns>
        public static async Task<IPage> InitializeAsync(string browserPath, string _cookieFile, bool headless = false)
        {
            // 验证浏览器路径有效性
            //if (!File.Exists(browserPath))
            //{
            //    throw new FileNotFoundException($"浏览器可执行文件不存在: {browserPath}");
            //}

            IPage Page = null;
            try
            {
                if (null == Playwright)
                {
                    LogUtils.Info("正在初始化Playwright...");
                    Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
                }
                if (null == Browser)
                {
                    // 配置浏览器启动选项
                    var launchOptions = new BrowserTypeLaunchOptions
                    {
                        /// <summary>
                        /// 浏览器可执行文件路径
                        /// 必须指定有效的浏览器安装路径
                        /// </summary>
                        ExecutablePath = browserPath,

                        /// <summary>
                        /// 是否使用无头模式
                        /// true: 不显示浏览器界面
                        /// false: 显示浏览器界面(默认)
                        /// </summary>
                        Headless = headless,

                        /// <summary>
                        /// 浏览器启动超时时间(毫秒)
                        /// 默认6000毫秒(6秒)
                        /// 超时后将抛出异常
                        /// </summary>
                        Timeout = 6000,

                        /// <summary>
                        /// 浏览器启动参数
                        /// 这里设置为启动时最大化窗口
                        /// 可添加其他Chromium支持的命令行参数
                        /// </summary>
                        Args = new[] { "--start-maximized" }
                    };

                    LogUtils.Info($"正在启动Chromium浏览器(无头模式: {headless})...");
                    Browser = await Playwright.Chromium.LaunchAsync(launchOptions);
                    LogUtils.Success($"浏览器已成功启动，版本: {Browser.Version}");
                }
                if (null == Context)
                {
                    // 配置浏览器上下文选项
                    var contextOptions = new BrowserNewContextOptions
                    {
                        /// <summary>
                        /// 视口设置
                        /// 设置为NoViewport表示不固定视口大小
                        /// 允许页面自由调整尺寸
                        /// </summary>
                        ViewportSize = ViewportSize.NoViewport,

                        /// <summary>
                        /// Cookie持久化文件路径
                        /// 暂未启用，启用后可保存登录状态
                        /// </summary>
                        //StorageStatePath = _cookieFile,

                        /// <summary>
                        /// 是否忽略HTTPS错误
                        /// true: 忽略证书错误
                        /// false: 严格检查HTTPS证书(默认)
                        /// </summary>
                        IgnoreHTTPSErrors = true,

                        /// <summary>
                        /// 是否允许文件下载
                        /// true: 允许浏览器下载文件
                        /// false: 禁止下载(默认)
                        /// </summary>
                        AcceptDownloads = true
                    };

                    // 创建新上下文
                    Context = await Browser.NewContextAsync(contextOptions);

                    // 加载防检测脚本
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
                // 创建新页面并配置默认参数
                Page = await Context.NewPageAsync();

                /// <summary>
                /// 设置页面操作默认超时(毫秒)
                /// 影响所有元素查找和操作
                /// 默认3000毫秒(3秒)
                /// </summary>
                Page.SetDefaultTimeout(3000);

                /// <summary>
                /// 设置页面导航默认超时(毫秒)
                /// 影响页面跳转和加载
                /// 默认6000毫秒(6秒)
                /// </summary>
                Page.SetDefaultNavigationTimeout(6000);

                // 配置页面行为
                await Page.SetExtraHTTPHeadersAsync(new Dictionary<string, string>
                {
                    /// <summary>
                    /// 设置Accept-Language请求头
                    /// 优先使用简体中文(zh-CN)
                    /// 其次使用中文(zh)
                    /// 最后使用英文(en)
                    /// </summary>
                    ["Accept-Language"] = "zh-CN,zh;q=0.9"
                });
            }
            catch (Exception ex)
            {
                LogUtils.Error($"上下文设置失败: {ex.Message}");
                throw new Exception($"VideoAutoUpload.Playwright-BaseSocialUploader-SetupContextAsync: {ex.Message}");
            }
            finally
            {
                if (Page == null)
                {
                    LogUtils.Error("浏览器初始化失败");
                }
            }
            return Page;
        }
        public static async Task SaveCookieAsync(string _cookieFile)
        {
            // 保存新Cookie
            await Context.StorageStateAsync(new BrowserContextStorageStateOptions
            {
                Path = _cookieFile
            });
            LogUtils.Info("成功获取并保存新Cookie");
        }
        #endregion

    }
}

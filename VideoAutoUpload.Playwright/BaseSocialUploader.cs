using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright
{
    /// <summary>
    /// 社交媒体视频上传器的抽象基类
    /// 提供浏览器自动化上传视频的基础功能
    /// </summary>
    internal abstract class BaseSocialUploader : IDisposable
    {
        #region 属性
        /// <summary>
        /// 页面实例
        /// </summary>
        protected IPage Page { get; private set; }
        #endregion
        #region 抽象方法
        /// <summary>
        /// 初始化特定平台的上传器
        /// </summary>
        /// <param name="browserPath">浏览器可执行文件路径</param>
        public abstract Task InitPlatformAsync(string browserPath);

        /// <summary>
        /// 执行平台登录流程
        /// </summary>
        public abstract Task LoginPlatformAsync();

        /// <summary>
        /// 上传视频到平台
        /// </summary>
        /// <param name="VideoPath">视频文件路径</param>
        /// <param name="title">视频标题</param>
        /// <param name="tags">视频标签数组</param>
        /// <param name="publishTime">计划发布时间(可选，null表示立即发布)</param>
        public abstract Task UploadVideoAsync(string VideoPath, string title, string[] tags, DateTime? publishTime = null);
        #endregion
        #region 基础方法
        /// <summary>
        /// 初始化浏览器实例
        /// </summary>
        /// <param name="browserPath">浏览器可执行文件路径</param>
        /// <param name="_cookieFile">cookie存储文件路径</param>
        /// <param name="headless">是否使用无头模式</param>
        /// <returns>初始化完成的页面实例</returns>
        protected async Task InitializeAsync(string browserPath, string _cookieFile, bool headless = false)
        {
            Page = await PlaywrightBrowserContext.InitializeAsync(browserPath, _cookieFile, headless);
        }
        protected async Task SaveCookieAsync(string _cookieFile)
        {
            await PlaywrightBrowserContext.SaveCookieAsync(_cookieFile);
        }
        #endregion
        #region 资源释放
        /// <summary>
        /// 释放所有托管资源
        /// </summary>
        public virtual void Dispose()
        {
            // 按顺序释放资源：页面 -> 上下文 -> 浏览器 -> Playwright
            //Page?.CloseAsync().GetAwaiter().GetResult();
            //Context?.CloseAsync().GetAwaiter().GetResult();
            //Browser?.CloseAsync().GetAwaiter().GetResult();
            //Playwright?.Dispose();
        }
        #endregion
    }
}
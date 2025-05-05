using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 页面跳转方法类
    /// </summary>
    [Description("页面跳转方法配置")]
    public class _PageMethod_GotoAsync
    {
        [Description("目标URL地址")]
        [JsonPropertyName("_url")]
        public string _url { get; set; }

        [Description("页面跳转选项配置")]
        [JsonPropertyName("_pageGotoOptions")]
        public _PageMethod_GotoAsync_PageGotoOptions? _pageGotoOptions { get; set; } = new _PageMethod_GotoAsync_PageGotoOptions();

        [Description("返回的响应对象")]
        [JsonPropertyName("_ret_IResponse")]
        public IResponse _ret_IResponse { get; set; }
    }
    /// <summary>
    /// 页面跳转选项配置类
    /// </summary>
    [Description("页面跳转选项配置")]
    public class _PageMethod_GotoAsync_PageGotoOptions
    {
        /// <summary>
        /// <para>
        /// Referer头信息值。如果提供，将优先于通过<see cref="IPage.SetExtraHTTPHeadersAsync"/>设置的referer头信息值。
        /// </para>
        /// </summary>
        [Description("Referer头信息")]
        [JsonPropertyName("referer")]
        public string? Referer { get; set; }

        /// <summary>
        /// <para>
        /// 最大操作时间(毫秒)，默认为30秒，设置为<c>0</c>表示禁用超时。
        /// 默认值可以通过<see cref="IBrowserContext.SetDefaultNavigationTimeout"/>、
        /// <see cref="IBrowserContext.SetDefaultTimeout"/>、
        /// <see cref="IPage.SetDefaultNavigationTimeout"/>或
        /// <see cref="IPage.SetDefaultTimeout"/>方法修改。
        /// </para>
        /// </summary>
        [Description("超时时间(毫秒)")]
        [JsonPropertyName("timeout")]
        public float? Timeout { get; set; }

        /// <summary>
        /// <para>操作成功完成的判定条件，默认为<c>load</c>。可选值包括:</para>
        /// <list type="bullet">
        /// <item><description>
        /// <c>'domcontentloaded'</c> - 当<c>DOMContentLoaded</c>事件触发时认为操作完成
        /// </description></item>
        /// <item><description>
        /// <c>'load'</c> - 当<c>load</c>事件触发时认为操作完成
        /// </description></item>
        /// <item><description>
        /// <c>'networkidle'</c> - **不推荐** 当至少500毫秒没有网络连接时认为操作完成。不推荐用于测试，应使用web断言来评估准备状态
        /// </description></item>
        /// <item><description>
        /// <c>'commit'</c> - 当收到网络响应且文档开始加载时认为操作完成
        /// </description></item>
        /// </list>
        /// </summary>
        [Description("等待完成条件")]
        [JsonPropertyName("waitUntil")]
        public WaitUntilState? WaitUntil { get; set; }
    }
}

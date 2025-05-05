using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 平台账号步骤配置类
    /// </summary>
    [Description("平台账号步骤配置")]
    public class PlatformAccountStep
    {
        /// <summary>
        /// API参考配置
        /// </summary>
        [Description("API参考")]
        [JsonPropertyName("_aPIreference")]
        public _APIreference _aPIreference { get; set; } = new _APIreference();
    }
    #region _APIreference
    /// <summary>
    /// API参考配置类
    /// </summary>
    [Description("API参考配置")]
    public class _APIreference
    {
        /// <summary>
        /// Playwright相关配置
        /// </summary>
        [Description("Platform配置")]
        [JsonPropertyName("_playwright")]
        public _Playwright _playwright { get; set; } = new _Playwright();

        /// <summary>
        /// 类相关配置
        /// </summary>
        [Description("类配置")]
        [JsonPropertyName("_classes")]
        public _Classes _classes { get; set; } = new _Classes();

        /// <summary>
        /// 断言相关配置
        /// </summary>
        [Description("断言配置")]
        [JsonPropertyName("_assertions")]
        public _Assertions _assertions { get; set; } = new _Assertions();
    }
    #region _Playwright
    /// <summary>
    /// Playwright配置类
    /// </summary>
    [Description("Playwright核心配置，包含浏览器自动化相关设置")]
    public class _Playwright
    { }
    #endregion _Playwright
    #region _Classes
    /// <summary>
    /// 类配置
    /// </summary>
    [Description("类配置")]
    public class _Classes
    {
        /// <summary>
        /// API请求配置
        /// </summary>
        [Description("API请求")]
        [JsonPropertyName("_apiRequest")]
        public _APIRequest _apiRequest { get; set; } = new _APIRequest();

        /// <summary>
        /// API请求上下文配置
        /// </summary>
        [Description("API请求上下文")]
        [JsonPropertyName("_apiRequestContext")]
        public _APIRequestContext _apiRequestContext { get; set; } = new _APIRequestContext();

        /// <summary>
        /// API响应配置
        /// </summary>
        [Description("API响应")]
        [JsonPropertyName("_apiResponse")]
        public _APIResponse _apiResponse { get; set; } = new _APIResponse();

        /// <summary>
        /// 无障碍配置
        /// </summary>
        [Description("无障碍")]
        [JsonPropertyName("_accessibility")]
        public _Accessibility _accessibility { get; set; } = new _Accessibility();

        /// <summary>
        /// 浏览器配置
        /// </summary>
        [Description("浏览器")]
        [JsonPropertyName("_browser")]
        public _Browser _browser { get; set; } = new _Browser();

        /// <summary>
        /// 浏览器上下文配置
        /// </summary>
        [Description("浏览器上下文")]
        [JsonPropertyName("_browserContext")]
        public _BrowserContext _browserContext { get; set; } = new _BrowserContext();

        /// <summary>
        /// 浏览器类型配置
        /// </summary>
        [Description("浏览器类型")]
        [JsonPropertyName("_browserType")]
        public _BrowserType _browserType { get; set; } = new _BrowserType();

        /// <summary>
        /// CDP会话配置
        /// </summary>
        [Description("CDP会话")]
        [JsonPropertyName("_cdpSession")]
        public _CDPSession _cdpSession { get; set; } = new _CDPSession();

        /// <summary>
        /// CDP会话事件配置
        /// </summary>
        [Description("CDP会话事件")]
        [JsonPropertyName("_cdpSessionEvent")]
        public _CDPSessionEvent _cdpSessionEvent { get; set; } = new _CDPSessionEvent();

        /// <summary>
        /// 时钟配置
        /// </summary>
        [Description("时钟")]
        [JsonPropertyName("_clock")]
        public _Clock _clock { get; set; } = new _Clock();

        /// <summary>
        /// 控制台消息配置
        /// </summary>
        [Description("控制台消息")]
        [JsonPropertyName("_consoleMessage")]
        public _ConsoleMessage _consoleMessage { get; set; } = new _ConsoleMessage();

        /// <summary>
        /// 对话框配置
        /// </summary>
        [Description("对话框")]
        [JsonPropertyName("_dialog")]
        public _Dialog _dialog { get; set; } = new _Dialog();

        /// <summary>
        /// 下载配置
        /// </summary>
        [Description("下载")]
        [JsonPropertyName("_download")]
        public _Download _download { get; set; } = new _Download();

        /// <summary>
        /// 元素句柄配置
        /// </summary>
        [Description("元素句柄")]
        [JsonPropertyName("_elementHandle")]
        public _ElementHandle _elementHandle { get; set; } = new _ElementHandle();

        /// <summary>
        /// 文件选择器配置
        /// </summary>
        [Description("文件选择器")]
        [JsonPropertyName("_fileChooser")]
        public _FileChooser _fileChooser { get; set; } = new _FileChooser();

        /// <summary>
        /// 表单数据配置
        /// </summary>
        [Description("表单数据")]
        [JsonPropertyName("_formData")]
        public _FormData _formData { get; set; } = new _FormData();

        /// <summary>
        /// 框架配置
        /// </summary>
        [Description("框架")]
        [JsonPropertyName("_frame")]
        public _Frame _frame { get; set; } = new _Frame();

        /// <summary>
        /// 框架定位器配置
        /// </summary>
        [Description("框架定位器")]
        [JsonPropertyName("_frameLocator")]
        public _FrameLocator _frameLocator { get; set; } = new _FrameLocator();

        /// <summary>
        /// JS句柄配置
        /// </summary>
        [Description("JS句柄")]
        [JsonPropertyName("_jsHandle")]
        public _JSHandle _jsHandle { get; set; } = new _JSHandle();

        /// <summary>
        /// 键盘配置
        /// </summary>
        [Description("键盘")]
        [JsonPropertyName("_keyboard")]
        public _Keyboard _keyboard { get; set; } = new _Keyboard();

        /// <summary>
        /// 定位器配置
        /// </summary>
        [Description("定位器")]
        [JsonPropertyName("_locator")]
        public _Locator _locator { get; set; } = new _Locator();

        /// <summary>
        /// 鼠标配置
        /// </summary>
        [Description("鼠标")]
        [JsonPropertyName("_mouse")]
        public _Mouse _mouse { get; set; } = new _Mouse();

        /// <summary>
        /// 页面配置
        /// </summary>
        [Description("页面")]
        [JsonPropertyName("_page")]
        public _Page _page { get; set; } = new _Page();

        /// <summary>
        /// 请求配置
        /// </summary>
        [Description("请求")]
        [JsonPropertyName("_request")]
        public _Request _request { get; set; } = new _Request();

        /// <summary>
        /// 响应配置
        /// </summary>
        [Description("响应")]
        [JsonPropertyName("_response")]
        public _Response _response { get; set; } = new _Response();

        /// <summary>
        /// 路由配置
        /// </summary>
        [Description("路由")]
        [JsonPropertyName("_route")]
        public _Route _route { get; set; } = new _Route();

        /// <summary>
        /// 选择器配置
        /// </summary>
        [Description("选择器")]
        [JsonPropertyName("_selectors")]
        public _Selectors _selectors { get; set; } = new _Selectors();

        /// <summary>
        /// 超时错误配置
        /// </summary>
        [Description("超时错误")]
        [JsonPropertyName("_timeoutError")]
        public _TimeoutError _timeoutError { get; set; } = new _TimeoutError();

        /// <summary>
        /// 触摸屏配置
        /// </summary>
        [Description("触摸屏")]
        [JsonPropertyName("_touchscreen")]
        public _Touchscreen _touchscreen { get; set; } = new _Touchscreen();

        /// <summary>
        /// 追踪配置
        /// </summary>
        [Description("追踪")]
        [JsonPropertyName("_tracing")]
        public _Tracing _tracing { get; set; } = new _Tracing();

        /// <summary>
        /// 视频配置
        /// </summary>
        [Description("视频")]
        [JsonPropertyName("_video")]
        public _Video _video { get; set; } = new _Video();

        /// <summary>
        /// Web错误配置
        /// </summary>
        [Description("Web错误")]
        [JsonPropertyName("_webError")]
        public _WebError _webError { get; set; } = new _WebError();

        /// <summary>
        /// WebSocket配置
        /// </summary>
        [Description("WebSocket")]
        [JsonPropertyName("_webSocket")]
        public _WebSocket _webSocket { get; set; } = new _WebSocket();

        /// <summary>
        /// WebSocket帧配置
        /// </summary>
        [Description("WebSocket帧")]
        [JsonPropertyName("_webSocketFrame")]
        public _WebSocketFrame _webSocketFrame { get; set; } = new _WebSocketFrame();

        /// <summary>
        /// WebSocket路由配置
        /// </summary>
        [Description("WebSocket路由")]
        [JsonPropertyName("_webSocketRoute")]
        public _WebSocketRoute _webSocketRoute { get; set; } = new _WebSocketRoute();

        /// <summary>
        /// 工作线程配置
        /// </summary>
        [Description("工作线程")]
        [JsonPropertyName("_worker")]
        public _Worker _worker { get; set; } = new _Worker();
    }
    #endregion _Classes
    #region _Assertions
    /// <summary>
    /// 断言配置类
    /// </summary>
    [Description("测试断言配置，包含各种验证条件设置")]
    public class _Assertions
    { }
    #endregion _Assertions
    #endregion _Playwright
}
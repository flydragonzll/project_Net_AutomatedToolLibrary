using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// Playwright Page类的方法集合
    /// </summary>
    public class _PageMethods
    {
        /// <summary>
        /// 添加初始化脚本方法
        /// </summary>
        [Description("在页面加载时添加JavaScript脚本")]
        [JsonPropertyName("_pageMethod_AddInitScriptAsync")]
        public _PageMethod_AddInitScriptAsync _pageMethod_AddInitScriptAsync { get; set; } = new _PageMethod_AddInitScriptAsync();

        /// <summary>
        /// 添加定位器处理方法
        /// </summary>
        [Description("添加处理特定定位器事件的处理器")]
        [JsonPropertyName("_pageMethod_AddLocatorHandlerAsync")]
        public _PageMethod_AddLocatorHandlerAsync _pageMethod_AddLocatorHandlerAsync { get; set; } = new _PageMethod_AddLocatorHandlerAsync();

        /// <summary>
        /// 添加脚本标签方法
        /// </summary>
        [Description("向页面添加JavaScript脚本标签")]
        [JsonPropertyName("_pageMethod_AddScriptTagAsync")]
        public _PageMethod_AddScriptTagAsync _pageMethod_AddScriptTagAsync { get; set; } = new _PageMethod_AddScriptTagAsync();

        /// <summary>
        /// 添加样式标签方法
        /// </summary>
        [Description("向页面添加CSS样式标签")]
        [JsonPropertyName("_pageMethod_AddStyleTagAsync")]
        public _PageMethod_AddStyleTagAsync _pageMethod_AddStyleTagAsync { get; set; } = new _PageMethod_AddStyleTagAsync();

        /// <summary>
        /// 页面置顶方法
        /// </summary>
        [Description("将页面标签置顶显示")]
        [JsonPropertyName("_pageMethod_BringToFrontAsync")]
        public _PageMethod_BringToFrontAsync _pageMethod_BringToFrontAsync { get; set; } = new _PageMethod_BringToFrontAsync();

        /// <summary>
        /// 关闭页面方法
        /// </summary>
        [Description("关闭当前页面")]
        [JsonPropertyName("_pageMethod_CloseAsync")]
        public _PageMethod_CloseAsync _pageMethod_CloseAsync { get; set; } = new _PageMethod_CloseAsync();

        /// <summary>
        /// 获取页面内容方法
        /// </summary>
        [Description("获取页面完整的HTML内容")]
        [JsonPropertyName("_pageMethod_ContentAsync")]
        public _PageMethod_ContentAsync _pageMethod_ContentAsync { get; set; } = new _PageMethod_ContentAsync();

        /// <summary>
        /// 获取浏览器上下文
        /// </summary>
        [Description("获取页面所属的浏览器上下文")]
        [JsonPropertyName("_pageMethod_Context")]
        public _PageMethod_Context _pageMethod_Context { get; set; } = new _PageMethod_Context();

        /// <summary>
        /// 拖放操作方法
        /// </summary>
        [Description("执行元素拖放操作")]
        [JsonPropertyName("_pageMethod_DragAndDropAsync")]
        public _PageMethod_DragAndDropAsync _pageMethod_DragAndDropAsync { get; set; } = new _PageMethod_DragAndDropAsync();

        /// <summary>
        /// 模拟媒体类型方法
        /// </summary>
        [Description("模拟特定的媒体类型(如print或screen)")]
        [JsonPropertyName("_pageMethod_EmulateMediaAsync")]
        public _PageMethod_EmulateMediaAsync _pageMethod_EmulateMediaAsync { get; set; } = new _PageMethod_EmulateMediaAsync();
        /// <summary>
        /// 执行JavaScript表达式方法
        /// </summary>
        [Description("在页面上下文中执行JavaScript表达式")]
        [JsonPropertyName("_pageMethod_EvaluateAsync")]
        public _PageMethod_EvaluateAsync _pageMethod_EvaluateAsync { get; set; } = new _PageMethod_EvaluateAsync();

        /// <summary>
        /// 获取JavaScript句柄方法
        /// </summary>
        [Description("执行JavaScript表达式并返回其句柄")]
        [JsonPropertyName("_pageMethod_EvaluateHandleAsync")]
        public _PageMethod_EvaluateHandleAsync _pageMethod_EvaluateHandleAsync { get; set; } = new _PageMethod_EvaluateHandleAsync();

        /// <summary>
        /// 暴露绑定方法
        /// </summary>
        [Description("将.NET方法暴露给页面中的JavaScript")]
        [JsonPropertyName("_pageMethod_ExposeBindingAsync")]
        public _PageMethod_ExposeBindingAsync _pageMethod_ExposeBindingAsync { get; set; } = new _PageMethod_ExposeBindingAsync();

        /// <summary>
        /// 暴露函数方法
        /// </summary>
        [Description("将.NET函数暴露给页面中的JavaScript")]
        [JsonPropertyName("_pageMethod_ExposeFunctionAsync")]
        public _PageMethod_ExposeFunctionAsync _pageMethod_ExposeFunctionAsync { get; set; } = new _PageMethod_ExposeFunctionAsync();

        /// <summary>
        /// 获取框架方法
        /// </summary>
        [Description("通过名称或属性获取页面中的框架")]
        [JsonPropertyName("_pageMethod_Frame")]
        public _PageMethod_Frame _pageMethod_Frame { get; set; } = new _PageMethod_Frame();

        /// <summary>
        /// 通过URL获取框架方法
        /// </summary>
        [Description("通过URL匹配获取页面中的框架")]
        [JsonPropertyName("_pageMethod_FrameByUrl")]
        public _PageMethod_FrameByUrl _pageMethod_FrameByUrl { get; set; } = new _PageMethod_FrameByUrl();

        /// <summary>
        /// 框架定位器方法
        /// </summary>
        [Description("创建框架定位器以查找框架内元素")]
        [JsonPropertyName("_pageMethod_FrameLocator")]
        public _PageMethod_FrameLocator _pageMethod_FrameLocator { get; set; } = new _PageMethod_FrameLocator();

        /// <summary>
        /// 获取所有框架方法
        /// </summary>
        [Description("获取页面中的所有框架列表")]
        [JsonPropertyName("_pageMethod_Frames")]
        public _PageMethod_Frames _pageMethod_Frames { get; set; } = new _PageMethod_Frames();

        /// <summary>
        /// 通过alt文本获取元素方法
        /// </summary>
        [Description("通过alt属性文本查找元素")]
        [JsonPropertyName("_pageMethod_GetByAltText")]
        public _PageMethod_GetByAltText _pageMethod_GetByAltText { get; set; } = new _PageMethod_GetByAltText();

        /// <summary>
        /// 通过label文本获取元素方法
        /// </summary>
        [Description("通过关联的label文本查找元素")]
        [JsonPropertyName("_pageMethod_GetByLabel")]
        public _PageMethod_GetByLabel _pageMethod_GetByLabel { get; set; } = new _PageMethod_GetByLabel();
        /// <summary>
        /// 通过占位符获取元素方法
        /// </summary>
        [Description("通过placeholder属性文本查找元素")]
        [JsonPropertyName("_pageMethod_GetByPlaceholder")]
        public _PageMethod_GetByPlaceholder _pageMethod_GetByPlaceholder { get; set; } = new _PageMethod_GetByPlaceholder();

        /// <summary>
        /// 通过角色获取元素方法
        /// </summary>
        [Description("通过ARIA角色查找元素")]
        [JsonPropertyName("_pageMethod_GetByRole")]
        public _PageMethod_GetByRole _pageMethod_GetByRole { get; set; } = new _PageMethod_GetByRole();

        /// <summary>
        /// 通过测试ID获取元素方法
        /// </summary>
        [Description("通过data-testid属性查找元素")]
        [JsonPropertyName("_pageMethod_GetByTestId")]
        public _PageMethod_GetByTestId _pageMethod_GetByTestId { get; set; } = new _PageMethod_GetByTestId();

        /// <summary>
        /// 通过文本获取元素方法
        /// </summary>
        [Description("通过文本内容查找元素")]
        [JsonPropertyName("_pageMethod_GetByText")]
        public _PageMethod_GetByText _pageMethod_GetByText { get; set; } = new _PageMethod_GetByText();

        /// <summary>
        /// 通过title属性获取元素方法
        /// </summary>
        [Description("通过title属性文本查找元素")]
        [JsonPropertyName("_pageMethod_GetByTitle")]
        public _PageMethod_GetByTitle _pageMethod_GetByTitle { get; set; } = new _PageMethod_GetByTitle();

        /// <summary>
        /// 页面后退方法
        /// </summary>
        [Description("在页面历史记录中后退")]
        [JsonPropertyName("_pageMethod_GoBackAsync")]
        public _PageMethod_GoBackAsync _pageMethod_GoBackAsync { get; set; } = new _PageMethod_GoBackAsync();

        /// <summary>
        /// 页面前进方法
        /// </summary>
        [Description("在页面历史记录中前进")]
        [JsonPropertyName("_pageMethod_GoForwardAsync")]
        public _PageMethod_GoForwardAsync _pageMethod_GoForwardAsync { get; set; } = new _PageMethod_GoForwardAsync();

        /// <summary>
        /// 页面跳转方法
        /// </summary>
        [Description("导航到指定的URL")]
        [JsonPropertyName("_pageMethod_GotoAsync")]
        public _PageMethod_GotoAsync _pageMethod_GotoAsync { get; set; } = new _PageMethod_GotoAsync();

        /// <summary>
        /// 检查页面是否关闭方法
        /// </summary>
        [Description("检查页面是否已关闭")]
        [JsonPropertyName("_pageMethod_IsClosed")]
        public _PageMethod_IsClosed _pageMethod_IsClosed { get; set; } = new _PageMethod_IsClosed();

        /// <summary>
        /// 创建定位器方法
        /// </summary>
        [Description("创建元素定位器")]
        [JsonPropertyName("_pageMethod_Locator")]
        public _PageMethod_Locator _pageMethod_Locator { get; set; } = new _PageMethod_Locator();
        /// <summary>
        /// 获取主框架方法
        /// </summary>
        [Description("获取页面的主框架")]
        [JsonPropertyName("_pageMethod_MainFrame")]
        public _PageMethod_MainFrame _pageMethod_MainFrame { get; set; } = new _PageMethod_MainFrame();

        /// <summary>
        /// 获取打开者方法
        /// </summary>
        [Description("获取打开当前页面的页面")]
        [JsonPropertyName("_pageMethod_OpenerAsync")]
        public _PageMethod_OpenerAsync _pageMethod_OpenerAsync { get; set; } = new _PageMethod_OpenerAsync();

        /// <summary>
        /// 暂停方法
        /// </summary>
        [Description("暂停脚本执行")]
        [JsonPropertyName("_pageMethod_PauseAsync")]
        public _PageMethod_PauseAsync _pageMethod_PauseAsync { get; set; } = new _PageMethod_PauseAsync();

        /// <summary>
        /// 生成PDF方法
        /// </summary>
        [Description("将页面生成PDF文件")]
        [JsonPropertyName("_pageMethod_PdfAsync")]
        public _PageMethod_PdfAsync _pageMethod_PdfAsync { get; set; } = new _PageMethod_PdfAsync();

        /// <summary>
        /// 重新加载方法
        /// </summary>
        [Description("重新加载当前页面")]
        [JsonPropertyName("_pageMethod_ReloadAsync")]
        public _PageMethod_ReloadAsync _pageMethod_ReloadAsync { get; set; } = new _PageMethod_ReloadAsync();

        /// <summary>
        /// 移除定位器处理方法
        /// </summary>
        [Description("移除之前添加的定位器处理器")]
        [JsonPropertyName("_pageMethod_RemoveLocatorHandlerAsync")]
        public _PageMethod_RemoveLocatorHandlerAsync _pageMethod_RemoveLocatorHandlerAsync { get; set; } = new _PageMethod_RemoveLocatorHandlerAsync();

        /// <summary>
        /// 请求垃圾回收方法
        /// </summary>
        [Description("请求JavaScript垃圾回收")]
        [JsonPropertyName("_pageMethod_RequestGCAsync")]
        public _PageMethod_RequestGCAsync _pageMethod_RequestGCAsync { get; set; } = new _PageMethod_RequestGCAsync();

        /// <summary>
        /// 路由请求方法
        /// </summary>
        [Description("拦截和修改网络请求")]
        [JsonPropertyName("_pageMethod_RouteAsync")]
        public _PageMethod_RouteAsync _pageMethod_RouteAsync { get; set; } = new _PageMethod_RouteAsync();

        /// <summary>
        /// 从HAR文件路由方法
        /// </summary>
        [Description("从HAR文件记录中路由网络请求")]
        [JsonPropertyName("_pageMethod_RouteFromHARAsync")]
        public _PageMethod_RouteFromHARAsync _pageMethod_RouteFromHARAsync { get; set; } = new _PageMethod_RouteFromHARAsync();

        /// <summary>
        /// WebSocket路由方法
        /// </summary>
        [Description("拦截和修改WebSocket请求")]
        [JsonPropertyName("_pageMethod_RouteWebSocketAsync")]
        public _PageMethod_RouteWebSocketAsync _pageMethod_RouteWebSocketAsync { get; set; } = new _PageMethod_RouteWebSocketAsync();
        /// <summary>
        /// 运行并等待控制台消息方法
        /// </summary>
        [Description("执行操作并等待控制台消息")]
        [JsonPropertyName("_pageMethod_RunAndWaitForConsoleMessageAsync")]
        public _PageMethod_RunAndWaitForConsoleMessageAsync _pageMethod_RunAndWaitForConsoleMessageAsync { get; set; } = new _PageMethod_RunAndWaitForConsoleMessageAsync();

        /// <summary>
        /// 等待控制台消息方法
        /// </summary>
        [Description("等待特定的控制台消息出现")]
        [JsonPropertyName("_pageMethod_WaitForConsoleMessageAsync")]
        public _PageMethod_WaitForConsoleMessageAsync _pageMethod_WaitForConsoleMessageAsync { get; set; } = new _PageMethod_WaitForConsoleMessageAsync();

        /// <summary>
        /// 运行并等待下载方法
        /// </summary>
        [Description("执行操作并等待下载开始")]
        [JsonPropertyName("_pageMethod_RunAndWaitForDownloadAsync")]
        public _PageMethod_RunAndWaitForDownloadAsync _pageMethod_RunAndWaitForDownloadAsync { get; set; } = new _PageMethod_RunAndWaitForDownloadAsync();

        /// <summary>
        /// 等待下载方法
        /// </summary>
        [Description("等待下载开始")]
        [JsonPropertyName("_pageMethod_WaitForDownloadAsync")]
        public _PageMethod_WaitForDownloadAsync _pageMethod_WaitForDownloadAsync { get; set; } = new _PageMethod_WaitForDownloadAsync();

        /// <summary>
        /// 运行并等待文件选择器方法
        /// </summary>
        [Description("执行操作并等待文件选择器出现")]
        [JsonPropertyName("_pageMethod_RunAndWaitForFileChooserAsync")]
        public _PageMethod_RunAndWaitForFileChooserAsync _pageMethod_RunAndWaitForFileChooserAsync { get; set; } = new _PageMethod_RunAndWaitForFileChooserAsync();

        /// <summary>
        /// 等待文件选择器方法
        /// </summary>
        [Description("等待文件选择器出现")]
        [JsonPropertyName("_pageMethod_WaitForFileChooserAsync")]
        public _PageMethod_WaitForFileChooserAsync _pageMethod_WaitForFileChooserAsync { get; set; } = new _PageMethod_WaitForFileChooserAsync();

        /// <summary>
        /// 运行并等待弹出窗口方法
        /// </summary>
        [Description("执行操作并等待弹出窗口出现")]
        [JsonPropertyName("_pageMethod_RunAndWaitForPopupAsync")]
        public _PageMethod_RunAndWaitForPopupAsync _pageMethod_RunAndWaitForPopupAsync { get; set; } = new _PageMethod_RunAndWaitForPopupAsync();

        /// <summary>
        /// 等待弹出窗口方法
        /// </summary>
        [Description("等待弹出窗口出现")]
        [JsonPropertyName("_pageMethod_WaitForPopupAsync")]
        public _PageMethod_WaitForPopupAsync _pageMethod_WaitForPopupAsync { get; set; } = new _PageMethod_WaitForPopupAsync();

        /// <summary>
        /// 运行并等待请求方法
        /// </summary>
        [Description("执行操作并等待特定请求")]
        [JsonPropertyName("_pageMethod_RunAndWaitForRequestAsync")]
        public _PageMethod_RunAndWaitForRequestAsync _pageMethod_RunAndWaitForRequestAsync { get; set; } = new _PageMethod_RunAndWaitForRequestAsync();

        /// <summary>
        /// 等待请求方法
        /// </summary>
        [Description("等待特定请求")]
        [JsonPropertyName("_pageMethod_WaitForRequestAsync")]
        public _PageMethod_WaitForRequestAsync _pageMethod_WaitForRequestAsync { get; set; } = new _PageMethod_WaitForRequestAsync();
        /// <summary>
        /// 运行并等待请求完成方法
        /// </summary>
        [Description("执行操作并等待请求完成")]
        [JsonPropertyName("_pageMethod_RunAndWaitForRequestFinishedAsync")]
        public _PageMethod_RunAndWaitForRequestFinishedAsync _pageMethod_RunAndWaitForRequestFinishedAsync { get; set; } = new _PageMethod_RunAndWaitForRequestFinishedAsync();

        /// <summary>
        /// 等待请求完成方法
        /// </summary>
        [Description("等待请求完成")]
        [JsonPropertyName("_pageMethod_WaitForRequestFinishedAsync")]
        public _PageMethod_WaitForRequestFinishedAsync _pageMethod_WaitForRequestFinishedAsync { get; set; } = new _PageMethod_WaitForRequestFinishedAsync();

        /// <summary>
        /// 运行并等待响应方法
        /// </summary>
        [Description("执行操作并等待特定响应")]
        [JsonPropertyName("_pageMethod_RunAndWaitForResponseAsync")]
        public _PageMethod_RunAndWaitForResponseAsync _pageMethod_RunAndWaitForResponseAsync { get; set; } = new _PageMethod_RunAndWaitForResponseAsync();

        /// <summary>
        /// 等待响应方法
        /// </summary>
        [Description("等待特定响应")]
        [JsonPropertyName("_pageMethod_WaitForResponseAsync")]
        public _PageMethod_WaitForResponseAsync _pageMethod_WaitForResponseAsync { get; set; } = new _PageMethod_WaitForResponseAsync();

        /// <summary>
        /// 运行并等待WebSocket方法
        /// </summary>
        [Description("执行操作并等待WebSocket连接")]
        [JsonPropertyName("_pageMethod_RunAndWaitForWebSocketAsync")]
        public _PageMethod_RunAndWaitForWebSocketAsync _pageMethod_RunAndWaitForWebSocketAsync { get; set; } = new _PageMethod_RunAndWaitForWebSocketAsync();
        /// <summary>
        /// 等待WebSocket方法
        /// </summary>
        [Description("等待WebSocket连接")]
        [JsonPropertyName("_pageMethod_WaitForWebSocketAsync")]
        public _PageMethod_WaitForWebSocketAsync _pageMethod_WaitForWebSocketAsync { get; set; } = new _PageMethod_WaitForWebSocketAsync();

        /// <summary>
        /// 运行并等待Worker方法
        /// </summary>
        [Description("执行操作并等待Worker创建")]
        [JsonPropertyName("_pageMethod_RunAndWaitForWorkerAsync")]
        public _PageMethod_RunAndWaitForWorkerAsync _pageMethod_RunAndWaitForWorkerAsync { get; set; } = new _PageMethod_RunAndWaitForWorkerAsync();

        /// <summary>
        /// 等待Worker方法
        /// </summary>
        [Description("等待Worker创建")]
        [JsonPropertyName("_pageMethod_WaitForWorkerAsync")]
        public _PageMethod_WaitForWorkerAsync _pageMethod_WaitForWorkerAsync { get; set; } = new _PageMethod_WaitForWorkerAsync();

        /// <summary>
        /// 截图方法
        /// </summary>
        [Description("对页面进行截图")]
        [JsonPropertyName("_pageMethod_ScreenshotAsync")]
        public _PageMethod_ScreenshotAsync _pageMethod_ScreenshotAsync { get; set; } = new _PageMethod_ScreenshotAsync();

        /// <summary>
        /// 设置内容方法
        /// </summary>
        [Description("设置页面的HTML内容")]
        [JsonPropertyName("_pageMethod_SetContentAsync")]
        public _PageMethod_SetContentAsync _pageMethod_SetContentAsync { get; set; } = new _PageMethod_SetContentAsync();
        /// <summary>
        /// 设置默认导航超时方法
        /// </summary>
        [Description("设置页面导航的默认超时时间")]
        [JsonPropertyName("_pageMethod_SetDefaultNavigationTimeout")]
        public _PageMethod_SetDefaultNavigationTimeout _pageMethod_SetDefaultNavigationTimeout { get; set; } = new _PageMethod_SetDefaultNavigationTimeout();

        /// <summary>
        /// 设置默认超时方法
        /// </summary>
        [Description("设置页面操作的默认超时时间")]
        [JsonPropertyName("_pageMethod_SetDefaultTimeout")]
        public _PageMethod_SetDefaultTimeout _pageMethod_SetDefaultTimeout { get; set; } = new _PageMethod_SetDefaultTimeout();

        /// <summary>
        /// 设置额外HTTP头方法
        /// </summary>
        [Description("设置额外的HTTP请求头")]
        [JsonPropertyName("_pageMethod_SetExtraHTTPHeadersAsync")]
        public _PageMethod_SetExtraHTTPHeadersAsync _pageMethod_SetExtraHTTPHeadersAsync { get; set; } = new _PageMethod_SetExtraHTTPHeadersAsync();

        /// <summary>
        /// 设置视口大小方法
        /// </summary>
        [Description("设置页面视口大小")]
        [JsonPropertyName("_pageMethod_SetViewportSizeAsync")]
        public _PageMethod_SetViewportSizeAsync _pageMethod_SetViewportSizeAsync { get; set; } = new _PageMethod_SetViewportSizeAsync();

        /// <summary>
        /// 获取标题方法
        /// </summary>
        [Description("获取页面标题")]
        [JsonPropertyName("_pageMethod_TitleAsync")]
        public _PageMethod_TitleAsync _pageMethod_TitleAsync { get; set; } = new _PageMethod_TitleAsync();
        /// <summary>
        /// 取消路由方法
        /// </summary>
        [Description("取消特定的请求路由")]
        [JsonPropertyName("_pageMethod_UnrouteAsync")]
        public _PageMethod_UnrouteAsync _pageMethod_UnrouteAsync { get; set; } = new _PageMethod_UnrouteAsync();

        /// <summary>
        /// 取消所有路由方法
        /// </summary>
        [Description("取消所有请求路由")]
        [JsonPropertyName("_pageMethod_UnrouteAllAsync")]
        public _PageMethod_UnrouteAllAsync _pageMethod_UnrouteAllAsync { get; set; } = new _PageMethod_UnrouteAllAsync();

        /// <summary>
        /// 获取URL方法
        /// </summary>
        [Description("获取当前页面URL")]
        [JsonPropertyName("_pageMethod_Url")]
        public _PageMethod_Url _pageMethod_Url { get; set; } = new _PageMethod_Url();

        /// <summary>
        /// 获取视频方法
        /// </summary>
        [Description("获取页面视频对象")]
        [JsonPropertyName("_pageMethod_Video")]
        public _PageMethod_Video _pageMethod_Video { get; set; } = new _PageMethod_Video();

        /// <summary>
        /// 获取视口大小方法
        /// </summary>
        [Description("获取页面视口大小")]
        [JsonPropertyName("_pageMethod_ViewportSize")]
        public _PageMethod_ViewportSize _pageMethod_ViewportSize { get; set; } = new _PageMethod_ViewportSize();

        /// <summary>
        /// 等待函数方法
        /// </summary>
        [Description("等待JavaScript函数返回真值")]
        [JsonPropertyName("_pageMethod_WaitForFunctionAsync")]
        public _PageMethod_WaitForFunctionAsync _pageMethod_WaitForFunctionAsync { get; set; } = new _PageMethod_WaitForFunctionAsync();

        /// <summary>
        /// 等待加载状态方法
        /// </summary>
        [Description("等待页面达到特定加载状态")]
        [JsonPropertyName("_pageMethod_WaitForLoadStateAsync")]
        public _PageMethod_WaitForLoadStateAsync _pageMethod_WaitForLoadStateAsync { get; set; } = new _PageMethod_WaitForLoadStateAsync();

        /// <summary>
        /// 等待URL方法
        /// </summary>
        [Description("等待URL匹配特定模式")]
        [JsonPropertyName("_pageMethod_WaitForURLAsync")]
        public _PageMethod_WaitForURLAsync _pageMethod_WaitForURLAsync { get; set; } = new _PageMethod_WaitForURLAsync();

        /// <summary>
        /// 获取Workers方法
        /// </summary>
        [Description("获取页面所有Worker")]
        [JsonPropertyName("_pageMethod_Workers")]
        public _PageMethod_Workers _pageMethod_Workers { get; set; } = new _PageMethod_Workers();
    }
}
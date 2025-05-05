using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 从 HAR 文件路由请求方法类
    /// </summary>
    [Description("从 HAR 文件路由请求方法配置")]
    public class _PageMethod_RouteFromHARAsync
    {
        [Description("HAR 文件路径")]
        [JsonPropertyName("_harPath")]
        public string _harPath { get; set; }

        [Description("路由选项")]
        [JsonPropertyName("_pageRouteFromHAROptions")]
        public _PageMethod_RouteFromHARAsync_PageRouteFromHAROptions? _pageRouteFromHAROptions { get; set; } = new _PageMethod_RouteFromHARAsync_PageRouteFromHAROptions();
    }

    /// <summary>
    /// 路由选项配置类
    /// </summary>
    [Description("路由选项配置")]
    public class _PageMethod_RouteFromHARAsync_PageRouteFromHAROptions
    {
        [Description("未找到处理方式")]
        [JsonPropertyName("notFound")]
        public string NotFound { get; set; }

        [Description("URL 匹配模式")]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [Description("是否更新")]
        [JsonPropertyName("update")]
        public bool? Update { get; set; }

        [Description("更新内容")]
        [JsonPropertyName("updateContent")]
        public bool? UpdateContent { get; set; }

        [Description("更新模式")]
        [JsonPropertyName("updateMode")]
        public string UpdateMode { get; set; }
    }
}
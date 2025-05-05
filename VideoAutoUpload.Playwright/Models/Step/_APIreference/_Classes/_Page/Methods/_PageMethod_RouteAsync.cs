using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 路由请求方法类
    /// </summary>
    [Description("路由请求方法配置")]
    public class _PageMethod_RouteAsync
    {
        [Description("URL 匹配模式")]
        [JsonPropertyName("_urlMatch")]
        public string _urlMatch { get; set; }

        [Description("路由处理函数")]
        [JsonPropertyName("_handler")]
        public object _handler { get; set; }

        [Description("路由选项")]
        [JsonPropertyName("_pageRouteOptions")]
        public _PageMethod_RouteAsync_PageRouteOptions? _pageRouteOptions { get; set; } = new _PageMethod_RouteAsync_PageRouteOptions();
    }

    /// <summary>
    /// 路由选项配置类
    /// </summary>
    [Description("路由选项配置")]
    public class _PageMethod_RouteAsync_PageRouteOptions
    {
        [Description("触发次数")]
        [JsonPropertyName("times")]
        public int? Times { get; set; }
    }
}
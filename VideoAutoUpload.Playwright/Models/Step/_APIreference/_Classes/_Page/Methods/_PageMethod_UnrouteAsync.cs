using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 取消路由方法类
    /// </summary>
    [Description("取消路由方法配置")]
    public class _PageMethod_UnrouteAsync
    {
        [Description("URL 匹配模式")]
        [JsonPropertyName("_urlMatch")]
        public string _urlMatch { get; set; }

        [Description("路由处理函数")]
        [JsonPropertyName("_handler")]
        public object _handler { get; set; }
    }
}
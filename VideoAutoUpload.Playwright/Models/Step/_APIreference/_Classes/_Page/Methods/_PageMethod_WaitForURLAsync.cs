using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 等待 URL 方法类
    /// </summary>
    [Description("等待 URL 方法配置")]
    public class _PageMethod_WaitForURLAsync
    {
        [Description("URL 匹配模式")]
        [JsonPropertyName("_urlMatch")]
        public string _urlMatch { get; set; }

        [Description("等待 URL 选项")]
        [JsonPropertyName("_pageWaitForURLOptions")]
        public _PageMethod_WaitForURLAsync_PageWaitForURLOptions? _pageWaitForURLOptions { get; set; } = new _PageMethod_WaitForURLAsync_PageWaitForURLOptions();
    }

    /// <summary>
    /// 等待 URL 选项配置类
    /// </summary>
    [Description("等待 URL 选项配置")]
    public class _PageMethod_WaitForURLAsync_PageWaitForURLOptions
    {
        [Description("等待完成条件")]
        [JsonPropertyName("waitUntil")]
        public string WaitUntil { get; set; }

        [Description("超时时间(毫秒)")]
        [JsonPropertyName("timeout")]
        public float? Timeout { get; set; }
    }
}
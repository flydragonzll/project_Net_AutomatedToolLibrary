using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 设置内容方法类
    /// </summary>
    [Description("设置内容方法配置")]
    public class _PageMethod_SetContentAsync
    {
        [Description("HTML 内容")]
        [JsonPropertyName("_html")]
        public string _html { get; set; }

        [Description("设置内容选项")]
        [JsonPropertyName("_pageSetContentOptions")]
        public _PageMethod_SetContentAsync_PageSetContentOptions? _pageSetContentOptions { get; set; } = new _PageMethod_SetContentAsync_PageSetContentOptions();
    }

    /// <summary>
    /// 设置内容选项配置类
    /// </summary>
    [Description("设置内容选项配置")]
    public class _PageMethod_SetContentAsync_PageSetContentOptions
    {
        [Description("等待完成条件")]
        [JsonPropertyName("waitUntil")]
        public string WaitUntil { get; set; }

        [Description("超时时间(毫秒)")]
        [JsonPropertyName("timeout")]
        public float? Timeout { get; set; }
    }
}
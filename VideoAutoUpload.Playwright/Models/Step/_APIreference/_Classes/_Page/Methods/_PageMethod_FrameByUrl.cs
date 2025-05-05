using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 根据 URL 获取框架方法类
    /// </summary>
    [Description("根据 URL 获取框架方法配置")]
    public class _PageMethod_FrameByUrl
    {
        [Description("URL 字符串")]
        [JsonPropertyName("_urlString")]
        public string _urlString { get; set; }

        [Description("URL 正则表达式")]
        [JsonPropertyName("_urlRegex")]
        public string _urlRegex { get; set; }

        [Description("URL 函数")]
        [JsonPropertyName("_urlFunc")]
        public object _urlFunc { get; set; }

        [Description("框架对象")]
        [JsonPropertyName("_frame")]
        public object _frame { get; set; }
    }
}
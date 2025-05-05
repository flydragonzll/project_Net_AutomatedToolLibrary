using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取 URL 方法类
    /// </summary>
    [Description("获取 URL 方法配置")]
    public class _PageMethod_Url
    {
        [Description("页面 URL")]
        [JsonPropertyName("_url")]
        public string _url { get; set; }
    }
}
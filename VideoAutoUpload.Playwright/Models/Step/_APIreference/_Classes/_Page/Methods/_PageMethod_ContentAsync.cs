using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取页面内容方法类
    /// </summary>
    [Description("获取页面内容方法配置")]
    public class _PageMethod_ContentAsync
    {
        [Description("页面内容")]
        [JsonPropertyName("_content")]
        public string _content { get; set; }
    }
}
using Microsoft.Playwright;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 添加样式标签方法类
    /// </summary>
    [Description("添加样式标签方法配置")]
    public class _PageMethod_AddStyleTagAsync
    {
        [Description("样式URL地址")]
        [JsonPropertyName("_url")]
        public string _url { get; set; }

        [Description("样式文件路径")]
        [JsonPropertyName("_path")]
        public string _path { get; set; }

        [Description("样式内容")]
        [JsonPropertyName("_content")]
        public string _content { get; set; }
    }
}
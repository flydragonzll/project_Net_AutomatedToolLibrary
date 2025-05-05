using Microsoft.Playwright;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 添加脚本标签方法类
    /// </summary>
    [Description("添加脚本标签方法配置")]
    public class _PageMethod_AddScriptTagAsync
    {
        [Description("脚本URL地址")]
        [JsonPropertyName("_url")]
        public string _url { get; set; }

        [Description("脚本文件路径")]
        [JsonPropertyName("_path")]
        public string _path { get; set; }
    }
}
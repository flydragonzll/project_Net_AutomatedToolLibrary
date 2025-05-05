using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取页面上下文方法类
    /// </summary>
    [Description("获取页面上下文方法配置")]
    public class _PageMethod_Context
    {
        [Description("页面上下文")]
        [JsonPropertyName("_context")]
        public object _context { get; set; }
    }
}
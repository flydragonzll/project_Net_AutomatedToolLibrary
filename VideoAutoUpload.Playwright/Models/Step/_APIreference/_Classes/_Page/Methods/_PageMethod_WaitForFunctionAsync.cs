using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 等待函数方法类
    /// </summary>
    [Description("等待函数方法配置")]
    public class _PageMethod_WaitForFunctionAsync
    {
        [Description("JavaScript 表达式")]
        [JsonPropertyName("_expression")]
        public string _expression { get; set; }

        [Description("参数")]
        [JsonPropertyName("_arg")]
        public object _arg { get; set; }

        [Description("等待函数选项")]
        [JsonPropertyName("_pageWaitForFunctionOptions")]
        public _PageMethod_WaitForFunctionAsync_PageWaitForFunctionOptions? _pageWaitForFunctionOptions { get; set; } = new _PageMethod_WaitForFunctionAsync_PageWaitForFunctionOptions();
    }

    /// <summary>
    /// 等待函数选项配置类
    /// </summary>
    [Description("等待函数选项配置")]
    public class _PageMethod_WaitForFunctionAsync_PageWaitForFunctionOptions
    {
        [Description("轮询间隔(毫秒)")]
        [JsonPropertyName("pollingInterval")]
        public float? PollingInterval { get; set; }

        [Description("超时时间(毫秒)")]
        [JsonPropertyName("timeout")]
        public float? Timeout { get; set; }
    }
}
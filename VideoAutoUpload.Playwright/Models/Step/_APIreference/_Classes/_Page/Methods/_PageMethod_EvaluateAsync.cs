using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 执行 JavaScript 表达式方法类
    /// </summary>
    [Description("执行 JavaScript 表达式方法配置")]
    public class _PageMethod_EvaluateAsync
    {
        [Description("JavaScript 表达式")]
        [JsonPropertyName("_expression")]
        public string _expression { get; set; }

        [Description("参数")]
        [JsonPropertyName("_arg")]
        public object _arg { get; set; }

        [Description("返回值")]
        [JsonPropertyName("_ret")]
        public object _ret { get; set; }
    }
}
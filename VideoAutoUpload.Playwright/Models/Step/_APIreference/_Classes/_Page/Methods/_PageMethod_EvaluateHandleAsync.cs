using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 执行 JavaScript 表达式并返回句柄方法类
    /// </summary>
    [Description("执行 JavaScript 表达式并返回句柄方法配置")]
    public class _PageMethod_EvaluateHandleAsync
    {
        [Description("JavaScript 表达式")]
        [JsonPropertyName("_expression")]
        public string _expression { get; set; }

        [Description("参数")]
        [JsonPropertyName("_arg")]
        public object _arg { get; set; }

        [Description("返回的句柄")]
        [JsonPropertyName("_ret_IJSHandle")]
        public object _ret_IJSHandle { get; set; }
    }
}
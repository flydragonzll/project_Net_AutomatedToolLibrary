using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 等待控制台消息方法类
    /// </summary>
    [Description("等待控制台消息方法配置")]
    public class _PageMethod_WaitForConsoleMessageAsync
    {
        [Description("控制台消息对象")]
        [JsonPropertyName("_ret_IConsoleMessage")]
        public object _ret_IConsoleMessage { get; set; }
    }
}
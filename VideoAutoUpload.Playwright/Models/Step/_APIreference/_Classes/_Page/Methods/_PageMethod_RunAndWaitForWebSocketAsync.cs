using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 运行并等待 WebSocket 方法类
    /// </summary>
    [Description("运行并等待 WebSocket 方法配置")]
    public class _PageMethod_RunAndWaitForWebSocketAsync
    {
        [Description("操作函数")]
        [JsonPropertyName("_action")]
        public object _action { get; set; }

        [Description("WebSocket 对象")]
        [JsonPropertyName("_ret_IWebSocket")]
        public object _ret_IWebSocket { get; set; }
    }
}
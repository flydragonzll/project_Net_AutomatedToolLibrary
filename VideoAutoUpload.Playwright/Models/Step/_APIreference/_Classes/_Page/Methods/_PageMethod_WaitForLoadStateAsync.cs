using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 等待加载状态方法类
    /// </summary>
    [Description("等待加载状态方法配置")]
    public class _PageMethod_WaitForLoadStateAsync
    {
        [Description("加载状态")]
        [JsonPropertyName("_state")]
        public string _state { get; set; }

        [Description("超时时间(毫秒)")]
        [JsonPropertyName("_timeout")]
        public float? _timeout { get; set; }
    }
}
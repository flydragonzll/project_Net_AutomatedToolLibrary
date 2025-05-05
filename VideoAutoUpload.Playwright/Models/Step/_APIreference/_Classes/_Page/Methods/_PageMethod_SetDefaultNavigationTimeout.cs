using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 设置默认导航超时方法类
    /// </summary>
    [Description("设置默认导航超时方法配置")]
    public class _PageMethod_SetDefaultNavigationTimeout
    {
        [Description("超时时间(毫秒)")]
        [JsonPropertyName("_timeout")]
        public float _timeout { get; set; }
    }
}
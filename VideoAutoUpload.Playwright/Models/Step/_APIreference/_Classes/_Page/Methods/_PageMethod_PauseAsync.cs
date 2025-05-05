using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 暂停页面方法类
    /// </summary>
    [Description("暂停页面方法配置")]
    public class _PageMethod_PauseAsync
    {
        [Description("是否暂停")]
        [JsonPropertyName("_isPaused")]
        public bool _isPaused { get; set; }
    }
}
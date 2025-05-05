using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 关闭页面方法类
    /// </summary>
    [Description("关闭页面方法配置")]
    public class _PageMethod_CloseAsync
    {
        [Description("关闭原因")]
        [JsonPropertyName("_reason")]
        public string _reason { get; set; }

        [Description("是否运行 beforeunload 事件")]
        [JsonPropertyName("_runBeforeUnload")]
        public bool _runBeforeUnload { get; set; }
    }
}
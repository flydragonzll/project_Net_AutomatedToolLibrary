using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取框架定位器方法类
    /// </summary>
    [Description("获取框架定位器方法配置")]
    public class _PageMethod_FrameLocator
    {
        [Description("选择器")]
        [JsonPropertyName("_selector")]
        public string _selector { get; set; }

        [Description("框架定位器对象")]
        [JsonPropertyName("_frameLocator")]
        public object _frameLocator { get; set; }
    }
}
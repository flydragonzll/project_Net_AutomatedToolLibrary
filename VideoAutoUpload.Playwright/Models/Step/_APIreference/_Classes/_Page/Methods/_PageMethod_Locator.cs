using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取定位器方法类
    /// </summary>
    [Description("获取定位器方法配置")]
    public class _PageMethod_Locator
    {
        [Description("选择器")]
        [JsonPropertyName("_selector")]
        public string _selector { get; set; }

        [Description("定位器对象")]
        [JsonPropertyName("_locator")]
        public object _locator { get; set; }
    }
}
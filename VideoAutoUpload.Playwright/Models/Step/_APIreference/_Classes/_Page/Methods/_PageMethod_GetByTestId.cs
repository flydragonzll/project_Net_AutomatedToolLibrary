using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 根据测试ID获取元素方法类
    /// </summary>
    [Description("根据测试ID获取元素方法配置")]
    public class _PageMethod_GetByTestId
    {
        [Description("测试ID")]
        [JsonPropertyName("_testId")]
        public string _testId { get; set; }

        [Description("元素对象")]
        [JsonPropertyName("_element")]
        public object _element { get; set; }
    }
}
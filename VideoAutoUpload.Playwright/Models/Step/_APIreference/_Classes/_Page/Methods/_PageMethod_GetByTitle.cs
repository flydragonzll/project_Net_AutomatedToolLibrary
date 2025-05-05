using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 根据标题获取元素方法类
    /// </summary>
    [Description("根据标题获取元素方法配置")]
    public class _PageMethod_GetByTitle
    {
        [Description("标题文本")]
        [JsonPropertyName("_text")]
        public string _text { get; set; }

        [Description("是否精确匹配")]
        [JsonPropertyName("_exact")]
        public bool? _exact { get; set; }

        [Description("元素对象")]
        [JsonPropertyName("_element")]
        public object _element { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 模拟媒体方法类
    /// </summary>
    [Description("模拟媒体方法配置")]
    public class _PageMethod_EmulateMediaAsync
    {
        [Description("媒体类型")]
        [JsonPropertyName("_media")]
        public string _media { get; set; }

        [Description("颜色方案")]
        [JsonPropertyName("_colorScheme")]
        public string _colorScheme { get; set; }

        [Description("减少运动")]
        [JsonPropertyName("_reducedMotion")]
        public string _reducedMotion { get; set; }

        [Description("强制颜色")]
        [JsonPropertyName("_forcedColors")]
        public string _forcedColors { get; set; }

        [Description("对比度")]
        [JsonPropertyName("_contrast")]
        public string _contrast { get; set; }
    }
}
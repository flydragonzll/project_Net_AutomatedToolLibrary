using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 截图方法类
    /// </summary>
    [Description("截图方法配置")]
    public class _PageMethod_ScreenshotAsync
    {
        [Description("截图选项")]
        [JsonPropertyName("_pageScreenshotOptions")]
        public _PageMethod_ScreenshotAsync_PageScreenshotOptions? _pageScreenshotOptions { get; set; } = new _PageMethod_ScreenshotAsync_PageScreenshotOptions();

        [Description("截图内容")]
        [JsonPropertyName("_ret_byteArray")]
        public byte[] _ret_byteArray { get; set; }
    }

    /// <summary>
    /// 截图选项配置类
    /// </summary>
    [Description("截图选项配置")]
    public class _PageMethod_ScreenshotAsync_PageScreenshotOptions
    {
        [Description("是否全屏截图")]
        [JsonPropertyName("fullPage")]
        public bool? FullPage { get; set; }

        [Description("是否省略背景")]
        [JsonPropertyName("omitBackground")]
        public bool? OmitBackground { get; set; }

        [Description("裁剪区域")]
        [JsonPropertyName("clip")]
        public object Clip { get; set; }

        [Description("保存路径")]
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [Description("截图类型")]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [Description("超时时间(毫秒)")]
        [JsonPropertyName("timeout")]
        public float? Timeout { get; set; }

        [Description("动画处理")]
        [JsonPropertyName("animations")]
        public string Animations { get; set; }

        [Description("光标处理")]
        [JsonPropertyName("caret")]
        public string Caret { get; set; }

        [Description("缩放比例")]
        [JsonPropertyName("scale")]
        public string Scale { get; set; }

        [Description("图片质量")]
        [JsonPropertyName("quality")]
        public int? Quality { get; set; }

        [Description("遮罩颜色")]
        [JsonPropertyName("maskColor")]
        public string MaskColor { get; set; }

        [Description("样式")]
        [JsonPropertyName("style")]
        public string Style { get; set; }

        [Description("遮罩")]
        [JsonPropertyName("mask")]
        public object[] Mask { get; set; }
    }
}
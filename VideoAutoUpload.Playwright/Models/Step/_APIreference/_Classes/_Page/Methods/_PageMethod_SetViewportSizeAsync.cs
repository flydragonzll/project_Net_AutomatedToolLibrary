using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 设置视口大小方法类
    /// </summary>
    [Description("设置视口大小方法配置")]
    public class _PageMethod_SetViewportSizeAsync
    {
        [Description("宽度")]
        [JsonPropertyName("_width")]
        public int _width { get; set; }

        [Description("高度")]
        [JsonPropertyName("_height")]
        public int _height { get; set; }
    }
}
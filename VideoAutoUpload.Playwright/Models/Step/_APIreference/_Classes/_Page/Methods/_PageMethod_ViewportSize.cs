using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取视口大小方法类
    /// </summary>
    [Description("获取视口大小方法配置")]
    public class _PageMethod_ViewportSize
    {
        [Description("视口大小")]
        [JsonPropertyName("_viewportSize")]
        public ViewportSize _viewportSize { get; set; }

        /// <summary>
        /// 视口大小类
        /// </summary>
        public class ViewportSize
        {
            [JsonPropertyName("width")]
            public int Width { get; set; }

            [JsonPropertyName("height")]
            public int Height { get; set; }
        }
    }
}
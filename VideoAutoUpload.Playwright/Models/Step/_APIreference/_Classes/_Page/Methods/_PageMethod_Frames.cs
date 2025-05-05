using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取所有框架方法类
    /// </summary>
    [Description("获取所有框架方法配置")]
    public class _PageMethod_Frames
    {
        [Description("框架列表")]
        [JsonPropertyName("_frames")]
        public List<object> _frames { get; set; }
    }
}
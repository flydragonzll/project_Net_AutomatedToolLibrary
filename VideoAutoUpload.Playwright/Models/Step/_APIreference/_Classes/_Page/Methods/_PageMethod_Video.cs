using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 视频录制方法类
    /// </summary>
    [Description("视频录制方法配置")]
    public class _PageMethod_Video
    {
        [Description("视频对象")]
        [JsonPropertyName("_ret_IVideo")]
        public object _ret_IVideo { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 判断页面是否关闭方法类
    /// </summary>
    [Description("判断页面是否关闭方法配置")]
    public class _PageMethod_IsClosed
    {
        [Description("页面是否关闭")]
        [JsonPropertyName("_isClosed")]
        public bool _isClosed { get; set; }
    }
}
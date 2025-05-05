using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取打开页面方法类
    /// </summary>
    [Description("获取打开页面方法配置")]
    public class _PageMethod_OpenerAsync
    {
        [Description("打开页面对象")]
        [JsonPropertyName("_opener")]
        public object _opener { get; set; }
    }
}
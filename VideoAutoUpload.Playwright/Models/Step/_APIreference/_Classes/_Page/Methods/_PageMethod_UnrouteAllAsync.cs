using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 取消所有路由方法类
    /// </summary>
    [Description("取消所有路由方法配置")]
    public class _PageMethod_UnrouteAllAsync
    {
        [Description("取消路由行为")]
        [JsonPropertyName("_behavior")]
        public string _behavior { get; set; }
    }
}
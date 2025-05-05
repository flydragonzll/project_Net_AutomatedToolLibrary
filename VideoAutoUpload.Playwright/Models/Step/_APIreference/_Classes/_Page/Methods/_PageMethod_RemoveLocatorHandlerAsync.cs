using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 移除定位器处理器方法类
    /// </summary>
    [Description("移除定位器处理器方法配置")]
    public class _PageMethod_RemoveLocatorHandlerAsync
    {
        [Description("定位器对象")]
        [JsonPropertyName("_locator")]
        public object _locator { get; set; }
    }
}
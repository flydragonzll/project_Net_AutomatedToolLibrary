using Microsoft.Playwright;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 添加定位器处理器方法类
    /// </summary>
    [Description("添加定位器处理器方法配置")]
    public class _PageMethod_AddLocatorHandlerAsync
    {
        [Description("定位器对象")]
        [JsonPropertyName("_locator")]
        public ILocator _locator { get; set; }

        [Description("处理器函数")]
        [JsonPropertyName("_handler")]
        public Func<Task> _handler { get; set; }

        [Description("添加定位器处理器选项配置")]
        [JsonPropertyName("_pageAddLocatorHandlerOptions")]
        public _PageMethod_AddLocatorHandlerAsync_PageAddLocatorHandlerOptions? _pageAddLocatorHandlerOptions { get; set; } = new _PageMethod_AddLocatorHandlerAsync_PageAddLocatorHandlerOptions();
    }

    /// <summary>
    /// 添加定位器处理器选项配置类
    /// </summary>
    [Description("添加定位器处理器选项配置")]
    public class _PageMethod_AddLocatorHandlerAsync_PageAddLocatorHandlerOptions
    {
        [Description("是否不等待操作完成")]
        [JsonPropertyName("noWaitAfter")]
        public bool? NoWaitAfter { get; set; }

        [Description("处理器触发次数")]
        [JsonPropertyName("times")]
        public int? Times { get; set; }
    }
}
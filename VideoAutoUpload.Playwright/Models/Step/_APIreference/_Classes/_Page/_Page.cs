using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 页面配置类
    /// </summary>
    [Description("页面配置")]
    public class _Page
    {
        [Description("页面方法配置")]
        [JsonPropertyName("_pageMethods")]
        public _PageMethods _pageMethods { get; set; } = new _PageMethods();

        [Description("页面属性配置")]
        [JsonPropertyName("_pageProperties")]
        public _PageProperties _pageProperties { get; set; } = new _PageProperties();

        [Description("页面事件配置")]
        [JsonPropertyName("_PageEvents")]
        public _PageEvents _PageEvents { get; set; } = new _PageEvents();

        [Description("已弃用的页面配置")]
        [JsonPropertyName("_pageDeprecated")]
        public _PageDeprecated _pageDeprecated { get; set; } = new _PageDeprecated();
    }
}
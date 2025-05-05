using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取主框架方法类
    /// </summary>
    [Description("获取主框架方法配置")]
    public class _PageMethod_MainFrame
    {
        [Description("主框架对象")]
        [JsonPropertyName("_mainFrame")]
        public object _mainFrame { get; set; }
    }
}
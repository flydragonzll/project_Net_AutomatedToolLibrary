using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取框架方法类
    /// </summary>
    [Description("获取框架方法配置")]
    public class _PageMethod_Frame
    {
        [Description("框架名称")]
        [JsonPropertyName("_name")]
        public string _name { get; set; }

        [Description("框架对象")]
        [JsonPropertyName("_frame")]
        public object _frame { get; set; }
    }
}
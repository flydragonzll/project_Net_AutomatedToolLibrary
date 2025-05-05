using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 暴露函数方法类
    /// </summary>
    [Description("暴露函数方法配置")]
    public class _PageMethod_ExposeFunctionAsync
    {
        [Description("函数名称")]
        [JsonPropertyName("_name")]
        public string _name { get; set; }

        [Description("回调函数")]
        [JsonPropertyName("_callback")]
        public object _callback { get; set; }
    }
}
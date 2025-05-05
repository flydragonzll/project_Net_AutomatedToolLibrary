using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 暴露绑定方法类
    /// </summary>
    [Description("暴露绑定方法配置")]
    public class _PageMethod_ExposeBindingAsync
    {
        [Description("绑定名称")]
        [JsonPropertyName("_name")]
        public string _name { get; set; }

        [Description("回调函数")]
        [JsonPropertyName("_callback")]
        public object _callback { get; set; }

        [Description("是否需要句柄")]
        [JsonPropertyName("_needsHandle")]
        public bool _needsHandle { get; set; }
    }
}
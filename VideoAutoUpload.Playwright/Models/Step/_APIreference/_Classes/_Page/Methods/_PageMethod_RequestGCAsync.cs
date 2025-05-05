using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 请求垃圾回收方法类
    /// </summary>
    [Description("请求垃圾回收方法配置")]
    public class _PageMethod_RequestGCAsync
    {
        [Description("是否成功")]
        [JsonPropertyName("_success")]
        public bool _success { get; set; }
    }
}
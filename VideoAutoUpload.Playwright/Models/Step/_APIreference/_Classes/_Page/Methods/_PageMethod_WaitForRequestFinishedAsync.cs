using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 等待请求完成方法类
    /// </summary>
    [Description("等待请求完成方法配置")]
    public class _PageMethod_WaitForRequestFinishedAsync
    {
        [Description("请求对象")]
        [JsonPropertyName("_ret_IRequest")]
        public object _ret_IRequest { get; set; }
    }
}
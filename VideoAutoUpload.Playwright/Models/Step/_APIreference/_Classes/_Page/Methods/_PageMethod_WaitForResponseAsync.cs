using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 等待响应方法类
    /// </summary>
    [Description("等待响应方法配置")]
    public class _PageMethod_WaitForResponseAsync
    {
        [Description("响应对象")]
        [JsonPropertyName("_ret_IResponse")]
        public object _ret_IResponse { get; set; }
    }
}
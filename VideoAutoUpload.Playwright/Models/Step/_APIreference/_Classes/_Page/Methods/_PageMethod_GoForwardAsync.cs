using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 前进导航方法类
    /// </summary>
    [Description("前进导航方法配置")]
    public class _PageMethod_GoForwardAsync
    {
        [Description("超时时间(毫秒)")]
        [JsonPropertyName("_timeout")]
        public float? _timeout { get; set; }

        [Description("等待完成条件")]
        [JsonPropertyName("_waitUntil")]
        public string _waitUntil { get; set; }

        [Description("返回的响应对象")]
        [JsonPropertyName("_ret_IResponse")]
        public object _ret_IResponse { get; set; }
    }
}
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 运行并等待响应方法类
    /// </summary>
    [Description("运行并等待响应方法配置")]
    public class _PageMethod_RunAndWaitForResponseAsync
    {
        [Description("操作函数")]
        [JsonPropertyName("_action")]
        public object _action { get; set; }

        [Description("响应对象")]
        [JsonPropertyName("_ret_IResponse")]
        public object _ret_IResponse { get; set; }
    }
}
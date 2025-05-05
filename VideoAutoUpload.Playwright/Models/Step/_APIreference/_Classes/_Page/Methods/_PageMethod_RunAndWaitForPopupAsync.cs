using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 运行并等待弹出窗口方法类
    /// </summary>
    [Description("运行并等待弹出窗口方法配置")]
    public class _PageMethod_RunAndWaitForPopupAsync
    {
        [Description("操作函数")]
        [JsonPropertyName("_action")]
        public object _action { get; set; }

        [Description("弹出窗口对象")]
        [JsonPropertyName("_ret_IPage")]
        public object _ret_IPage { get; set; }
    }
}
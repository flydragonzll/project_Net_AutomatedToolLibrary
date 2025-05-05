using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 运行并等待文件选择器方法类
    /// </summary>
    [Description("运行并等待文件选择器方法配置")]
    public class _PageMethod_RunAndWaitForFileChooserAsync
    {
        [Description("操作函数")]
        [JsonPropertyName("_action")]
        public object _action { get; set; }

        [Description("文件选择器对象")]
        [JsonPropertyName("_ret_IFileChooser")]
        public object _ret_IFileChooser { get; set; }
    }
}
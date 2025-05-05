using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 等待文件选择器方法类
    /// </summary>
    [Description("等待文件选择器方法配置")]
    public class _PageMethod_WaitForFileChooserAsync
    {
        [Description("文件选择器对象")]
        [JsonPropertyName("_ret_IFileChooser")]
        public object _ret_IFileChooser { get; set; }
    }
}
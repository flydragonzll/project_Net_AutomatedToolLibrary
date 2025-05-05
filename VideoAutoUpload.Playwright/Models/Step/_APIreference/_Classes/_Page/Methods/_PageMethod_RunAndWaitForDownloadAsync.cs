using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 运行并等待下载方法类
    /// </summary>
    [Description("运行并等待下载方法配置")]
    public class _PageMethod_RunAndWaitForDownloadAsync
    {
        [Description("操作函数")]
        [JsonPropertyName("_action")]
        public object _action { get; set; }

        [Description("下载对象")]
        [JsonPropertyName("_ret_IDownload")]
        public object _ret_IDownload { get; set; }
    }
}
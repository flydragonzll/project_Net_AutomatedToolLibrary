using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 等待 Worker 方法类
    /// </summary>
    [Description("等待 Worker 方法配置")]
    public class _PageMethod_WaitForWorkerAsync
    {
        [Description("Worker 对象")]
        [JsonPropertyName("_ret_IWorker")]
        public object _ret_IWorker { get; set; }
    }
}
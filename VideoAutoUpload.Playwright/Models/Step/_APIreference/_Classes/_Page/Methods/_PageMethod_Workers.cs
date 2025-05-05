using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取 Worker 列表方法类
    /// </summary>
    [Description("获取 Worker 列表方法配置")]
    public class _PageMethod_Workers
    {
        [Description("Worker 列表")]
        [JsonPropertyName("_workers")]
        public List<object> _workers { get; set; }
    }
}
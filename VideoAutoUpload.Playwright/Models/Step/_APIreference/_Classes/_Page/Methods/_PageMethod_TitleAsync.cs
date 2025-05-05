using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 获取标题方法类
    /// </summary>
    [Description("获取标题方法配置")]
    public class _PageMethod_TitleAsync
    {
        [Description("页面标题")]
        [JsonPropertyName("_title")]
        public string _title { get; set; }
    }
}
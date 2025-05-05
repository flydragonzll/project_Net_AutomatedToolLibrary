using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 将页面带到前端方法类
    /// </summary>
    [Description("将页面带到前端方法配置")]
    public class _PageMethod_BringToFrontAsync
    {
        [Description("是否强制将页面带到前端")]
        [JsonPropertyName("_force")]
        public bool _force { get; set; }
    }
}
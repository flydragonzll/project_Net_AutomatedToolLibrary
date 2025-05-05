using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 设置额外 HTTP 头方法类
    /// </summary>
    [Description("设置额外 HTTP 头方法配置")]
    public class _PageMethod_SetExtraHTTPHeadersAsync
    {
        [Description("HTTP 头信息")]
        [JsonPropertyName("_headers")]
        public List<HeaderEntry> _headers { get; set; } = new List<HeaderEntry>();

        /// <summary>
        /// HTTP 头条目
        /// </summary>
        public class HeaderEntry
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("value")]
            public string Value { get; set; }
        }
    }
}
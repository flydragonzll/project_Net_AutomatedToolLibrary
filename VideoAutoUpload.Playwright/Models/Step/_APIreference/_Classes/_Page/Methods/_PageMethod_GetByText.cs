using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright.Models.Step
{
    public class _PageMethod_GetByText
    {
        [JsonPropertyName("_text")]
        public string _text { get; set; }
        [JsonPropertyName("_pageGetByTextOptions")]
        public _PageMethod_GotoAsync_PageGetByTextOptions? _pageGetByTextOptions { get; set; }
        [JsonPropertyName("_ret_ILocator")]
        public ILocator _ret_ILocator { get; set; }
    }
    public class _PageMethod_GotoAsync_PageGetByTextOptions
    {
        /// <summary>
        /// <para>
        /// Whether to find an exact match: case-sensitive and whole-string. Default to false.
        /// Ignored when locating by a regular expression. Note that exact match still trims
        /// whitespace.
        /// </para>
        /// </summary>
        [JsonPropertyName("exact")]
        public bool? Exact { get; set; }
    }
}

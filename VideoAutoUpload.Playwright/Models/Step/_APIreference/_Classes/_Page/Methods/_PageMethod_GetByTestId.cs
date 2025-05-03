using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright.Models.Step
{
    public class _PageMethod_GetByTestId
    {
        [JsonPropertyName("_testId")]
        public string _testId { get; set; }
        [JsonPropertyName("_ret_ILocator")]
        public ILocator _ret_ILocator { get; set; }
    }
}

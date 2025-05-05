using Microsoft.Playwright;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 添加初始化脚本方法类
    /// </summary>
    [Description("添加初始化脚本方法配置")]
    public class _PageMethod_AddInitScriptAsync
    {
        [Description("脚本内容")]
        [JsonPropertyName("_script")]
        public string _script { get; set; }

        [Description("脚本路径")]
        [JsonPropertyName("_scriptPath")]
        public string _scriptPath { get; set; }
    }
}
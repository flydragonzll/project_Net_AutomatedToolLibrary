using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 拖放操作方法类
    /// </summary>
    [Description("拖放操作方法配置")]
    public class _PageMethod_DragAndDropAsync
    {
        [Description("源选择器")]
        [JsonPropertyName("_source")]
        public string _source { get; set; }

        [Description("目标选择器")]
        [JsonPropertyName("_target")]
        public string _target { get; set; }

        [Description("拖放选项")]
        [JsonPropertyName("_pageDragAndDropOptions")]
        public _PageMethod_DragAndDropAsync_PageDragAndDropOptions? _pageDragAndDropOptions { get; set; } = new _PageMethod_DragAndDropAsync_PageDragAndDropOptions();
    }

    /// <summary>
    /// 拖放选项配置类
    /// </summary>
    [Description("拖放选项配置")]
    public class _PageMethod_DragAndDropAsync_PageDragAndDropOptions
    {
        [Description("是否强制执行")]
        [JsonPropertyName("force")]
        public bool? Force { get; set; }

        [Description("超时时间(毫秒)")]
        [JsonPropertyName("timeout")]
        public float? Timeout { get; set; }

        [Description("是否试运行")]
        [JsonPropertyName("trial")]
        public bool? Trial { get; set; }
    }
}
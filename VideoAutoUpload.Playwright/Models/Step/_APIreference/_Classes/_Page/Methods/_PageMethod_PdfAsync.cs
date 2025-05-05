using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 导出 PDF 方法类
    /// </summary>
    [Description("导出 PDF 方法配置")]
    public class _PageMethod_PdfAsync
    {
        [Description("PDF 文件路径")]
        [JsonPropertyName("_path")]
        public string _path { get; set; }

        [Description("PDF 文件内容")]
        [JsonPropertyName("_content")]
        public byte[] _content { get; set; }

        [Description("PDF 导出选项")]
        [JsonPropertyName("_pagePdfOptions")]
        public _PageMethod_PdfAsync_PagePdfOptions? _pagePdfOptions { get; set; } = new _PageMethod_PdfAsync_PagePdfOptions();
    }

    /// <summary>
    /// PDF 导出选项配置类
    /// </summary>
    [Description("PDF 导出选项配置")]
    public class _PageMethod_PdfAsync_PagePdfOptions
    {
        [Description("缩放比例")]
        [JsonPropertyName("scale")]
        public float? Scale { get; set; }

        [Description("是否显示页眉和页脚")]
        [JsonPropertyName("displayHeaderFooter")]
        public bool? DisplayHeaderFooter { get; set; }

        [Description("是否打印背景")]
        [JsonPropertyName("printBackground")]
        public bool? PrintBackground { get; set; }

        [Description("是否横向")]
        [JsonPropertyName("landscape")]
        public bool? Landscape { get; set; }

        [Description("是否优先使用 CSS 页面大小")]
        [JsonPropertyName("preferCSSPageSize")]
        public bool? PreferCSSPageSize { get; set; }

        [Description("页面范围")]
        [JsonPropertyName("pageRanges")]
        public string PageRanges { get; set; }

        [Description("页眉模板")]
        [JsonPropertyName("headerTemplate")]
        public string HeaderTemplate { get; set; }

        [Description("页脚模板")]
        [JsonPropertyName("footerTemplate")]
        public string FooterTemplate { get; set; }

        [Description("页边距")]
        [JsonPropertyName("margin")]
        public object Margin { get; set; }

        [Description("页面宽度")]
        [JsonPropertyName("width")]
        public string Width { get; set; }

        [Description("页面高度")]
        [JsonPropertyName("height")]
        public string Height { get; set; }

        [Description("是否生成大纲")]
        [JsonPropertyName("outline")]
        public bool? Outline { get; set; }

        [Description("是否生成标签")]
        [JsonPropertyName("tagged")]
        public bool? Tagged { get; set; }
    }
}
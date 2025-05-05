using Microsoft.Playwright;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 根据角色获取元素方法类
    /// </summary>
    [Description("根据角色获取元素方法配置")]
    public class _PageMethod_GetByRole
    {
        [Description("角色名称")]
        [JsonPropertyName("_role")]
        public string _role { get; set; }

        [Description("角色选项")]
        [JsonPropertyName("_pageGetByRoleOptions")]
        public _PageMethod_GetByRole_PageGetByRoleOptions? _pageGetByRoleOptions { get; set; } = new _PageMethod_GetByRole_PageGetByRoleOptions();

        [Description("元素对象")]
        [JsonPropertyName("_element")]
        public object _element { get; set; }
    }

    /// <summary>
    /// 角色选项配置类
    /// </summary>
    [Description("角色选项配置")]
    public class _PageMethod_GetByRole_PageGetByRoleOptions
    {
        [Description("是否精确匹配")]
        [JsonPropertyName("exact")]
        public bool? Exact { get; set; }

        [Description("包含文本")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Description("是否包含子元素")]
        [JsonPropertyName("includeHidden")]
        public bool? IncludeHidden { get; set; }
    }
}

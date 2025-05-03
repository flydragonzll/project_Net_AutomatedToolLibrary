using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace VideoAutoUpload.Playwright.Models.Step
{
    /// <summary>
    /// 页面相关属性配置类
    /// </summary>
    [Description("页面行为控制配置，包含 API 请求、时钟、键盘、鼠标、触摸屏等操作设置")]
    public class _PageProperties
    {
        /// <summary>
        /// API请求相关配置
        /// </summary>
        [Description("用于配置页面中涉及的API请求行为（如拦截、模拟响应等）")]
        [JsonPropertyName("_pagePropertie_APIRequest")]
        public _PagePropertie_APIRequest _pagePropertie_APIRequest { get; set; } = new _PagePropertie_APIRequest();

        /// <summary>
        /// 时钟相关配置
        /// </summary>
        [Description("用于模拟或控制页面中时间相关的功能（如等待、延迟等）")]
        [JsonPropertyName("_pagePropertie_Clock")]
        public _PagePropertie_Clock _pagePropertie_Clock { get; set; } = new _PagePropertie_Clock();

        /// <summary>
        /// 键盘输入相关配置
        /// </summary>
        [Description("用于配置页面中键盘事件的行为（如按键、组合键等）")]
        [JsonPropertyName("_pagePropertie_Keyboard")]
        public _PagePropertie_Keyboard _pagePropertie_Keyboard { get; set; } = new _PagePropertie_Keyboard();

        /// <summary>
        /// 鼠标操作相关配置
        /// </summary>
        [Description("用于配置页面中鼠标点击、悬停、拖拽等行为")]
        [JsonPropertyName("_pagePropertie_Mouse")]
        public _PagePropertie_Mouse _pagePropertie_Mouse { get; set; } = new _PagePropertie_Mouse();

        /// <summary>
        /// 触摸屏操作相关配置
        /// </summary>
        [Description("用于配置页面中模拟触摸屏交互（如滑动、点击等）")]
        [JsonPropertyName("_pagePropertie_Touchscreen")]
        public _PagePropertie_Touchscreen _pagePropertie_Touchscreen { get; set; } = new _PagePropertie_Touchscreen();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VideoAutoUpload.Playwright.Models.Step;

namespace VideoAutoUpload.Playwright.Models
{
    /// <summary>
    /// 平台配置类，包含多个平台的信息
    /// </summary>
    public class PlatformsConfig
    {
        /// <summary>
        /// 平台列表，包含多个平台的详细信息
        /// </summary>
        [JsonPropertyName("platforms")]
        public List<Platform> Platforms { get; set; }
    }

    /// <summary>
    /// 平台类，包含平台名称和该平台下的账户信息
    /// </summary>
    public class Platform
    {
        /// <summary>
        /// 平台名称，例如 "YouTube", "Bilibili" 等
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 该平台下的账户列表，包含每个账户的详细信息
        /// </summary>
        [JsonPropertyName("accounts")]
        public List<Account> Accounts { get; set; }
    }

    /// <summary>
    /// 账户类，包含账户的cookie文件、要上传的视频、操作步骤、错误处理、日志记录和调度信息
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 存储该账户cookie信息的文件路径
        /// </summary>
        [JsonPropertyName("cookieFile")]
        public string CookieFile { get; set; }

        /// <summary>
        /// 要上传的视频列表，包含每个视频的详细信息
        /// </summary>
        [JsonPropertyName("videos")]
        public List<Video> Videos { get; set; }

        /// <summary>
        /// 操作步骤列表，包含一系列的操作步骤信息
        /// </summary>
        [JsonPropertyName("steps")]
        public List<PlatformAccountStep> Steps { get; set; }

        /// <summary>
        /// 错误处理配置，包含重试次数、重试延迟和错误处理策略
        /// </summary>
        [JsonPropertyName("errorHandling")]
        public ErrorHandling ErrorHandling { get; set; }

        /// <summary>
        /// 日志记录配置，包含日志级别和日志文件路径
        /// </summary>
        [JsonPropertyName("logging")]
        public Logging Logging { get; set; }

        /// <summary>
        /// 调度配置，包含任务开始时间和执行频率
        /// </summary>
        [JsonPropertyName("scheduling")]
        public Scheduling Scheduling { get; set; }
    }

    /// <summary>
    /// 视频类，包含视频的文件路径、标题、标签和发布时间
    /// </summary>
    public class Video
    {
        /// <summary>
        /// 视频文件的本地路径
        /// </summary>
        [JsonPropertyName("videoPath")]
        public string VideoPath { get; set; }

        /// <summary>
        /// 视频的标题
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// 视频的标签列表，用于分类和搜索
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// 视频的发布时间，可为空
        /// </summary>
        [JsonPropertyName("publishTime")]
        public DateTime? PublishTime { get; set; }
    }
    #region 废弃
    /// <summary>
    /// 操作步骤类，包含操作类型、URL、等待条件、持续时间、条件判断、选择器、文件路径、值、清空操作和点击次数等信息
    /// </summary>
    //public class Step
    //{
    //    [JsonPropertyName("APIReference")]
    //    public string APIReference { get; set; }
    //    [JsonPropertyName("Classes")]
    //    public string Classes { get; set; }



    //    /// <summary>
    //    /// 操作类型，例如 "click", "input", "upload" 等
    //    /// </summary>
    //    [JsonPropertyName("type")]
    //    public string Type { get; set; }

    //    /// <summary>
    //    /// 操作的URL地址
    //    /// </summary>
    //    [JsonPropertyName("url")]
    //    public string Url { get; set; }

    //    /// <summary>
    //    /// 等待页面加载完成的条件，例如 "load", "domcontentloaded" 等
    //    /// </summary>
    //    [JsonPropertyName("waitUntil")]
    //    public string WaitUntil { get; set; }

    //    /// <summary>
    //    /// 操作的持续时间，单位为毫秒，可为空
    //    /// </summary>
    //    [JsonPropertyName("waitTime")]
    //    public int? WaitTime { get; set; }

    //    /// <summary>
    //    /// 操作的条件判断，例如 "elementExists", "textContains" 等
    //    /// </summary>
    //    [JsonPropertyName("condition")]
    //    public string Condition { get; set; }

    //    /// <summary>
    //    /// 元素选择器，用于定位页面上的元素
    //    /// </summary>
    //    [JsonPropertyName("selector")]
    //    public string Selector { get; set; }

    //    /// <summary>
    //    /// 操作涉及的文件路径，例如上传文件时的文件路径
    //    /// </summary>
    //    [JsonPropertyName("filePath")]
    //    public string FilePath { get; set; }

    //    /// <summary>
    //    /// 操作的值，例如输入框中的文本
    //    /// </summary>
    //    [JsonPropertyName("value")]
    //    public string Value { get; set; }

    //    /// <summary>
    //    /// 在操作前是否清空元素内容，可为空
    //    /// </summary>
    //    [JsonPropertyName("clearBefore")]
    //    public bool? ClearBefore { get; set; }

    //    /// <summary>
    //    /// 点击操作的点击次数，可为空
    //    /// </summary>
    //    [JsonPropertyName("clickCount")]
    //    public int? ClickCount { get; set; }
    //}
    #endregion
    /// <summary>
    /// 错误处理类，包含重试次数、重试延迟和错误处理策略
    /// </summary>
    public class ErrorHandling
    {
        /// <summary>
        /// 发生错误时的重试次数
        /// </summary>
        [JsonPropertyName("retryCount")]
        public int RetryCount { get; set; }

        /// <summary>
        /// 每次重试之间的延迟时间，单位为毫秒
        /// </summary>
        [JsonPropertyName("retryDelay")]
        public int RetryDelay { get; set; }

        /// <summary>
        /// 错误处理策略，例如 "continue", "stop" 等
        /// </summary>
        [JsonPropertyName("onError")]
        public string OnError { get; set; }
    }

    /// <summary>
    /// 日志记录类，包含日志级别和日志文件路径
    /// </summary>
    public class Logging
    {
        /// <summary>
        /// 日志级别，例如 "debug", "info", "error" 等
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; set; }

        /// <summary>
        /// 日志文件的路径
        /// </summary>
        [JsonPropertyName("file")]
        public string File { get; set; }
    }

    /// <summary>
    /// 调度类，包含任务开始时间和执行频率
    /// </summary>
    public class Scheduling
    {
        /// <summary>
        /// 任务开始的时间
        /// </summary>
        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 任务执行的频率，例如 "daily", "weekly" 等
        /// </summary>
        [JsonPropertyName("frequency")]
        public string Frequency { get; set; }
    }
}
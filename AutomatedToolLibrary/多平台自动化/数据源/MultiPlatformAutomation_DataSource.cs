using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoAutoUpload.Playwright.Models;

namespace AutomatedToolLibrary.多平台自动化.数据源
{
    public class MultiPlatformAutomation_Playwright_APIreference_DataSource
    {
        /// <summary>
        /// 存储当前编辑的平台配置数据对象
        /// </summary>
        public static PlatformsConfig platformsConfig;

        /// <summary>
        /// 步骤编号计数器
        /// </summary>
        public static int stepIndex = 1;

        /// <summary>
        /// 视频编号计数器
        /// </summary>
        public static int videoIndex = 1;
        #region 【字段定义】
        /// <summary>
        /// 参考类型数据源（如 Classes）
        /// </summary>
        public static Dictionary<string, string[]> _referenceOptions = new()
        {
            {
                "Classes", new[]
                {
                    "APIRequest", "APIRequestContext", "APIResponse", "Accessibility", "Browser", "BrowserContext",
                    "BrowserType", "CDPSession", "CDPSessionEvent", "Clock", "ConsoleMessage", "Dialog", "Download",
                    "ElementHandle", "FileChooser", "FormData", "Frame", "FrameLocator", "JSHandle", "Keyboard",
                    "Locator", "Mouse", "Page", "Request", "Response", "Route", "Selectors", "TimeoutError", "Touchscreen",
                    "Tracing", "Video", "WebError", "WebSocket", "WebSocketFrame", "WebSocketRoute", "Worker"
                }
            }
        };
        /// <summary>
        /// 非 Page / Mouse 类型的处理方式选项
        /// </summary>
        public static string[] _handlerOptionsOthers = new[] { "Methods", "Events" };
        /// <summary>
        /// 处理方式映射：当种类为 Page 或 Mouse 时显示不同选项
        /// </summary>
        public static Dictionary<string, string[]> _handlerOptionsForPageAndMouse = new()
        {
            {
                "Methods", new[]
                {
                    "AddInitScriptAsync", "AddLocatorHandlerAsync", "AddScriptTagAsync", "AddStyleTagAsync", "BringToFrontAsync",
                    "CloseAsync", "ContentAsync", "Context", "DragAndDropAsync", "EmulateMediaAsync", "EvaluateAsync",
                    "EvaluateHandleAsync", "ExposeBindingAsync", "ExposeFunctionAsync", "Frame", "FrameByUrl", "FrameLocator",
                    "Frames", "GetByAltText", "GetByLabel", "GetByPlaceholder", "GetByRole", "GetByTestId", "GetByText",
                    "GetByTitle", "GoBackAsync", "GoForwardAsync", "GotoAsync", "IsClosed", "Locator", "MainFrame", "OpenerAsync",
                    "PauseAsync", "PdfAsync", "ReloadAsync", "RemoveLocatorHandlerAsync", "RequestGCAsync", "RouteAsync",
                    "RouteFromHARAsync", "RouteWebSocketAsync", "RunAndWaitForConsoleMessageAsync", "WaitForConsoleMessageAsync",
                    "RunAndWaitForDownloadAsync", "WaitForDownloadAsync", "RunAndWaitForFileChooserAsync", "WaitForFileChooserAsync",
                    "RunAndWaitForPopupAsync", "WaitForPopupAsync", "RunAndWaitForRequestAsync", "WaitForRequestAsync",
                    "RunAndWaitForRequestFinishedAsync", "WaitForRequestFinishedAsync", "RunAndWaitForResponseAsync",
                    "WaitForResponseAsync", "RunAndWaitForWebSocketAsync", "WaitForWebSocketAsync", "RunAndWaitForWorkerAsync",
                    "WaitForWorkerAsync", "ScreenshotAsync", "SetContentAsync", "SetDefaultNavigationTimeout", "SetDefaultTimeout",
                    "SetExtraHTTPHeadersAsync", "SetViewportSizeAsync", "TitleAsync", "UnrouteAsync", "UnrouteAllAsync", "Url",
                    "Video", "ViewportSize", "WaitForFunctionAsync", "WaitForLoadStateAsync", "WaitForURLAsync", "Workers"
                }
            },
            // 其他处理方式可以后续扩展
        };


        #endregion

        protected static List<Playwright_APIreference> playwright_APIreference { get; private set; } = new List<Playwright_APIreference>();


        public MultiPlatformAutomation_Playwright_APIreference_DataSource()
        {
            if (!playwright_APIreference.Any())
            {
                //playwright_APIreference.Add(new Playwright_APIreference("APIreference", "Classes", "APIRequest", "", "", "", "API参考", "类", "API请求", "", "", ""));
                
            }
        }
    }
    /// <summary>
    /// "API参考""类""页面","方法","跳转页面","使用方法1"
    /// </summary>
    public class Playwright_APIreference
    {
        public string APIReference1 { get; set; }
        public string APIReference2 { get; set; }
        public string APIReference3 { get; set; }
        public string APIReference4 { get; set; }
        public string APIReference5 { get; set; }
        public string APIReference6 { get; set; }
        public string APIReference1Name { get; set; }
        public string APIReference2Name { get; set; }
        public string APIReference3Name { get; set; }
        public string APIReference4Name { get; set; }
        public string APIReference5Name { get; set; }
        public string APIReference6Name { get; set; }
        /// <summary>
        /// 构造函数用于快速初始化对象
        /// </summary>
        //public Playwright_APIreference(
        //    string ref1, string ref2, string ref3, string ref4, string ref5, string ref6,
        //    string name1, string name2, string name3, string name4, string name5, string name6)
        //{
        //    APIReference1 = ref1;
        //    APIReference2 = ref2;
        //    APIReference3 = ref3;
        //    APIReference4 = ref4;
        //    APIReference5 = ref5;
        //    APIReference6 = ref6;

        //    APIReference1Name = name1;
        //    APIReference2Name = name2;
        //    APIReference3Name = name3;
        //    APIReference4Name = name4;
        //    APIReference5Name = name5;
        //    APIReference6Name = name6;
        //}
    }
}

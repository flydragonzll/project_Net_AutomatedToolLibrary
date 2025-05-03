using AutomatedToolLibrary.多平台自动化;
using Mapster;
using System.ComponentModel;
using System.Reflection;
using VideoAutoUpload;
using VideoAutoUpload.Playwright.Models.Step;

namespace AutomatedToolLibrary
{
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点
        /// </summary>
        /// <remarks>
        /// 该方法初始化应用程序配置并启动主窗体
        /// 如果发生未处理异常，将捕获并显示错误信息
        /// </remarks>
        [STAThread]
        static void Main()
        {
            try
            {
                // 初始化应用程序配置(高DPI设置、默认字体等)
                // 参考: https://aka.ms/applicationconfiguration
                ApplicationConfiguration.Initialize();

                // 启动主窗体
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                // 捕获并处理未预期的异常
                MessageBox.Show($"AutomatedToolLibrary-Program-Main: {ex.Message}",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
using AutomatedToolLibrary.多平台自动化.数据源;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoAutoUpload.Playwright.Models;

namespace AutomatedToolLibrary.多平台自动化
{
    public class Platform_Configuration
    {
        private static Panel panel_平台配置_填充面板;

        public Platform_Configuration(Panel panel_填充面板)
        {
            panel_平台配置_填充面板 = panel_填充面板;
        }

        #region 【界面操作 - 平台管理】

        /// <summary>
        /// 加载所有平台数据到界面控件中
        /// 清除现有控件后重新加载所有平台及其账户信息
        /// </summary>
        public static void PopulateControls()
        {
            panel_平台配置_填充面板.Controls.Clear();
            foreach (var platform in MultiPlatformAutomation_Playwright_APIreference_DataSource.platformsConfig.Platforms)
            {
                AddPlatformControls(platform);
            }
        }

        /// <summary>
        /// 向界面中添加一个平台相关的控件组
        /// 包含平台名称、添加账号按钮、以及该平台下的所有账号
        /// </summary>
        private static void AddPlatformControls(Platform platform)
        {
            GroupBox groupBox_平台管理_平台 = new GroupBox();
            groupBox_平台管理_平台.Text = platform.Name;
            groupBox_平台管理_平台.Dock = DockStyle.Top;

            Button button_平台管理_新增账号 = CreateButton("Add Account", (s, e) => AddAccountControls(platform.Accounts[0], groupBox_平台管理_平台));
            groupBox_平台管理_平台.Controls.Add(button_平台管理_新增账号);

            foreach (var account in platform.Accounts)
            {
                AddAccountControls(account, groupBox_平台管理_平台);
            }

            panel_平台配置_填充面板.Controls.Add(groupBox_平台管理_平台);
        }

        /// <summary>
        /// 向界面中添加一个账号相关的控件组
        /// 包含 Cookie 文件路径输入框、添加视频/步骤按钮等
        /// </summary>
        private static void AddAccountControls(Account account, GroupBox platformGroupBox)
        {
            GroupBox groupBox_账号管理_账号 = new GroupBox();
            groupBox_账号管理_账号.Text = "Account";
            groupBox_账号管理_账号.Dock = DockStyle.Top;

            TextBox textBox_账号管理_Cookie路径 = CreateTextBox(account.CookieFile);
            groupBox_账号管理_账号.Controls.Add(textBox_账号管理_Cookie路径);

            Button button_账号管理_新增视频 = CreateButton("Add Video", (s, e) => Video_Configuration.AddVideoControls(account.Videos[0], groupBox_账号管理_账号));
            groupBox_账号管理_账号.Controls.Add(button_账号管理_新增视频);

            foreach (var video in account.Videos)
            {
                Video_Configuration.AddVideoControls(video, groupBox_账号管理_账号);
            }

            Button button_账号管理_新增步骤 = CreateButton("Add Step", (s, e) => Platform_Step_Configuration.AddStepControls(account.Steps[0], groupBox_账号管理_账号));
            groupBox_账号管理_账号.Controls.Add(button_账号管理_新增步骤);

            foreach (var step in account.Steps)
            {
                Platform_Step_Configuration.AddStepControls(step, groupBox_账号管理_账号);
            }

            platformGroupBox.Controls.Add(groupBox_账号管理_账号);
        }

        #endregion

        /// <summary>
        /// 创建一个按钮控件
        /// </summary>
        /// <param name="text_按钮文本">按钮显示的文本</param>
        /// <param name="eventHandler_点击事件处理程序">按钮点击事件的处理程序</param>
        /// <returns>创建好的按钮控件</returns>
        private static Button CreateButton(string text_按钮文本, EventHandler eventHandler_点击事件处理程序)
        {
            Button button_创建的按钮 = new Button
            {
                Text = text_按钮文本,
                Dock = DockStyle.Top
            };
            button_创建的按钮.Click += eventHandler_点击事件处理程序;
            return button_创建的按钮;
        }

        /// <summary>
        /// 创建一个文本框控件
        /// </summary>
        /// <param name="text_初始文本">文本框的初始文本</param>
        /// <returns>创建好的文本框控件</returns>
        private static TextBox CreateTextBox(string text_初始文本)
        {
            TextBox textBox_创建的文本框 = new TextBox
            {
                Text = text_初始文本,
                Dock = DockStyle.Top
            };
            return textBox_创建的文本框;
        }
    }
}

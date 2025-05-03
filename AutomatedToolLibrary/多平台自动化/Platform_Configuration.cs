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
        private static Panel _panel_Fill;
        public Platform_Configuration(Panel panel_Fill)
        {
            _panel_Fill = panel_Fill;
        }
        #region 【界面操作 - 平台管理】

        /// <summary>
        /// 加载所有平台数据到界面控件中
        /// 清除现有控件后重新加载所有平台及其账户信息
        /// </summary>
        public static void PopulateControls()
        {
            _panel_Fill.Controls.Clear();
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

            Button button_平台管理_新增账号 = new Button();
            button_平台管理_新增账号.Text = "Add Account";
            button_平台管理_新增账号.Click += (s, e) => AddAccountControls(platform.Accounts[0], groupBox_平台管理_平台);
            groupBox_平台管理_平台.Controls.Add(button_平台管理_新增账号);

            foreach (var account in platform.Accounts)
            {
                AddAccountControls(account, groupBox_平台管理_平台);
            }

            _panel_Fill.Controls.Add(groupBox_平台管理_平台);
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

            TextBox textBox_账号管理_Cookie路径 = new TextBox();
            textBox_账号管理_Cookie路径.Text = account.CookieFile;
            textBox_账号管理_Cookie路径.Dock = DockStyle.Top;
            groupBox_账号管理_账号.Controls.Add(textBox_账号管理_Cookie路径);

            Button button_账号管理_新增视频 = new Button();
            button_账号管理_新增视频.Text = "Add Video";
            button_账号管理_新增视频.Click += (s, e) => Video_Configuration.AddVideoControls(account.Videos[0], groupBox_账号管理_账号);
            groupBox_账号管理_账号.Controls.Add(button_账号管理_新增视频);

            foreach (var video in account.Videos)
            {
                Video_Configuration.AddVideoControls(video, groupBox_账号管理_账号);
            }

            Button button_账号管理_新增步骤 = new Button();
            button_账号管理_新增步骤.Text = "Add Step";
            button_账号管理_新增步骤.Click += (s, e) => Platform_Step_Configuration.AddStepControls(account.Steps[0], groupBox_账号管理_账号);
            groupBox_账号管理_账号.Controls.Add(button_账号管理_新增步骤);

            foreach (var step in account.Steps)
            {
                Platform_Step_Configuration.AddStepControls(step, groupBox_账号管理_账号);
            }

            platformGroupBox.Controls.Add(groupBox_账号管理_账号);
        }

        #endregion
    }
}

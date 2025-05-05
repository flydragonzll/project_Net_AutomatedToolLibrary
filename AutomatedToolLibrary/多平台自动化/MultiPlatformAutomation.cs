using AutomatedToolLibrary.多平台自动化.数据源;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoAutoUpload.Playwright.Models;
using VideoAutoUpload.Playwright.Models.Step;
/*
* 控件结构
* *视频选择
* *平台配置
*/
namespace AutomatedToolLibrary.多平台自动化
{
    /// <summary>
    /// 多平台自动化配置界面窗体类，用于加载、编辑和保存多平台任务配置文件（ZLL 格式）
    /// </summary>
    public partial class MultiPlatformAutomation : Form
    {


        #region 【初始化与构造函数】

        /// <summary>
        /// 构造函数：初始化窗体并创建默认空配置
        /// </summary>
        public MultiPlatformAutomation()
        {
            InitializeComponent();
            // 初始化一个包含空平台列表的配置对象
            MultiPlatformAutomation_Playwright_APIreference_DataSource.platformsConfig = new PlatformsConfig { Platforms = new List<Platform>() };
        }
        #endregion
        #region MultiPlatformAutomation_PanelTop
        private void MultiPlatformAutomation_PanelTop_Button加载ZLL文件_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ZLL Files (*.ZLL)|*.ZLL";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                MultiPlatformAutomation_Playwright_APIreference_DataSource.platformsConfig = JsonSerializer.Deserialize<PlatformsConfig>(json);
                //Platform_Configuration.PopulateControls(); // 加载配置到界面上
            }
        }
        private void MultiPlatformAutomation_PanelTop_Button保持ZLL文件_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ZLL Files (*.ZLL)|*.ZLL";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = JsonSerializer.Serialize(MultiPlatformAutomation_Playwright_APIreference_DataSource.platformsConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(saveFileDialog.FileName, json); // 保存到文件
            }
        }

        
        private void MultiPlatformAutomation_PanelTop_Button添加媒体_Click(object sender, EventArgs e)
        {
            TabControl TabControlFill = MultiPlatformAutomation_PanelFill.Controls.OfType<TabControl>().FirstOrDefault();
            if (TabControlFill == null)
            {
                TabControlFill = new TabControl();
                TabControlFill.Dock = DockStyle.Fill;
                MultiPlatformAutomation_PanelFill.Controls.Add(TabControlFill);


                var tabPage1 = new TabPage("视频配置");
                UCVideoConfigList uCVideoConfigList = new UCVideoConfigList();
                uCVideoConfigList.Dock = DockStyle.Fill;
                tabPage1.Controls.Add(uCVideoConfigList);
                TabControlFill.TabPages.Add(tabPage1);
                


                var tabPage2 = new TabPage("媒体选择及操作步骤配置1");
                UCStepConfigList uCStepConfigList = new UCStepConfigList();
                uCStepConfigList.Dock = DockStyle.Fill;
                tabPage2.Controls.Add(uCStepConfigList);
                TabControlFill.TabPages.Add(tabPage2);
            }
            else
            {
                if (TabControlFill.TabPages.Count == 0)
                {
                    var tabPage1 = new TabPage("视频配置");
                    UCVideoConfigList uCVideoConfigList = new UCVideoConfigList();
                    uCVideoConfigList.Dock = DockStyle.Fill;
                    tabPage1.Controls.Add(uCVideoConfigList);
                    TabControlFill.TabPages.Add(tabPage1);

                    var tabPage2 = new TabPage("媒体选择及操作步骤配置1");
                    UCStepConfigList uCStepConfigList = new UCStepConfigList();
                    uCStepConfigList.Dock = DockStyle.Fill;
                    tabPage2.Controls.Add(uCStepConfigList);
                    TabControlFill.TabPages.Add(tabPage2);
                }
                else
                {
                    int nextIndex = TabControlFill.TabPages.Count + 1;
                    var newTabPage = new TabPage($"媒体选择及操作步骤配置 {nextIndex - 1}");
                    UCStepConfigList uCStepConfigList = new UCStepConfigList();
                    uCStepConfigList.Dock = DockStyle.Fill;
                    newTabPage.Controls.Add(uCStepConfigList);
                    TabControlFill.TabPages.Add(newTabPage);
                }
            }
        }
        #endregion MultiPlatformAutomation_PanelTop

    }
}
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

        #region 【主窗体事件】

        /// <summary>
        /// 点击“加载 ZLL”按钮事件处理程序
        /// 功能：打开文件对话框选择 .ZLL 配置文件，并反序列化为对象加载到界面中
        /// </summary>
        private void btnLoadZLL_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ZLL Files (*.ZLL)|*.ZLL";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                MultiPlatformAutomation_Playwright_APIreference_DataSource.platformsConfig = JsonSerializer.Deserialize<PlatformsConfig>(json);
                Platform_Configuration.PopulateControls(); // 加载配置到界面上
            }
        }

        /// <summary>
        /// 点击“保存 ZLL”按钮事件处理程序
        /// 功能：将当前界面上的配置保存为 .ZLL 文件
        /// </summary>
        private void btnSaveZLL_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ZLL Files (*.ZLL)|*.ZLL";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = JsonSerializer.Serialize(MultiPlatformAutomation_Playwright_APIreference_DataSource.platformsConfig, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(saveFileDialog.FileName, json); // 保存到文件
            }
        }

        /// <summary>
        /// 点击“添加平台”按钮事件处理程序
        /// 功能：向配置中添加一个新的平台对象，并在界面中显示
        /// </summary>
        private void btnAddPlatform_Click(object sender, EventArgs e)
        {
            
        }

        #endregion
        #region 【设计模式 - 控件工厂】

        /// <summary>
        /// 工厂方法：根据参考、种类、处理方式创建对应的步骤控件
        /// </summary>
        private Control CreateStepControl(string reference, string category, string handler)
        {
            ComboBox typeComboBox = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            if (reference == "Classes" && category == "Page" && handler == "Methods")
            {
                typeComboBox.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._handlerOptionsForPageAndMouse["Methods"]);
            }
            else
            {
                typeComboBox.Items.Add("待选");
            }

            if (typeComboBox.Items.Count > 0)
                typeComboBox.SelectedIndex = 0;

            return typeComboBox;
        }

        #endregion
        #region MultiPlatformAutomation_PanelTop
        private void MultiPlatformAutomation_PanelTop_Button加载ZLL文件_Click(object sender, EventArgs e)
        {

        }
        private void MultiPlatformAutomation_PanelTop_Button保持ZLL文件_Click(object sender, EventArgs e)
        {

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
                Platform_Step_Configuration.AddStepConfigControls(tabPage2);
                TabControlFill.TabPages.Add(tabPage2);
            }
            else
            {
                if (TabControlFill.TabPages.Count == 0)
                {
                    var tabPage1 = new TabPage("视频配置");
                    Video_Configuration.AddVideoConfigControls(tabPage1);
                    TabControlFill.TabPages.Add(tabPage1);

                    var tabPage2 = new TabPage("媒体选择及操作步骤配置");
                    Platform_Step_Configuration.AddStepConfigControls(tabPage2);
                    TabControlFill.TabPages.Add(tabPage2);
                }
                else
                {
                    int nextIndex = TabControlFill.TabPages.Count + 1;
                    var newTabPage = new TabPage($"媒体选择及操作步骤配置 {nextIndex - 1}");
                    Platform_Step_Configuration.AddStepConfigControls(newTabPage);
                    TabControlFill.TabPages.Add(newTabPage);
                }
            }
        }
        #endregion MultiPlatformAutomation_PanelTop

    }
}
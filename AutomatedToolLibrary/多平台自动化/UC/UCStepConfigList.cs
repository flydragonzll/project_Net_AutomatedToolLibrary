using AutomatedToolLibrary.多平台自动化.数据源;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoAutoUpload.Playwright.Models.Step;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutomatedToolLibrary.多平台自动化
{
    /// <summary>
    /// 步骤配置列表用户控件
    /// 用于管理多个步骤配置的集合
    /// </summary>
    public partial class UCStepConfigList : UserControl
    {
        /// <summary>
        /// 当前选中的平台名称
        /// 不显示在属性窗口中
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ComboBox平台 { set; get; }

        /// <summary>
        /// 步骤列表
        /// 包含所有配置的步骤信息
        /// 不显示在属性窗口中
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PlatformAccountStep> Steps { set; get; }

        /// <summary>
        /// 构造函数
        /// 初始化步骤配置列表控件
        /// </summary>
        public UCStepConfigList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 控件加载事件处理
        /// 初始化平台下拉框和步骤列表
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void UCStepConfigList_Load(object sender, EventArgs e)
        {
            #region ComboBox平台 数据初始化
            // 设置平台下拉框的数据源
            UCStepConfigList_FlowLayoutPanelRight_ComboBox平台.DataSource = MultiPlatformAutomation_Playwright_APIreference_DataSource.GetPlatforms();

            // 如果有预设的平台值，则选中对应项
            if (!string.IsNullOrWhiteSpace(ComboBox平台))
            {
                UCStepConfigList_FlowLayoutPanelRight_ComboBox平台.SelectedItem =
                    UCStepConfigList_FlowLayoutPanelRight_ComboBox平台.Items.Cast<PlatformAccountStep>()
                    .FirstOrDefault(x => x.Equals(ComboBox平台));
            }
            else
            {
                // 否则默认选中第一项
                UCStepConfigList_FlowLayoutPanelRight_ComboBox平台.SelectedIndex = 0;
            }
            #endregion ComboBox平台 数据初始化
            // 创建新的API参考对象
            Playwright_APIreference playwright_APIreference = new Playwright_APIreference();
            //playwright_APIreference.APIReference01 = "_aPIreference";
            // 获取API参考数据
            var playwrightAPIReference = MultiPlatformAutomation_Playwright_APIreference_DataSource.GetPlaywrightAPIReference(playwright_APIreference);
            UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.DataSource = playwrightAPIReference;
            UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.DisplayMember = "APIReference01Name"; // 显示名称
            UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.ValueMember = "APIReference01"; // 绑定值
            UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedIndex = -1;

            // 如果有预设的步骤列表，则加载步骤
            if (null != Steps && Steps.Any())
            {
                // 待实现：加载已有步骤到界面
            }
        }

        /// <summary>
        /// 新增步骤按钮点击事件
        /// 添加一个新的步骤配置
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void UCStepConfigList_FlowLayoutPanelRight_Button新增步骤_Click(object sender, EventArgs e)
        {
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方式.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方法.SelectedValue == null)
            {
                return;
            }
            // 创建新的API参考对象
            Playwright_APIreference playwright_APIreference = new Playwright_APIreference();
            playwright_APIreference.APIReference01 = UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue.ToString();
            playwright_APIreference.APIReference02 = UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.SelectedValue.ToString();
            playwright_APIreference.APIReference03 = UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.SelectedValue.ToString();
            playwright_APIreference.APIReference04 = UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方式.SelectedValue.ToString();
            playwright_APIreference.APIReference05 = UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方法.SelectedValue.ToString();
            // 获取API参考数据
            var playwrightAPIReference = MultiPlatformAutomation_Playwright_APIreference_DataSource.GetPlaywrightAPIReference(playwright_APIreference).FirstOrDefault(p=>string.IsNullOrWhiteSpace(p.APIReference06));
            if (null != playwrightAPIReference)
            {
                UCStepConfig uCStepConfig = new UCStepConfig(playwrightAPIReference._object)
                {
                    Dock = DockStyle.Top,
                    Width = UCStepConfigList_FlowLayoutPanelFill.Width - 25
                };
                uCStepConfig.Height = uCStepConfig.UCStepConfig_PanelFill.Controls.OfType<GroupBox>().Sum(g => g.Height);
                UCStepConfigList_FlowLayoutPanelFill.Controls.Add(uCStepConfig);
            }
        }

        /// <summary>
        /// 接口参考下拉框选择变更事件
        /// 根据选择的接口参考类型加载相关数据
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue == null)
            {
                return;
            }
            // 创建新的API参考对象
            Playwright_APIreference playwright_APIreference = new Playwright_APIreference();
            playwright_APIreference.APIReference01 = UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue.ToString();
            // 获取API参考数据
            var playwrightAPIReference = MultiPlatformAutomation_Playwright_APIreference_DataSource.GetPlaywrightAPIReference(playwright_APIreference);
            UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.DataSource = playwrightAPIReference;
            UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.DisplayMember = "APIReference02Name"; // 显示名称
            UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.ValueMember = "APIReference02"; // 绑定值
            UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.SelectedIndex = -1; // 清空选择
        }
        /// <summary>
        /// 相关配置下拉框选择变更事件
        /// 根据选择的相关配置类型加载数据
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.SelectedValue == null)
            {
                return;
            }
            // 创建新的API参考对象
            Playwright_APIreference playwright_APIreference = new Playwright_APIreference();
            playwright_APIreference.APIReference01 = UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue.ToString();
            playwright_APIreference.APIReference02 = UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.SelectedValue.ToString();
            // 获取API参考数据
            var playwrightAPIReference = MultiPlatformAutomation_Playwright_APIreference_DataSource.GetPlaywrightAPIReference(playwright_APIreference);
            UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.DataSource = playwrightAPIReference;
            UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.DisplayMember = "APIReference03Name"; // 显示名称
            UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.ValueMember = "APIReference03"; // 绑定值
            UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.SelectedIndex = -1; // 清空选择
        }
      
        /// <summary>
        /// 核心功能下拉框选择变更事件
        /// 根据选择的核心功能类型加载数据
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.SelectedValue == null)
            {
                return;
            }
            // 创建新的API参考对象
            Playwright_APIreference playwright_APIreference = new Playwright_APIreference();
            playwright_APIreference.APIReference01 = UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue.ToString();
            playwright_APIreference.APIReference02 = UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.SelectedValue.ToString();
            playwright_APIreference.APIReference03 = UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.SelectedValue.ToString();
            // 获取API参考数据
            var playwrightAPIReference = MultiPlatformAutomation_Playwright_APIreference_DataSource.GetPlaywrightAPIReference(playwright_APIreference);
            UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方式.DataSource = playwrightAPIReference;
            UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方式.DisplayMember = "APIReference04Name"; // 显示名称
            UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方式.ValueMember = "APIReference04"; // 绑定值
            UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方式.SelectedIndex = -1; // 清空选择
        }

       
        private void UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方式_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.SelectedValue == null)
            {
                return;
            }
            if (UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方式.SelectedValue == null)
            {
                return;
            }
            // 创建新的API参考对象
            Playwright_APIreference playwright_APIreference = new Playwright_APIreference();
            playwright_APIreference.APIReference01 = UCStepConfigList_FlowLayoutPanelRight_ComboBox接口参考.SelectedValue.ToString();
            playwright_APIreference.APIReference02 = UCStepConfigList_FlowLayoutPanelRight_ComboBox相关配置.SelectedValue.ToString();
            playwright_APIreference.APIReference03 = UCStepConfigList_FlowLayoutPanelRight_ComboBox核心功能.SelectedValue.ToString();
            playwright_APIreference.APIReference04 = UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方式.SelectedValue.ToString();
            // 获取API参考数据
            var playwrightAPIReference = MultiPlatformAutomation_Playwright_APIreference_DataSource.GetPlaywrightAPIReference(playwright_APIreference);
            UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方法.DataSource = playwrightAPIReference;
            UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方法.DisplayMember = "APIReference05Name"; // 显示名称
            UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方法.ValueMember = "APIReference05"; // 绑定值
            UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方法.SelectedIndex = -1; // 清空选择

        }

        /// <summary>
        /// 实现方法下拉框选择变更事件
        /// 根据选择的实现方法加载数据
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void UCStepConfigList_FlowLayoutPanelRight_ComboBox实现方法_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}

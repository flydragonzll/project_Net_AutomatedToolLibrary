using AutomatedToolLibrary.多平台自动化.数据源;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoAutoUpload.Playwright.Models.Step;

namespace AutomatedToolLibrary.多平台自动化
{
    public class Platform_Step_Configuration
    {
        #region 【界面操作 - 步骤配置】

        /// <summary>
        /// 向 TabPage 中添加步骤配置控件（参考、种类、处理方式、步骤 Type 下拉等）
        /// </summary>
        public static void AddStepConfigControls(TabPage tabPage_步骤配置页)
        {
            Panel panel_步骤配置_主容器 = CreatePanel(DockStyle.Fill, true);

            Panel panel_步骤配置_步骤 = CreatePanel(DockStyle.Fill, false);
            panel_步骤配置_步骤.Padding = new Padding(5);
            panel_步骤配置_步骤.BorderStyle = BorderStyle.FixedSingle;
            panel_步骤配置_主容器.Controls.Add(panel_步骤配置_步骤);

            Panel panel_步骤配置_控制面板 = CreatePanel(DockStyle.Right, false);
            panel_步骤配置_控制面板.Width = 300;
            panel_步骤配置_控制面板.Padding = new Padding(5);
            panel_步骤配置_控制面板.BorderStyle = BorderStyle.FixedSingle;

            // 平台下拉框
            ComboBox comboBox_步骤配置_平台 = CreateComboBox(DockStyle.Top, ComboBoxStyle.DropDownList);
            LoadPlatformComboBox(comboBox_步骤配置_平台);
            panel_步骤配置_控制面板.Controls.Add(comboBox_步骤配置_平台);

            // 参考下拉框
            Label label_步骤配置_参考 = CreateLabel("参考");
            ComboBox comboBox_步骤配置_参考 = CreateComboBox(DockStyle.Top, ComboBoxStyle.DropDownList);
            comboBox_步骤配置_参考.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._referenceOptions.Keys.ToArray());
            comboBox_步骤配置_参考.SelectedIndex = 0;
            panel_步骤配置_控制面板.Controls.Add(label_步骤配置_参考);
            panel_步骤配置_控制面板.Controls.Add(comboBox_步骤配置_参考);

            // 种类下拉框
            Label label_步骤配置_种类 = CreateLabel("种类");
            ComboBox comboBox_步骤配置_种类 = CreateComboBox(DockStyle.Top, ComboBoxStyle.DropDownList);
            comboBox_步骤配置_种类.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._referenceOptions["Classes"]);
            comboBox_步骤配置_种类.SelectedIndex = 0;
            panel_步骤配置_控制面板.Controls.Add(label_步骤配置_种类);
            panel_步骤配置_控制面板.Controls.Add(comboBox_步骤配置_种类);

            // 处理方式下拉框
            Label label_步骤配置_处理方式 = CreateLabel("处理方式");
            ComboBox comboBox_步骤配置_处理方式 = CreateComboBox(DockStyle.Top, ComboBoxStyle.DropDownList);
            UpdateHandlerComboBox(comboBox_步骤配置_处理方式, comboBox_步骤配置_种类.SelectedItem?.ToString() ?? "");
            panel_步骤配置_控制面板.Controls.Add(label_步骤配置_处理方式);
            panel_步骤配置_控制面板.Controls.Add(comboBox_步骤配置_处理方式);

            // 新增步骤按钮
            Button button_步骤配置_新增步骤 = CreateButton("新增步骤", (s, e) =>
            {
                if (string.IsNullOrEmpty(comboBox_步骤配置_参考.Text))
                    MessageBox.Show("请选择参考");
                else if (string.IsNullOrEmpty(comboBox_步骤配置_种类.Text))
                    MessageBox.Show("请选择种类");
                else if (string.IsNullOrEmpty(comboBox_步骤配置_处理方式.Text))
                    MessageBox.Show("请选择处理方式");
                else
                {
                    AddStepRow(panel_步骤配置_步骤, comboBox_步骤配置_参考.Text, comboBox_步骤配置_种类.Text, comboBox_步骤配置_处理方式.Text);
                }
            });
            panel_步骤配置_控制面板.Controls.Add(button_步骤配置_新增步骤);

            // 注册种类变化事件，更新处理方式下拉内容
            comboBox_步骤配置_种类.SelectedIndexChanged += (s, e) =>
            {
                UpdateHandlerComboBox(comboBox_步骤配置_处理方式, comboBox_步骤配置_种类.SelectedItem?.ToString() ?? "");
            };

            // 添加控件到界面
            panel_步骤配置_主容器.Controls.Add(panel_步骤配置_控制面板);
            tabPage_步骤配置页.Controls.Add(panel_步骤配置_主容器);
        }

        /// <summary>
        /// 加载平台下拉项（抖音、快手）
        /// </summary>
        private static void LoadPlatformComboBox(ComboBox comboBox_平台下拉框)
        {
            comboBox_平台下拉框.Items.Clear();
            comboBox_平台下拉框.Items.Add("抖音");
            comboBox_平台下拉框.Items.Add("快手");
            if (comboBox_平台下拉框.Items.Count > 0)
                comboBox_平台下拉框.SelectedIndex = 0;
        }

        /// <summary>
        /// 更新处理方式下拉框（根据种类判断是否为 Page/Mouse）
        /// </summary>
        private static void UpdateHandlerComboBox(ComboBox handlerComboBox_处理方式下拉框, string selectedCategory_选择的种类)
        {
            handlerComboBox_处理方式下拉框.Items.Clear();

            if (selectedCategory_选择的种类 == "Page" || selectedCategory_选择的种类 == "Mouse")
            {
                handlerComboBox_处理方式下拉框.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._handlerOptionsForPageAndMouse.Keys.ToArray());
            }
            else
            {
                handlerComboBox_处理方式下拉框.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._handlerOptionsOthers);
            }

            if (handlerComboBox_处理方式下拉框.Items.Count > 0)
                handlerComboBox_处理方式下拉框.SelectedIndex = 0;
        }

        /// <summary>
        /// 向面板中新增一个步骤配置行（GroupBox + Type 下拉框）
        /// </summary>
        private static void AddStepRow(Panel panel_步骤配置面板, string reference_参考, string category_种类, string handler_处理方式)
        {
            GroupBox groupBox_步骤配置_步骤 = new GroupBox();
            groupBox_步骤配置_步骤.Text = $"步骤{MultiPlatformAutomation_Playwright_APIreference_DataSource.stepIndex++}";
            groupBox_步骤配置_步骤.Dock = DockStyle.Top;
            groupBox_步骤配置_步骤.AutoSize = true;
            groupBox_步骤配置_步骤.Padding = new Padding(5);

            ComboBox comboBox_步骤配置_Type = CreateComboBox(DockStyle.Top, ComboBoxStyle.DropDownList);

            if (reference_参考 == "Classes" && category_种类 == "Page" && handler_处理方式 == "Methods")
            {
                comboBox_步骤配置_Type.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._handlerOptionsForPageAndMouse["Methods"]);
            }
            else
            {
                comboBox_步骤配置_Type.Items.Add("待选");
            }

            if (comboBox_步骤配置_Type.Items.Count > 0)
                comboBox_步骤配置_Type.SelectedIndex = 0;

            groupBox_步骤配置_步骤.Controls.Add(comboBox_步骤配置_Type);
            panel_步骤配置面板.Controls.Add(groupBox_步骤配置_步骤);
        }

        /// <summary>
        /// 向界面中添加一个操作步骤（Step）相关的控件组
        /// 包含步骤类型、URL 等字段
        /// </summary>
        public static void AddStepControls(PlatformAccountStep step_步骤配置, GroupBox accountGroupBox_账号组框)
        {
            GroupBox groupBox_步骤配置_步骤 = new GroupBox();
            groupBox_步骤配置_步骤.Text = "Step";
            groupBox_步骤配置_步骤.Dock = DockStyle.Top;

            //TextBox textBox_步骤配置_Type = new TextBox();
            //textBox_步骤配置_Type.Text = step.Type;
            //textBox_步骤配置_Type.Dock = DockStyle.Top;
            //groupBox_步骤配置_步骤.Controls.Add(textBox_步骤配置_Type);

            //TextBox textBox_步骤配置_Url = new TextBox();
            //textBox_步骤配置_Url.Text = step.Url;
            //textBox_步骤配置_Url.Dock = DockStyle.Top;
            //groupBox_步骤配置_步骤.Controls.Add(textBox_步骤配置_Url);

            accountGroupBox_账号组框.Controls.Add(groupBox_步骤配置_步骤);
        }

        #endregion

        /// <summary>
        /// 创建一个面板控件
        /// </summary>
        /// <param name="dockStyle_停靠样式">面板的停靠样式</param>
        /// <param name="autoScroll_是否自动滚动">面板是否支持自动滚动</param>
        /// <returns>创建好的面板控件</returns>
        private static Panel CreatePanel(DockStyle dockStyle_停靠样式, bool autoScroll_是否自动滚动)
        {
            Panel panel_创建的面板 = new Panel
            {
                Dock = dockStyle_停靠样式,
                AutoScroll = autoScroll_是否自动滚动
            };
            return panel_创建的面板;
        }

        /// <summary>
        /// 创建一个标签控件
        /// </summary>
        /// <param name="text_标签文本">标签显示的文本</param>
        /// <returns>创建好的标签控件</returns>
        private static Label CreateLabel(string text_标签文本)
        {
            Label label_创建的标签 = new Label
            {
                Text = text_标签文本,
                AutoSize = true,
                Dock = DockStyle.Top
            };
            return label_创建的标签;
        }

        /// <summary>
        /// 创建一个组合框控件
        /// </summary>
        /// <param name="dockStyle_停靠样式">组合框的停靠样式</param>
        /// <param name="comboBoxStyle_组合框样式">组合框的样式</param>
        /// <returns>创建好的组合框控件</returns>
        private static ComboBox CreateComboBox(DockStyle dockStyle_停靠样式, ComboBoxStyle comboBoxStyle_组合框样式)
        {
            ComboBox comboBox_创建的组合框 = new ComboBox
            {
                Dock = dockStyle_停靠样式,
                DropDownStyle = comboBoxStyle_组合框样式
            };
            return comboBox_创建的组合框;
        }

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
                Dock = DockStyle.Top,
                Margin = new Padding(0, 5, 0, 0)
            };
            button_创建的按钮.Click += eventHandler_点击事件处理程序;
            return button_创建的按钮;
        }
    }
}
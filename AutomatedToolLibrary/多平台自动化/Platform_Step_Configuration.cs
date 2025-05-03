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
        public static void AddStepConfigControls(TabPage tabPage)
        {
            Panel panel_步骤配置_主容器 = new Panel();
            panel_步骤配置_主容器.Dock = DockStyle.Fill;
            panel_步骤配置_主容器.AutoScroll = true;

            Panel panel_步骤配置_步骤 = new Panel();
            panel_步骤配置_步骤.Dock = DockStyle.Fill;
            panel_步骤配置_步骤.AutoSize = true;
            panel_步骤配置_步骤.Padding = new Padding(5);
            panel_步骤配置_步骤.BorderStyle = BorderStyle.FixedSingle;
            panel_步骤配置_主容器.Controls.Add(panel_步骤配置_步骤);

            Panel panel_步骤配置_控制面板 = new Panel();
            panel_步骤配置_控制面板.Width = 300;
            panel_步骤配置_控制面板.Dock = DockStyle.Right;
            panel_步骤配置_控制面板.AutoSize = false;
            panel_步骤配置_控制面板.Padding = new Padding(5);
            panel_步骤配置_控制面板.BorderStyle = BorderStyle.FixedSingle;

            // 平台下拉框
            ComboBox comboBox_步骤配置_平台 = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            LoadPlatformComboBox(comboBox_步骤配置_平台);
            panel_步骤配置_控制面板.Controls.Add(comboBox_步骤配置_平台);

            // 参考下拉框
            Label label_步骤配置_参考 = new Label { Text = "参考", AutoSize = true, Dock = DockStyle.Top };
            ComboBox comboBox_步骤配置_参考 = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBox_步骤配置_参考.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._referenceOptions.Keys.ToArray());
            comboBox_步骤配置_参考.SelectedIndex = 0;
            panel_步骤配置_控制面板.Controls.Add(label_步骤配置_参考);
            panel_步骤配置_控制面板.Controls.Add(comboBox_步骤配置_参考);

            // 种类下拉框
            Label label_步骤配置_种类 = new Label { Text = "种类", AutoSize = true, Dock = DockStyle.Top };
            ComboBox comboBox_步骤配置_种类 = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBox_步骤配置_种类.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._referenceOptions["Classes"]);
            comboBox_步骤配置_种类.SelectedIndex = 0;
            panel_步骤配置_控制面板.Controls.Add(label_步骤配置_种类);
            panel_步骤配置_控制面板.Controls.Add(comboBox_步骤配置_种类);

            // 处理方式下拉框
            Label label_步骤配置_处理方式 = new Label { Text = "处理方式", AutoSize = true, Dock = DockStyle.Top };
            ComboBox comboBox_步骤配置_处理方式 = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            UpdateHandlerComboBox(comboBox_步骤配置_处理方式, comboBox_步骤配置_种类.SelectedItem?.ToString() ?? "");
            panel_步骤配置_控制面板.Controls.Add(label_步骤配置_处理方式);
            panel_步骤配置_控制面板.Controls.Add(comboBox_步骤配置_处理方式);

            // 新增步骤按钮
            Button button_步骤配置_新增步骤 = new Button
            {
                Text = "新增步骤",
                Dock = DockStyle.Top,
                Margin = new Padding(0, 5, 0, 0)
            };
            button_步骤配置_新增步骤.Click += (s, e) =>
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
            };
            panel_步骤配置_控制面板.Controls.Add(button_步骤配置_新增步骤);

            // 注册种类变化事件，更新处理方式下拉内容
            comboBox_步骤配置_种类.SelectedIndexChanged += (s, e) =>
            {
                UpdateHandlerComboBox(comboBox_步骤配置_处理方式, comboBox_步骤配置_种类.SelectedItem?.ToString() ?? "");
            };

            // 添加控件到界面
            panel_步骤配置_主容器.Controls.Add(panel_步骤配置_控制面板);
            tabPage.Controls.Add(panel_步骤配置_主容器);
        }

        /// <summary>
        /// 加载平台下拉项（抖音、快手）
        /// </summary>
        private static void LoadPlatformComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("抖音");
            comboBox.Items.Add("快手");
            if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 更新处理方式下拉框（根据种类判断是否为 Page/Mouse）
        /// </summary>
        private static void UpdateHandlerComboBox(ComboBox handlerComboBox, string selectedCategory)
        {
            handlerComboBox.Items.Clear();

            if (selectedCategory == "Page" || selectedCategory == "Mouse")
            {
                handlerComboBox.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._handlerOptionsForPageAndMouse.Keys.ToArray());
            }
            else
            {
                handlerComboBox.Items.AddRange(MultiPlatformAutomation_Playwright_APIreference_DataSource._handlerOptionsOthers);
            }

            if (handlerComboBox.Items.Count > 0)
                handlerComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 向面板中新增一个步骤配置行（GroupBox + Type 下拉框）
        /// </summary>
        private static void AddStepRow(Panel panel, string reference, string category, string handler)
        {
            GroupBox groupBox_步骤配置_步骤 = new GroupBox();
            groupBox_步骤配置_步骤.Text = $"步骤{MultiPlatformAutomation_Playwright_APIreference_DataSource.stepIndex++}";
            groupBox_步骤配置_步骤.Dock = DockStyle.Top;
            groupBox_步骤配置_步骤.AutoSize = true;
            groupBox_步骤配置_步骤.Padding = new Padding(5);

            ComboBox comboBox_步骤配置_Type = new ComboBox
            {
                Dock = DockStyle.Top,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            if (reference == "Classes" && category == "Page" && handler == "Methods")
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
            panel.Controls.Add(groupBox_步骤配置_步骤);
        }

        /// <summary>
        /// 向界面中添加一个操作步骤（Step）相关的控件组
        /// 包含步骤类型、URL 等字段
        /// </summary>
        public static void AddStepControls(PlatformAccountStep step, GroupBox accountGroupBox)
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

            accountGroupBox.Controls.Add(groupBox_步骤配置_步骤);
        }

        #endregion
    }
}

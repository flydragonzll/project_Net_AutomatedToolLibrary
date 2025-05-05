using AutomatedToolLibrary.多平台自动化.数据源;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoAutoUpload.Playwright.Models.Step;


namespace AutomatedToolLibrary.多平台自动化
{
    /// <summary>
    /// 步骤配置用户控件
    /// 用于显示和编辑单个步骤的配置信息
    /// </summary>
    public partial class UCStepConfig : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object StepConfig { get; set; }
        /// <summary>
        /// 构造函数
        /// 初始化步骤配置控件
        /// </summary>
        public UCStepConfig()
        {
            InitializeComponent();
        }
        public UCStepConfig(object stepConfig)
        {
            InitializeComponent();
            StepConfig = stepConfig;
            if (null == StepConfig) return;
            // 反射获取属性值
            try
            {
                Type type01 = StepConfig.GetType();
                foreach (PropertyInfo property01 in type01.GetProperties())
                {
                    object value01 = property01.GetValue(StepConfig);
                    string propertyName01 = property01.Name;

                    // 获取 DescriptionAttribute
                    var descriptionAttribute01 = (DescriptionAttribute)Attribute.GetCustomAttribute(property01, typeof(DescriptionAttribute));
                    string description01 = descriptionAttribute01?.Description ?? "无描述";
                    if (value01 != null && !property01.PropertyType.IsPrimitive && !MultiPlatformAutomation_Playwright_APIreference_DataSource.DefaultDataType.Contains(MultiPlatformAutomation_Playwright_APIreference_DataSource.DataTypeRet(property01.PropertyType.ToString())))
                    {
                        ProcessNestedProperties(value01, UCStepConfig_PanelFill);
                    }
                    else
                    {
                        CreateControlForProperty(property01, value01, UCStepConfig_PanelFill,true);
                    }
                }
            }
            catch (Exception ex)
            {
                // 处理异常
                MessageBox.Show($"发生错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UCStepConfig_Load(object sender, EventArgs e)
        {
           
        }
        //1. 根据属性描述和数据类型创建控件
        //实现步骤：
        //使用反射获取 property01 的 DescriptionAttribute 和数据类型。
        //根据描述生成一个 Label 控件，显示属性名或描述。
        //根据不同的数据类型（如 string, int, bool 等）动态创建对应的编辑控件（如 TextBox, NumericUpDown, CheckBox 等）。
        //所有控件放置在 GroupBox1 中。
        //最后将 GroupBox1 添加到 UCStepConfig_FlowLayoutPanelFill 中。
        private Control CreateControlForProperty(PropertyInfo property, object value, Panel panel,bool teShu = false)
        {
            string propertyName = property.Name;
            var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(property, typeof(DescriptionAttribute));
            string description = descriptionAttribute?.Description ?? propertyName;

            // 根据数据类型创建不同控件
            Control inputControl = null;
            Type propertyType = property.PropertyType;

            if (propertyType == typeof(string))
            {
                TextBox textBox = new TextBox();
                textBox.Dock = DockStyle.Top;
                textBox.Text = value?.ToString() ?? "";
                textBox.Tag = property; // 用于后续保存
                textBox.PlaceholderText = description; // 使用占位符提示
                inputControl = textBox;
            }
            else if (propertyType == typeof(float) || propertyType == typeof(int) || propertyType == typeof(double) || propertyType.IsPrimitive)
            {
                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Dock = DockStyle.Top;
                numericUpDown.Value = Convert.ToDecimal(value ?? 0);
                numericUpDown.Tag = property;
                inputControl = numericUpDown;
            }
            else if (propertyType == typeof(bool))
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Dock = DockStyle.Top;
                checkBox.Checked = Convert.ToBoolean(value);
                checkBox.Tag = property;
                checkBox.Text = description; // 设置CheckBox的文本
                inputControl = checkBox;
            }
            // 新增：处理 WaitUntilState 数据类型
            else if (propertyType == typeof(WaitUntilState))
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Dock = DockStyle.Top;
                comboBox.Items.AddRange(Enum.GetNames(typeof(WaitUntilState)));
                comboBox.SelectedItem = value?.ToString();
                comboBox.Tag = property;
                inputControl = comboBox;
            }

            if (inputControl != null && teShu)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Dock = DockStyle.Top;
                groupBox.Text = description;
                groupBox.AutoSize = true;
                groupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                groupBox.Controls.Add(inputControl);
                groupBox.Height = inputControl.Height + 20;
                // 添加悬浮提示
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(inputControl, description);

                panel.Controls.Add(groupBox);
            }
            return inputControl;
        }
        //2.递归处理嵌套对象
        //如果满足条件（即属性是一个复杂类型），则递归创建 GroupBox2、GroupBox3 等
        private void ProcessNestedProperties(object obj, Panel parentPanel)
        {
            if (obj == null) return;
            GroupBox groupBox = new GroupBox();
            groupBox.Dock = DockStyle.Top;
            groupBox.Text = "子变量配置";
            groupBox.AutoSize = true;
            groupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Type type = obj.GetType();
            foreach (PropertyInfo property in type.GetProperties())
            {
                object value = property.GetValue(obj);
                Type propertyType = property.PropertyType;

                if (!propertyType.IsPrimitive && !MultiPlatformAutomation_Playwright_APIreference_DataSource.DefaultDataType.Contains(MultiPlatformAutomation_Playwright_APIreference_DataSource.DataTypeRet(propertyType.ToString())))
                {
                    GroupBox groupBox1 = new GroupBox();
                    groupBox1.Dock = DockStyle.Top;
                    groupBox1.Text = property.Name;
                    groupBox1.AutoSize = true;
                    groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                    Panel Panel = new Panel();
                    Panel.Dock = DockStyle.Fill;
                    groupBox1.Controls.Add(Panel);
                    groupBox.Controls.Add(groupBox1);
                    ProcessNestedProperties(value, Panel); // 递归
                    groupBox1.Height = Panel.Controls.OfType<Control>().Sum(g => g.Height) + 20; // 更新 GroupBox1 的高度
                }
                else
                {
                    groupBox.Controls.Add(CreateControlForProperty(property, value, parentPanel));
                    groupBox.Height = groupBox.Controls.OfType<Control>().Sum(c => c.Height) + 20; // 更新 GroupBox 的高度
                }
            }
            parentPanel.Controls.Add(groupBox);

        }
        public void SaveStepConfig()
        {
            if (StepConfig == null) return;

            Type type = StepConfig.GetType();
            foreach (Control control in UCStepConfig_PanelFill.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    foreach (Control innerControl in groupBox.Controls)
                    {
                        if (innerControl is Label label)
                        {
                            string propertyName = label.Text;
                            PropertyInfo property = type.GetProperty(propertyName);

                            if (property != null)
                            {
                                foreach (Control inputControl in groupBox.Controls)
                                {
                                    if (inputControl.Tag is PropertyInfo prop && prop == property)
                                    {
                                        object value = null;
                                        if (inputControl is TextBox textBox)
                                            value = textBox.Text;
                                        else if (inputControl is NumericUpDown numericUpDown)
                                            value = Convert.ChangeType(numericUpDown.Value, property.PropertyType);
                                        else if (inputControl is CheckBox checkBox)
                                            value = checkBox.Checked;

                                        if (value != null)
                                            property.SetValue(StepConfig, value);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    /// <summary>
    /// 步骤配置实体类
    /// 包含步骤的基本配置信息
    /// </summary>
    public class StepConfig
    {
        /// <summary>
        /// 步骤名称标签
        /// 用于显示步骤的名称
        /// </summary>
        public string StepName_Lable { get; set; }

        /// <summary>
        /// 步骤类型
        /// 标识步骤的类别，如"点击"、"输入"等
        /// </summary>
        public string StepType { get; set; }

        /// <summary>
        /// 步骤描述
        /// 详细说明步骤的功能和用途
        /// </summary>
        public string StepDescription { get; set; }

        /// <summary>
        /// 步骤参数
        /// 步骤执行所需的参数配置
        /// </summary>
        public string StepParameters { get; set; }

        /// <summary>
        /// 步骤结果
        /// 步骤执行后的输出或结果
        /// </summary>
        public string StepResult { get; set; }
    }
}


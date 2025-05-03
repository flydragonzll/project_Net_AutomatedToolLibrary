using AutomatedToolLibrary.组件类;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatedToolLibrary.多平台自动化
{
    public partial class UCVideoConfig : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int VideoIndex
        {
            get
            {
                return int.Parse(UCVideoConfig_GroupBox配置视频.Text.Replace("请配置第_", "").Replace("_个视频", ""));
            }
            set
            {
                UCVideoConfig_GroupBox配置视频.Text = $"请配置第{value}个视频";
            }
        }
        #region UCVideoConfig_GroupBox配置视频_Panel功能选项 属性
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CheckBox标题AI优化
        {
            get
            {
                return UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标题AI优化.Checked;
            }
            set
            {
                UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标题AI优化.Checked = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CheckBox对比标题
        {
            get
            {
                return UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox对比标题.Checked;
            }
            set
            {
                UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox对比标题.Checked = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CheckBox标签AI生成
        {
            get
            {
                return UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标签AI生成.Checked;
            }
            set
            {
                UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标签AI生成.Checked = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CheckBox删除选择
        {
            get
            {
                return UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox删除选择.Checked;
            }
            private set { }
        }
        #endregion UCVideoConfig_GroupBox配置视频_Panel功能选项 属性
        public UCVideoConfig()
        {
            InitializeComponent();
        }
        public UCVideoConfig(bool checkBox功能批量配置, bool checkBox标题AI优化, bool checkBox对比标题, bool checkBox标签AI生成)
        {
            InitializeComponent();
            if (checkBox功能批量配置)
            {
                UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标题AI优化.Visible = false;
                UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox对比标题.Visible = false;
                UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标签AI生成.Visible = false;
            }
            CheckBox标题AI优化 = checkBox标题AI优化;
            CheckBox对比标题 = checkBox对比标题;
            CheckBox标签AI生成 = checkBox标签AI生成;
        }
        #region UCVideoConfig_GroupBox配置视频_Panel功能选项
        private void UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标题AI优化_CheckedChanged(object sender, EventArgs e)
        {
            if (UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标题AI优化.Checked)
            {
                this.CheckBox标题AI优化 = true;
            }
            else
            {
                this.CheckBox标题AI优化 = false;
            }
        }

        private void UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox对比标题_CheckedChanged(object sender, EventArgs e)
        {
            if (UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox对比标题.Checked)
            {
                this.CheckBox对比标题 = true;
            }
            else
            {
                this.CheckBox对比标题 = false;
            }
        }

        private void UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标签AI生成_CheckedChanged(object sender, EventArgs e)
        {
            if (UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标签AI生成.Checked)
            {
                this.CheckBox标签AI生成 = true;
            }
            else
            {
                this.CheckBox标签AI生成 = false;
            }
        }
        private void UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox删除选择_CheckedChanged(object sender, EventArgs e)
        {
            if (UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox删除选择.Checked)
            {
                this.CheckBox删除选择 = true;
            }
            else
            {
                this.CheckBox删除选择 = false;
            }
        }
        #endregion UCVideoConfig_GroupBox配置视频_Panel功能选项
        #region UCVideoConfig_GroupBox配置视频_GroupBox视频路径
        /// <summary>
        /// 获取视频路径配置
        /// </summary>
        private static string MyVideosPath = ConfigurationManager.AppSettings["MyVideosPath"];
        private static string MyVideosTags = ConfigurationManager.AppSettings["MyVideosTags"];
        private void UCVideoConfig_GroupBox配置视频_GroupBox视频路径_Button选择视频_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "选择视频文件";
                    openFileDialog.Filter = "视频文件|*.mp4";
                    if (!string.IsNullOrEmpty(MyVideosPath))
                        openFileDialog.InitialDirectory = MyVideosPath;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (Funtions.UpdateConfiguration("MyVideosPath", Path.GetDirectoryName(openFileDialog.FileName)))
                        {
                            this.UCVideoConfig_GroupBox配置视频_GroupBox视频路径_TextBox视频路径.Text = openFileDialog.FileName;
                            GroupBox_Add_MultiSelectTextBox(UCVideoConfig_GroupBox配置视频_GroupBox标题_FlowLayoutPanelFill, "标题", Path.GetFileNameWithoutExtension(openFileDialog.FileName));
                            if (null != MyVideosTags)
                            {
                                foreach (string tag in MyVideosTags.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    GroupBox_Add_MultiSelectTextBox(UCVideoConfig_GroupBox配置视频_GroupBox标签_FlowLayoutPanelFill, "标签", tag);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("保存视频路径配置失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择视频文件时出错，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region 新增组件 MultiSelectTextBox
        private void GroupBox_Add_MultiSelectTextBox(FlowLayoutPanel flowLayoutPanel, string leiXing, string text)
        {
            bool isScrollVisible = false;
            // 创建 MultiSelectTextBox
            MultiSelectTextBox multiSelectTextBox = new MultiSelectTextBox();
            multiSelectTextBox.Text = text;
            multiSelectTextBox.ShowCompareButton = CheckBox对比标题;
            switch (leiXing)
            {
                case "标题":
                    isScrollVisible = flowLayoutPanel.Controls.Count * multiSelectTextBox.Height > flowLayoutPanel.Height;
                    multiSelectTextBox.Width = flowLayoutPanel.Width - (isScrollVisible ? 36 : 20);
                    if (flowLayoutPanel.Controls.Count == 0)
                    {
                        multiSelectTextBox.Checked = true;
                    }

                    break;
                case "标签":
                    if (flowLayoutPanel.Controls.Count < 5)
                    {
                        multiSelectTextBox.Checked = true;
                    }
                    break;
                default:

                    break;
            }
            // 添加到 GroupBox
            flowLayoutPanel.Controls.Add(multiSelectTextBox);
        }
        #endregion 新增组件 MultiSelectTextBox
        #endregion UCVideoConfig_GroupBox配置视频_GroupBox视频路径
    }
}

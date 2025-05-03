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

        public UCVideoConfig()
        {
            InitializeComponent();
        }
        #region UCVideoConfig_GroupBox配置视频_Panel功能选项
        private void UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标题AI优化_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox对比标题_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UCVideoConfig_GroupBox配置视频_Panel功能选项_CheckBox标签AI生成_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion UCVideoConfig_GroupBox配置视频_Panel功能选项
        /// <summary>
        /// 获取视频路径配置
        /// </summary>
        private static string 默认视频路径 = ConfigurationManager.AppSettings["MyVideosPath"];
        private void UCVideoConfig_GroupBox配置视频_GroupBox视频路径_Button选择视频_Click(object sender, EventArgs e)
        {

        }
    }
}

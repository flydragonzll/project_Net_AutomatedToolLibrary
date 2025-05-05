using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatedToolLibrary.多平台自动化
{
    public partial class UCVideoConfigList : UserControl
    {
        public UCVideoConfigList()
        {
            InitializeComponent();
        }
        private void UCVideoConfigList_PanelFill_FlowLayoutPanelFill_SizeChanged(object sender, EventArgs e)
        {
            if (UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Count == 0)
                return;

            var ucVideoConfig = (UCVideoConfig)UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls[0];

            bool isScrollVisible = UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Count * ucVideoConfig.Height > UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Height;
            // 更新控件显示的序号
            for (int i = 0; i < UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Count; i++)
            {
                ucVideoConfig = (UCVideoConfig)UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls[i];
                ucVideoConfig.Width = UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Width - (isScrollVisible ? 36 : 20);
            }
        }
        #region UCVideoConfigList_PanelRight_FlowLayoutPanelFill
        private void UCVideoConfigList_PanelRight_FlowLayoutPanelFill_CheckBox功能批量配置_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UCVideoConfigList_PanelRight_FlowLayoutPanelFill_Button新增_Click(object sender, EventArgs e)
        {
            UCVideoConfig ucVideoConfig = new UCVideoConfig();
            ucVideoConfig.VideoIndex = 1;
            bool isScrollVisible = UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Count * ucVideoConfig.Height > UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Height;
            ucVideoConfig.Width = UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Width - (isScrollVisible ? 36 : 20);
            ucVideoConfig.MouseDown += UCVideoConfig_MouseDown;
            ucVideoConfig.MouseMove += UCVideoConfig_MouseMove;
            ucVideoConfig.MouseUp += UCVideoConfig_MouseUp;
            UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Add(ucVideoConfig);
        }
        #region UCVideoConfig 绑定事件
        private UCVideoConfig draggedUCVideoConfig;
        private Point offset;
        private bool isDragging;
        private void UCVideoConfig_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                draggedUCVideoConfig = (UCVideoConfig)sender;
                offset = e.Location;
                isDragging = true;
            }
        }

        private void UCVideoConfig_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = draggedUCVideoConfig.Location;
                newLocation.Y += e.Y - offset.Y;
                draggedUCVideoConfig.Location = newLocation;
            }
        }

        private void UCVideoConfig_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;

                // 根据拖拽后的位置更新控件顺序
                UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Remove(draggedUCVideoConfig);
                int insertIndex = 0;
                foreach (Control control in UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls)
                {
                    if (control.Top > draggedUCVideoConfig.Top)
                    {
                        break;
                    }
                    insertIndex++;
                }
                UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Add(draggedUCVideoConfig);
                UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.SetChildIndex(draggedUCVideoConfig, insertIndex);

                // 更新控件显示的序号
                for (int i = 0; i < UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Count; i++)
                {
                    UCVideoConfig ucVideoConfig = (UCVideoConfig)UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls[i];
                    ucVideoConfig.VideoIndex = i + 1;
                }
            }
        }
        #endregion UCVideoConfig 绑定事件
        private void UCVideoConfigList_PanelRight_FlowLayoutPanelFill_Button删除_Click(object sender, EventArgs e)
        {
            int count = UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Count;
            // 删除选中的控件
            for (int i = 0; i < count; i++)
            {
                UCVideoConfig ucVideoConfig = (UCVideoConfig)UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls[i];
                if (ucVideoConfig.CheckBox删除选择)
                {
                    UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Remove(ucVideoConfig);
                }
            }
            // 更新控件显示的序号
            for (int i = 0; i < UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls.Count; i++)
            {
                UCVideoConfig ucVideoConfig = (UCVideoConfig)UCVideoConfigList_PanelFill_FlowLayoutPanelFill.Controls[i];
                ucVideoConfig.VideoIndex = i + 1;
            }
        }
        #endregion UCVideoConfigList_PanelRight_FlowLayoutPanelFill

        
    }
}

namespace AutomatedToolLibrary.多平台自动化
{
    partial class UCStepConfig
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            UCStepConfig_PanelFill = new Panel();
            SuspendLayout();
            // 
            // UCStepConfig_PanelFill
            // 
            UCStepConfig_PanelFill.AutoScroll = true;
            UCStepConfig_PanelFill.Dock = DockStyle.Fill;
            UCStepConfig_PanelFill.Location = new Point(0, 0);
            UCStepConfig_PanelFill.Name = "UCStepConfig_PanelFill";
            UCStepConfig_PanelFill.Size = new Size(354, 106);
            UCStepConfig_PanelFill.TabIndex = 0;
            // 
            // UCStepConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(UCStepConfig_PanelFill);
            Name = "UCStepConfig";
            Size = new Size(354, 106);
            Load += UCStepConfig_Load;
            ResumeLayout(false);
        }

        #endregion

        public Panel UCStepConfig_PanelFill;
    }
}

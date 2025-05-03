namespace AutomatedToolLibrary.多平台自动化
{
    partial class MultiPlatformAutomation
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            btnLoadZLL = new Button();
            btnSaveZLL = new Button();
            btnAddPlatform = new Button();
            panel_Fill = new Panel();
            panel_Top = new Panel();
            panel_Top.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadZLL
            // 
            btnLoadZLL.Location = new Point(12, 12);
            btnLoadZLL.Name = "btnLoadZLL";
            btnLoadZLL.Size = new Size(100, 23);
            btnLoadZLL.TabIndex = 0;
            btnLoadZLL.Text = "加载ZLL文件";
            btnLoadZLL.UseVisualStyleBackColor = true;
            btnLoadZLL.Click += btnLoadZLL_Click;
            // 
            // btnSaveZLL
            // 
            btnSaveZLL.Location = new Point(118, 12);
            btnSaveZLL.Name = "btnSaveZLL";
            btnSaveZLL.Size = new Size(100, 23);
            btnSaveZLL.TabIndex = 1;
            btnSaveZLL.Text = "保存ZLL文件";
            btnSaveZLL.UseVisualStyleBackColor = true;
            btnSaveZLL.Click += btnSaveZLL_Click;
            // 
            // btnAddPlatform
            // 
            btnAddPlatform.Location = new Point(224, 12);
            btnAddPlatform.Name = "btnAddPlatform";
            btnAddPlatform.Size = new Size(100, 23);
            btnAddPlatform.TabIndex = 2;
            btnAddPlatform.Text = "添加媒体";
            btnAddPlatform.UseVisualStyleBackColor = true;
            btnAddPlatform.Click += btnAddPlatform_Click;
            // 
            // panel_Fill
            // 
            panel_Fill.Dock = DockStyle.Fill;
            panel_Fill.Location = new Point(0, 46);
            panel_Fill.Name = "panel_Fill";
            panel_Fill.Size = new Size(854, 597);
            panel_Fill.TabIndex = 3;
            // 
            // panel_Top
            // 
            panel_Top.Controls.Add(btnAddPlatform);
            panel_Top.Controls.Add(btnSaveZLL);
            panel_Top.Controls.Add(btnLoadZLL);
            panel_Top.Dock = DockStyle.Top;
            panel_Top.Location = new Point(0, 0);
            panel_Top.Name = "panel_Top";
            panel_Top.Size = new Size(854, 46);
            panel_Top.TabIndex = 4;
            // 
            // MultiPlatformAutomation
            // 
            ClientSize = new Size(854, 643);
            Controls.Add(panel_Fill);
            Controls.Add(panel_Top);
            Name = "MultiPlatformAutomation";
            Text = "视频上传配置工具";
            panel_Top.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadZLL;
        private System.Windows.Forms.Button btnSaveZLL;
        private System.Windows.Forms.Button btnAddPlatform;
        private Panel panel_Fill;
        private Panel panel_Top;
    }
}
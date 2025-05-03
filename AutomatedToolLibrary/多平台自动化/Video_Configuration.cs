using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoAutoUpload.Playwright.Models;

namespace AutomatedToolLibrary.多平台自动化
{
    public class Video_Configuration
    { /// <summary>
      /// 获取视频路径配置
      /// </summary>
        private static string MyVideosPath = ConfigurationManager.AppSettings["MyVideosPath"];
        #region 【界面操作 - 视频配置】

        /// <summary>
        /// 向 TabPage 中添加视频配置控件（标题、标签、路径等）
        /// </summary>
        public static void AddVideoConfigControls(TabPage tabPage)
        {
            Panel panel_视频配置_容器 = new Panel();
            panel_视频配置_容器.Dock = DockStyle.Fill;
            panel_视频配置_容器.AutoScroll = true;

            AddVideoRow(panel_视频配置_容器);

            tabPage.Controls.Add(panel_视频配置_容器);
        }

        /// <summary>
        /// 新增一行视频配置（包括路径、标题、标签、发布时间等）
        /// </summary>
        private static void AddVideoRow(Panel panel)
        {
            int currentVideoCount = panel.Controls.OfType<GroupBox>().Count() + 1;

            GroupBox groupBox_视频配置_视频 = new GroupBox();
            groupBox_视频配置_视频.Text = $"视频{currentVideoCount}";
            groupBox_视频配置_视频.Dock = DockStyle.Top;
            groupBox_视频配置_视频.AutoSize = true;
            groupBox_视频配置_视频.Padding = new Padding(5);

            // 删除按钮行
            FlowLayoutPanel flowLayoutPanel_视频配置_删除行 = new FlowLayoutPanel();
            flowLayoutPanel_视频配置_删除行.AutoSize = true;
            flowLayoutPanel_视频配置_删除行.Dock = DockStyle.Top;
            flowLayoutPanel_视频配置_删除行.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Button button_视频配置_删除 = new Button { Text = "删除" };
            button_视频配置_删除.Click += (s, e) =>
            {
                var parent = groupBox_视频配置_视频.Parent;
                groupBox_视频配置_视频.Dispose();

                int index = 1;
                foreach (Control control in parent.Controls.OfType<GroupBox>())
                {
                    control.Text = $"视频{index++}";
                }
            };
            flowLayoutPanel_视频配置_删除行.Controls.Add(button_视频配置_删除);

            Button button_视频配置_新增 = new Button();
            button_视频配置_新增.Text = "新增";
            button_视频配置_新增.Click += (s, e) => AddVideoRow(panel);
            flowLayoutPanel_视频配置_删除行.Controls.Add(button_视频配置_新增);

            groupBox_视频配置_视频.Controls.Add(flowLayoutPanel_视频配置_删除行);

            // 发布时间行
            TableLayoutPanel tableLayoutPanel_视频配置_发布时间 = CreateTwoColumnLayout("发布时间");
            DateTimePicker dateTimePicker_视频配置_发布时间 = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Dock = DockStyle.Fill
            };
            tableLayoutPanel_视频配置_发布时间.Controls.Add(dateTimePicker_视频配置_发布时间, 1, 0);
            groupBox_视频配置_视频.Controls.Add(tableLayoutPanel_视频配置_发布时间);

            // 标签行
            TableLayoutPanel tableLayoutPanel_视频配置_标签 = CreateTwoColumnLayout("标签");
            TextBox textBox_视频配置_标签 = new TextBox { Dock = DockStyle.Fill };
            tableLayoutPanel_视频配置_标签.Controls.Add(textBox_视频配置_标签, 1, 0);
            groupBox_视频配置_视频.Controls.Add(tableLayoutPanel_视频配置_标签);

            // 标题行
            TableLayoutPanel tableLayoutPanel_视频配置_标题 = CreateTwoColumnLayout("标题");
            TextBox textBox_视频配置_标题 = new TextBox { Dock = DockStyle.Fill };
            tableLayoutPanel_视频配置_标题.Controls.Add(textBox_视频配置_标题, 1, 0);
            groupBox_视频配置_视频.Controls.Add(tableLayoutPanel_视频配置_标题);

            // 视频路径行
            TableLayoutPanel tableLayoutPanel_视频配置_视频路径 = CreateThreeColumnLayout("视频路径", "选择视频");
            TextBox textBox_视频配置_视频路径 = new TextBox { Dock = DockStyle.Fill };
            Button button_视频配置_选择视频 = new Button { Text = "选择视频", Width = 80, Dock = DockStyle.Fill };

            tableLayoutPanel_视频配置_视频路径.Controls.Add(textBox_视频配置_视频路径, 1, 0);
            tableLayoutPanel_视频配置_视频路径.Controls.Add(button_视频配置_选择视频, 2, 0);
            groupBox_视频配置_视频.Controls.Add(tableLayoutPanel_视频配置_视频路径);

            // 绑定点击事件
            button_视频配置_选择视频.Click += (s, e) =>
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
                                textBox_视频配置_视频路径.Text = openFileDialog.FileName;
                                textBox_视频配置_标题.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                                textBox_视频配置_标签.Text = "";
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
            };

            // 添加到面板
            panel.Controls.Add(groupBox_视频配置_视频);
        }

        /// <summary>
        /// 创建两列布局的 TableLayoutPanel（Label + Control）
        /// </summary>
        private static TableLayoutPanel CreateTwoColumnLayout(string labelText)
        {
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Top;
            layout.AutoSize = false;
            layout.Height = 35;
            layout.ColumnCount = 2;
            layout.RowCount = 1;

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Label label = new Label
            {
                Text = labelText,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            };

            layout.Controls.Add(label, 0, 0);
            return layout;
        }

        /// <summary>
        /// 创建三列布局的 TableLayoutPanel（Label + Control + Button）
        /// </summary>
        private static TableLayoutPanel CreateThreeColumnLayout(string labelText, string buttonText)
        {
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Top;
            layout.AutoSize = false;
            layout.Height = 35;
            layout.ColumnCount = 3;
            layout.RowCount = 1;

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Label label = new Label
            {
                Text = labelText,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            };

            layout.Controls.Add(label, 0, 0);
            return layout;
        }

        /// <summary>
        /// 向界面中添加一个视频相关的控件组
        /// 包含视频路径、标题、标签、发布时间等字段
        /// </summary>
        public static void AddVideoControls(Video video, GroupBox accountGroupBox)
        {
            GroupBox groupBox_视频配置_视频 = new GroupBox();
            groupBox_视频配置_视频.Text = "Video";
            groupBox_视频配置_视频.Dock = DockStyle.Top;

            TextBox textBox_视频配置_视频路径 = new TextBox();
            textBox_视频配置_视频路径.Text = video.VideoPath;
            groupBox_视频配置_视频.Controls.Add(textBox_视频配置_视频路径);

            TextBox textBox_视频配置_标题 = new TextBox();
            textBox_视频配置_标题.Text = video.Title;
            groupBox_视频配置_视频.Controls.Add(textBox_视频配置_标题);

            TextBox textBox_视频配置_标签 = new TextBox();
            textBox_视频配置_标签.Text = string.Join(",", video.Tags);
            groupBox_视频配置_视频.Controls.Add(textBox_视频配置_标签);

            DateTimePicker dateTimePicker_视频配置_发布时间 = new DateTimePicker();
            dateTimePicker_视频配置_发布时间.Value = video.PublishTime ?? DateTime.Now;
            groupBox_视频配置_视频.Controls.Add(dateTimePicker_视频配置_发布时间);

            accountGroupBox.Controls.Add(groupBox_视频配置_视频);
        }

        #endregion
    }
}

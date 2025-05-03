using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedToolLibrary.组件类
{
    [ToolboxItem(true)]
    public partial class MultiSelectTextBox : UserControl
    {
        [Category("Appearance")]
        [Description("是否选择")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Checked
        {
            get { return checkBox.Checked; }
            set { checkBox.Checked = value; }
        }

        [Category("Appearance")]
        [Description("是否显示对比按钮")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowCompareButton
        {
            get { return showCompareButton; }
            set
            {
                showCompareButton = value;
                compareButton.Visible = showCompareButton;
            }
        }
        [Category("Appearance")]
        [Description("文本")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        private CheckBox checkBox;
        private TextBox textBox;
        private Button compareButton;
        private string oldText;
        private bool showCompareButton = true;
        private Form tooltipForm;

        public MultiSelectTextBox()
        {
            InitializeComponent();

            checkBox = new CheckBox();
            checkBox.Location = new Point(5, 5);
            checkBox.Size = new Size(15, 15);
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            this.Controls.Add(checkBox);

            textBox = new TextBox();
            textBox.Location = new Point(25, 3);
            textBox.Size = new Size(150, 20);
            textBox.Enabled = false;
            textBox.TextChanged += TextBox_TextChanged;
            this.Controls.Add(textBox);

            compareButton = new Button();
            compareButton.Text = "对比";
            compareButton.Location = new Point(180, 3);
            compareButton.Size = new Size(60, 20);
            compareButton.Click += CompareButton_Click;
            compareButton.MouseLeave += CompareButton_MouseLeave;
            compareButton.Visible = showCompareButton;
            this.Controls.Add(compareButton);
        }


        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            textBox.Enabled = checkBox.Checked;
            if (!checkBox.Checked)
            {
                textBox.Text = oldText;
            }
            else
            {
                oldText = textBox.Text;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // 这里可以添加文本变化时的其他逻辑
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            string newText = textBox.Text;

            if (tooltipForm != null)
            {
                tooltipForm.Close();
                tooltipForm.Dispose();
            }

            tooltipForm = new Form();
            tooltipForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            tooltipForm.BackColor = SystemColors.Info;
            tooltipForm.ShowInTaskbar = false;
            tooltipForm.TopMost = true;

            tooltipForm.Paint += (s, pe) =>
            {
                using (var g = pe.Graphics)
                {
                    // 检查字体是否有效
                    if (tooltipForm.Font == null)
                    {
                        MessageBox.Show("Font is null!");
                        return;
                    }

                    // 绘制旧文本
                    g.DrawString(oldText, tooltipForm.Font, Brushes.Black, 5, 5);

                    // 绘制新文本
                    g.DrawString(newText, tooltipForm.Font, Brushes.Black, 5, 25);
                }
            };

            var size = MeasureTextSize(oldText, newText, tooltipForm.Font);
            tooltipForm.Size = new Size(size.Width + 300, size.Height + 45);

            Point location = compareButton.PointToScreen(compareButton.Location);
            tooltipForm.Location = location;
            tooltipForm.Show();
        }

        private void CompareButton_MouseLeave(object sender, EventArgs e)
        {
            if (tooltipForm != null)
            {
                tooltipForm.Close();
                tooltipForm.Dispose();
            }
        }

        private Size MeasureTextSize(string oldText, string newText, Font font)
        {
            int width = Math.Max(TextRenderer.MeasureText(oldText, font).Width, TextRenderer.MeasureText(newText, font).Width);
            int height = 2 * TextRenderer.MeasureText("A", font).Height + 5;

            return new Size(width, height);
        }
    }
}
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace AutomatedToolLibrary
{
    /// <summary>
    /// 自动化工具库主窗体
    /// </summary>
    /// <remarks>
    /// 提供视频自动上传等功能
    /// 包含与用户交互的界面元素和业务逻辑
    /// </remarks>
    public partial class Tools : Form
    {
        private readonly string _logFile = "app.log";

        /// <summary>
        /// 初始化Tools窗体
        /// </summary>
        public Tools()
        {
            try
            {
                InitializeComponent();
                Log("应用程序初始化完成");
                textBox_视频自动上传_浏览器.Text = BrowserExecutablePath + "\\chrome.exe";
            }
            catch (Exception ex)
            {
                LogError("窗体初始化失败", ex);
                throw;
            }
        }

        /// <summary>
        /// 记录信息日志
        /// </summary>
        /// <param name="message">日志消息</param>
        private void Log(string message)
        {
            File.AppendAllText(_logFile,
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO: {message}{Environment.NewLine}",
                Encoding.UTF8);
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="ex">异常对象</param>
        private void LogError(string message, Exception ex)
        {
            File.AppendAllText(_logFile,
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message} - {ex}{Environment.NewLine}",
                Encoding.UTF8);
        }
        #region 视频自动上传
        private string BrowserExecutablePath = ConfigurationManager.AppSettings["BrowserExecutablePath"];
        private void button_视频自动上传_浏览器_Click(object sender, EventArgs e)
        {
            try
            {
                Log("开始选择浏览器运行程序");
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "选择浏览器运行程序";
                    openFileDialog.Filter = "浏览器运行程序|*.exe";
                    openFileDialog.InitialDirectory = BrowserExecutablePath;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Log($"用户选择了浏览器运行程序: {openFileDialog.FileName}");

                        if (UpdateConfiguration("BrowserExecutablePath", openFileDialog.InitialDirectory))
                        {
                            textBox_视频自动上传_浏览器.Text = openFileDialog.FileName;
                        }
                    }
                    else
                    {
                        Log("用户取消了文件选择");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("选择视频文件时出错", ex);
                MessageBox.Show("选择视频文件时出错，请重试", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string MyVideosPath = ConfigurationManager.AppSettings["MyVideosPath"];

        /// <summary>
        /// 处理视频路径选择按钮点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void button_视频自动上传_选择视频路径_Click(object sender, EventArgs e)
        {
            try
            {
                Log("开始选择视频文件");

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "选择视频文件";
                    openFileDialog.Filter = "视频文件|*.mp4";
                    openFileDialog.InitialDirectory = MyVideosPath;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Log($"用户选择了视频文件: {openFileDialog.FileName}");

                        if (UpdateConfiguration("MyVideosPath", openFileDialog.InitialDirectory))
                        {
                            textBox_视频自动上传_视频路径.Text = openFileDialog.FileName;

                            if (openFileDialog.FileNames.Any())
                            {
                                textBox_视频自动上传_标题.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                                if (checkBox_视频自动上传_AI优化标题.Checked)
                                {
                                    // TODO: 实现AI标题优化功能
                                }

                                textBox_视频自动上传_标签.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("保存视频路径配置失败", "警告",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        Log("用户取消了文件选择");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("选择视频文件时出错", ex);
                MessageBox.Show("选择视频文件时出错，请重试", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 处理视频上传按钮点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">事件参数</param>
        private void button_视频自动上传_上传_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_视频自动上传_视频路径.Text))
                {
                    MessageBox.Show("请先选择视频文件", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!File.Exists(textBox_视频自动上传_视频路径.Text))
                {
                    MessageBox.Show("指定的视频文件不存在", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Log($"开始上传视频: {textBox_视频自动上传_视频路径.Text}");

                // 获取GroupBox中所有选中的CheckBox控件
                var selectedCheckBoxes = groupBox_视频自动上传_上传平台选择.Controls
                    .OfType<CheckBox>()
                    .Where(cb => cb.Checked)
                    .ToList();

                if (selectedCheckBoxes.Count == 0)
                {
                    MessageBox.Show("请至少选择一个上传平台", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<string> platformList = selectedCheckBoxes.Select(cb => cb.Tag.ToString()).ToList();
                string browserPath = textBox_视频自动上传_浏览器.Text;
                string videoPath = textBox_视频自动上传_视频路径.Text;
                string title = textBox_视频自动上传_标题.Text;
                string tags = textBox_视频自动上传_标签.Text;
                new VideoAutoUpload.Playwright.Main().Run(platformList, browserPath, videoPath, title, tags);

                Log("视频上传任务已启动");
                MessageBox.Show("视频上传任务已开始", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogError("视频上传失败", ex);
                MessageBox.Show($"视频上传失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion 视频自动上传

        #region 通用方法
        /// <summary>
        /// 更新应用程序配置
        /// </summary>
        /// <param name="key">配置键</param>
        /// <param name="value">配置值</param>
        /// <returns>是否成功更新配置</returns>
        private bool UpdateConfiguration(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (configFile.AppSettings.Settings[key] == null)
                {
                    configFile.AppSettings.Settings.Add(key, value);
                    Log($"添加新配置项: {key}={value}");
                }
                else
                {
                    configFile.AppSettings.Settings[key].Value = value;
                    Log($"更新配置项: {key}={value}");
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch (ConfigurationErrorsException ex)
            {
                LogError($"配置更新失败(配置错误): {key}={value}", ex);
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                LogError($"配置更新失败(权限不足): {key}={value}", ex);
                return false;
            }
            catch (Exception ex)
            {
                LogError($"配置更新失败: {key}={value}", ex);
                return false;
            }
        }
        #endregion 通用方法


    }
}

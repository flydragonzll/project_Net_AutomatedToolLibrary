using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright
{
    /// <summary>
    /// 项目全局配置
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// 项目基础目录
        /// </summary>
        public static string BaseDir { get; } = Directory.GetCurrentDirectory();

        /// <summary>
        /// Chrome浏览器可执行文件路径
        /// </summary>
        public static string LocalChromePath { get; } = "";

        /// <summary>
        /// 小红书签名服务地址
        /// </summary>
        public static string XhsServer { get; } = "http://localhost:5000";

        /// <summary>
        /// 获取文件绝对路径
        /// </summary>
        public static string GetAbsolutePath(string relativePath, string subFolder)
        {
            var path = Path.Combine(BaseDir, subFolder, relativePath);
            return Path.GetFullPath(path);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright
{
    /// <summary>
    /// 提供文件时间相关的实用方法
    /// </summary>
    internal static class FileTimeUtils
    {
        /// <summary>
        /// 获取文件的最后修改时间
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>DateTime对象表示最后修改时间</returns>
        /// <exception cref="FileNotFoundException">当文件不存在时抛出</exception>
        public static DateTime GetFileLastWriteTime(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"文件不存在: {filePath}");
            }

            return File.GetLastWriteTime(filePath);
        }

        /// <summary>
        /// 获取文件的创建时间
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>DateTime对象表示创建时间</returns>
        /// <exception cref="FileNotFoundException">当文件不存在时抛出</exception>
        public static DateTime GetFileCreationTime(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"文件不存在: {filePath}");
            }

            return File.GetCreationTime(filePath);
        }

        /// <summary>
        /// 格式化时间为指定格式的字符串
        /// </summary>
        /// <param name="dateTime">DateTime对象</param>
        /// <param name="format">格式字符串(默认:yyyy-MM-dd HH:mm:ss)</param>
        /// <returns>格式化后的时间字符串</returns>
        public static string FormatDateTime(DateTime dateTime, string format = "yyyy-MM-dd HH:mm:ss")
        {
            return dateTime.ToString(format);
        }

        /// <summary>
        /// 获取文件的绝对路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        /// <param name="subFolder">子文件夹名称</param>
        /// <returns>绝对路径字符串</returns>
        public static string GetAbsolutePath(string relativePath, string subFolder)
        {
            var baseDir = AppContext.BaseDirectory;
            var fullPath = Path.Combine(baseDir, subFolder, relativePath);
            return Path.GetFullPath(fullPath);
        }
    }
}
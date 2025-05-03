using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright
{
    /// <summary>
    /// 提供日志记录功能，支持多种日志级别
    /// </summary>
    public static class LogUtils
    {
        private static ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            //builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information);
        });

        private static ILogger _logger = _loggerFactory.CreateLogger("SocialAutoUpload");

        /// <summary>
        /// 记录信息级别日志
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        public static void Info(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        /// <summary>
        /// 记录成功级别日志
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        public static void Success(string message, params object[] args)
        {
            _logger.LogInformation("[SUCCESS] " + message, args);
        }

        /// <summary>
        /// 记录错误级别日志
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        public static void Error(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        /// <summary>
        /// 记录警告级别日志
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="args">格式化参数</param>
        public static void Warning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        /// <summary>
        /// 配置日志系统
        /// </summary>
        /// <param name="configure">配置委托</param>
        public static void Configure(Action<ILoggingBuilder> configure)
        {
            _loggerFactory = LoggerFactory.Create(configure);
            _logger = _loggerFactory.CreateLogger("SocialAutoUpload");
        }
    }
}

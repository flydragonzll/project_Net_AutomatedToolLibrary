using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedToolLibrary
{
    public class Funtions
    {
        #region 【通用工具方法】



        /// <summary>
        /// 更新应用程序配置
        /// </summary>
        /// <param name="key">配置键</param>
        /// <param name="value">配置值</param>
        /// <returns>是否成功更新配置</returns>
        public static bool UpdateConfiguration(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (configFile.AppSettings.Settings[key] == null)
                {
                    configFile.AppSettings.Settings.Add(key, value);
                }
                else
                {
                    configFile.AppSettings.Settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}

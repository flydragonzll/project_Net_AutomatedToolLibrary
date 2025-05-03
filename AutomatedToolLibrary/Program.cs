using AutomatedToolLibrary.多平台自动化;
using Mapster;
using System.ComponentModel;
using System.Reflection;
using VideoAutoUpload;
using VideoAutoUpload.Playwright.Models.Step;

namespace AutomatedToolLibrary
{
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点
        /// </summary>
        /// <remarks>
        /// 该方法初始化应用程序配置并启动主窗体
        /// 如果发生未处理异常，将捕获并显示错误信息
        /// </remarks>
        [STAThread]
        static void Main()
        {
            PlatformAccountStep platformAccountStep = new PlatformAccountStep();
            TraverseProperties(platformAccountStep);
            try
            {
                // 初始化应用程序配置(高DPI设置、默认字体等)
                // 参考: https://aka.ms/applicationconfiguration
                ApplicationConfiguration.Initialize();

                // 启动主窗体
                Application.Run(new MultiPlatformAutomation());
            }
            catch (Exception ex)
            {
                // 捕获并处理未预期的异常
                MessageBox.Show($"AutomatedToolLibrary-Program-Main: {ex.Message}",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private static readonly string DefaultDataType = "|string|";
        public static void TraverseProperties(object obj01)
        {
            if (obj01 == null) return;
            List<Playwright_APIreference> playwright_APIreferenceList = new List<Playwright_APIreference>();
            try
            {
                Type type01 = obj01.GetType();
                foreach (PropertyInfo property01 in type01.GetProperties())
                {
                    object value01 = property01.GetValue(obj01);
                    string propertyName01 = property01.Name;

                    // 获取 DescriptionAttribute
                    var descriptionAttribute01 = (DescriptionAttribute)Attribute.GetCustomAttribute(property01, typeof(DescriptionAttribute));
                    string description01 = descriptionAttribute01?.Description ?? "无描述";

                    Playwright_APIreference playwright_APIreference01 = new Playwright_APIreference();
                    playwright_APIreference01.APIReference01 = propertyName01;
                    playwright_APIreference01.APIReference01Name = description01;
                    playwright_APIreferenceList.Add(playwright_APIreference01);

                    // 如果属性是类类型，则递归进入
                    if (value01 != null && !property01.PropertyType.IsPrimitive && !DefaultDataType.Contains(property01.PropertyType.ToString()))
                    {
                        //TraverseProperties(value01);
                        #region 02
                        Type type02 = value01.GetType();
                        foreach (PropertyInfo property02 in type02.GetProperties())
                        {
                            object value02 = property02.GetValue(value01);
                            string propertyName02 = property02.Name;

                            // 获取 DescriptionAttribute
                            var descriptionAttribute02 = (DescriptionAttribute)Attribute.GetCustomAttribute(property02, typeof(DescriptionAttribute));
                            string description02 = descriptionAttribute02?.Description ?? "无描述";

                            Playwright_APIreference playwright_APIreference02 = new Playwright_APIreference();
                            playwright_APIreference02 = playwright_APIreference01.Adapt<Playwright_APIreference>();
                            playwright_APIreference02.APIReference02 = propertyName02;
                            playwright_APIreference02.APIReference02Name = description02;
                            playwright_APIreferenceList.Add(playwright_APIreference02);

                            // 如果属性是类类型，则递归进入
                            if (value02 != null && !property02.PropertyType.IsPrimitive && !DefaultDataType.Contains(property02.PropertyType.ToString()))
                            {
                                //TraverseProperties(value02);
                                #region 03
                                Type type03 = value02.GetType();
                                foreach (PropertyInfo property03 in type03.GetProperties())
                                {
                                    object value03 = property03.GetValue(value02);
                                    string propertyName03 = property03.Name;

                                    // 获取 DescriptionAttribute
                                    var descriptionAttribute03 = (DescriptionAttribute)Attribute.GetCustomAttribute(property03, typeof(DescriptionAttribute));
                                    string description03 = descriptionAttribute03?.Description ?? "无描述";

                                    Playwright_APIreference playwright_APIreference03 = new Playwright_APIreference();
                                    playwright_APIreference03 = playwright_APIreference02.Adapt<Playwright_APIreference>();
                                    playwright_APIreference03.APIReference03 = propertyName03;
                                    playwright_APIreference03.APIReference03Name = description03;
                                    playwright_APIreferenceList.Add(playwright_APIreference03);

                                    // 如果属性是类类型，则递归进入
                                    if (value03 != null && !property03.PropertyType.IsPrimitive && !DefaultDataType.Contains(property03.PropertyType.ToString()))
                                    {
                                        //TraverseProperties(value03);
                                        #region 04
                                        Type type04 = value03.GetType();
                                        foreach (PropertyInfo property04 in type04.GetProperties())
                                        {
                                            object value04 = property04.GetValue(value03);
                                            string propertyName04 = property04.Name;

                                            // 获取 DescriptionAttribute
                                            var descriptionAttribute04 = (DescriptionAttribute)Attribute.GetCustomAttribute(property04, typeof(DescriptionAttribute));
                                            string description04 = descriptionAttribute04?.Description ?? "无描述";

                                            Playwright_APIreference playwright_APIreference04 = new Playwright_APIreference();
                                            playwright_APIreference04 = playwright_APIreference03.Adapt<Playwright_APIreference>();
                                            playwright_APIreference04.APIReference04 = propertyName04;
                                            playwright_APIreference04.APIReference04Name = description04;
                                            playwright_APIreferenceList.Add(playwright_APIreference04);

                                            // 如果属性是类类型，则递归进入
                                            if (value04 != null && !property04.PropertyType.IsPrimitive && !DefaultDataType.Contains(property04.PropertyType.ToString()))
                                            {
                                                //TraverseProperties(value04);
                                                #region 05
                                                Type type05 = value04.GetType();
                                                foreach (PropertyInfo property05 in type05.GetProperties())
                                                {
                                                    object value05 = property05.GetValue(value04);
                                                    string propertyName05 = property05.Name;

                                                    // 获取 DescriptionAttribute
                                                    var descriptionAttribute05 = (DescriptionAttribute)Attribute.GetCustomAttribute(property05, typeof(DescriptionAttribute));
                                                    string description05 = descriptionAttribute05?.Description ?? "无描述";

                                                    Playwright_APIreference playwright_APIreference05 = new Playwright_APIreference();
                                                    playwright_APIreference05 = playwright_APIreference04.Adapt<Playwright_APIreference>();
                                                    playwright_APIreference05.APIReference05 = propertyName05;
                                                    playwright_APIreference05.APIReference05Name = description05;
                                                    playwright_APIreferenceList.Add(playwright_APIreference05);

                                                    // 如果属性是类类型，则递归进入
                                                    if (value05 != null && !property05.PropertyType.IsPrimitive && !DefaultDataType.Contains(property05.PropertyType.ToString()))
                                                    {
                                                        //TraverseProperties(value05);
                                                        #region 06
                                                        Type type06 = value05.GetType();
                                                        foreach (PropertyInfo property06 in type06.GetProperties())
                                                        {
                                                            object value06 = property06.GetValue(value05);
                                                            string propertyName06 = property06.Name;

                                                            // 获取 DescriptionAttribute
                                                            var descriptionAttribute06 = (DescriptionAttribute)Attribute.GetCustomAttribute(property06, typeof(DescriptionAttribute));
                                                            string description06 = descriptionAttribute06?.Description ?? "无描述";

                                                            Playwright_APIreference playwright_APIreference06 = new Playwright_APIreference();
                                                            playwright_APIreference06 = playwright_APIreference05.Adapt<Playwright_APIreference>();
                                                            playwright_APIreference06.APIReference06 = propertyName06;
                                                            playwright_APIreference06.APIReference06Name = description06;
                                                            playwright_APIreferenceList.Add(playwright_APIreference06);

                                                            // 如果属性是类类型，则递归进入
                                                            if (value06 != null && !property06.PropertyType.IsPrimitive && !DefaultDataType.Contains(property06.PropertyType.ToString()))
                                                            {
                                                                //TraverseProperties(value06);
                                                            }
                                                        }
                                                        #endregion 06
                                                    }
                                                }
                                                #endregion 05
                                            }
                                        }
                                        #endregion 04
                                    }
                                }
                                #endregion 03
                            }
                        }
                        #endregion 02
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            var tt = playwright_APIreferenceList;
        }

    }
    public class Playwright_APIreference
    {
        public string APIReference01 { get; set; }
        public string APIReference02 { get; set; }
        public string APIReference03 { get; set; }
        public string APIReference04 { get; set; }
        public string APIReference05 { get; set; }
        public string APIReference06 { get; set; }
        public string APIReference01Name { get; set; }
        public string APIReference02Name { get; set; }
        public string APIReference03Name { get; set; }
        public string APIReference04Name { get; set; }
        public string APIReference05Name { get; set; }
        public string APIReference06Name { get; set; }
    }
}
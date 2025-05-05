using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VideoAutoUpload.Playwright.Models;
using VideoAutoUpload.Playwright.Models.Step;

namespace AutomatedToolLibrary.多平台自动化.数据源
{
    public class MultiPlatformAutomation_Playwright_APIreference_DataSource
    {
        /// <summary>
        /// 存储当前编辑的平台配置数据对象
        /// </summary>
        public static PlatformsConfig platformsConfig;

        protected static List<Playwright_APIreference> playwright_APIreferenceList { get; private set; } = new List<Playwright_APIreference>();
        public static readonly string DefaultDataType = "|string|int|double|bool|float|WaitUntilState|".ToUpper();
        public static string DataTypeRet( string typeName)
        {
            string[] parts = typeName.Split('.');
            string lastPart = parts.Length > 0 ? parts[parts.Length - 1] : typeName;
            string upperLastPart = lastPart.ToUpper();
            return upperLastPart;
        }
        private static readonly string DefaultPlatforms = "抖音|快手|视频号|B站|小红书|知乎|微博|今日头条|西瓜视频|百家号|企鹅号|大鱼号|网易号|搜狐号|爱奇艺号|腾讯看点|一点资讯|趣头条|哔哩哔哩|皮皮虾|美拍|秒拍|微视|全民小视频|随刻|好看视频|新浪看点|快看点|东方号|惠头条|快传号|搜狗号";
        private static void InitDataSource()
        {
            if (!playwright_APIreferenceList.Any())
            {
                PlatformAccountStep obj01 = new PlatformAccountStep();
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
                        playwright_APIreference01._object = value01;
                        playwright_APIreferenceList.Add(playwright_APIreference01);

                        // 如果属性是类类型，则递归进入
                        if (value01 != null && !property01.PropertyType.IsPrimitive && !DefaultDataType.Contains(DataTypeRet(property01.PropertyType.ToString())))
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
                                playwright_APIreference02._object = value02;
                                playwright_APIreferenceList.Add(playwright_APIreference02);

                                // 如果属性是类类型，则递归进入
                                if (value02 != null && !property02.PropertyType.IsPrimitive && !DefaultDataType.Contains(DataTypeRet(property02.PropertyType.ToString())))
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
                                        playwright_APIreference03._object = value03;
                                        playwright_APIreferenceList.Add(playwright_APIreference03);

                                        // 如果属性是类类型，则递归进入
                                        if (value03 != null && !property03.PropertyType.IsPrimitive && !DefaultDataType.Contains(DataTypeRet(property03.PropertyType.ToString())))
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
                                                playwright_APIreference04._object = value04;
                                                playwright_APIreferenceList.Add(playwright_APIreference04);

                                                // 如果属性是类类型，则递归进入
                                                if (value04 != null && !property04.PropertyType.IsPrimitive && !DefaultDataType.Contains(DataTypeRet(property04.PropertyType.ToString())))
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
                                                        playwright_APIreference05._object = value05;
                                                        playwright_APIreferenceList.Add(playwright_APIreference05);

                                                        // 如果属性是类类型，则递归进入
                                                        if (value05 != null && !property05.PropertyType.IsPrimitive && !DefaultDataType.Contains(DataTypeRet(property05.PropertyType.ToString())))
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
                                                                playwright_APIreference06._object = value06;
                                                                playwright_APIreferenceList.Add(playwright_APIreference06);

                                                                // 如果属性是类类型，则递归进入
                                                                if (value06 != null && !property06.PropertyType.IsPrimitive && !DefaultDataType.Contains(DataTypeRet(property06.PropertyType.ToString())))
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

            }
        }
        public static List<Playwright_APIreference> GetPlaywrightAPIReference(Playwright_APIreference playwright_APIreference)
        {
            if (!playwright_APIreferenceList.Any())
            {
                InitDataSource();
            }
            List<Playwright_APIreference> playwright_APIreferenceListRet = new List<Playwright_APIreference>();
            if (!string.IsNullOrWhiteSpace(playwright_APIreference.APIReference01))
            {
                playwright_APIreferenceListRet = playwright_APIreferenceList.Where(x => x.APIReference01 == playwright_APIreference.APIReference01).ToList();
            }
            else
            {
                playwright_APIreferenceListRet = playwright_APIreferenceList.Where(x => string.IsNullOrWhiteSpace(x.APIReference02)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(playwright_APIreference.APIReference02))
            {
                playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => x.APIReference02 == playwright_APIreference.APIReference02).ToList();
            }
            else
            {
                playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => string.IsNullOrWhiteSpace(x.APIReference03)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(playwright_APIreference.APIReference03))
            {
                playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => x.APIReference03 == playwright_APIreference.APIReference03).ToList();
            }
            else
            {
                playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => string.IsNullOrWhiteSpace(x.APIReference04)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(playwright_APIreference.APIReference04))
            {
                playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => x.APIReference04 == playwright_APIreference.APIReference04).ToList();
            }
            else
            {
                playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => string.IsNullOrWhiteSpace(x.APIReference05)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(playwright_APIreference.APIReference05))
            {
                playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => x.APIReference05 == playwright_APIreference.APIReference05).ToList();
            }
            else
            {
                playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => string.IsNullOrWhiteSpace(x.APIReference06)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(playwright_APIreference.APIReference06))
            {
                playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => x.APIReference06 == playwright_APIreference.APIReference06).ToList();
            }
            //else
            //{
            //    playwright_APIreferenceListRet = playwright_APIreferenceListRet.Where(x => string.IsNullOrWhiteSpace(x.APIReference06)).ToList();
            //}
            return playwright_APIreferenceListRet;
        }
        public static List<string> GetPlatforms()
        {
            List<string> platforms = new List<string>();
            if (DefaultPlatforms != null)
            {
                foreach (var platform in DefaultPlatforms.Split('|'))
                {
                    platforms.Add(platform);
                }
            }
            return platforms;
        }
    }
    /// <summary>
    /// "API参考""类""页面","方法","跳转页面","使用方法1"
    /// </summary>
    public class Playwright_APIreference
    {
        public object _object { get; set; }
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
        /// <summary>
        /// 构造函数用于快速初始化对象
        /// </summary>
        //public Playwright_APIreference(
        //    string ref1, string ref2, string ref3, string ref4, string ref5, string ref6,
        //    string name1, string name2, string name3, string name4, string name5, string name6)
        //{
        //    APIReference1 = ref1;
        //    APIReference2 = ref2;
        //    APIReference3 = ref3;
        //    APIReference4 = ref4;
        //    APIReference5 = ref5;
        //    APIReference6 = ref6;

        //    APIReference1Name = name1;
        //    APIReference2Name = name2;
        //    APIReference3Name = name3;
        //    APIReference4Name = name4;
        //    APIReference5Name = name5;
        //    APIReference6Name = name6;
        //}
    }
}

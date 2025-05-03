
//using System;
//using System.Threading.Tasks;
//namespace VideoAutoUpload.Playwright
//{
//    /// <summary>
//    /// 哔哩哔哩Cookie获取示例
//    /// </summary>
//    public class GetBilibiliCookieExample
//    {
//        /// <summary>
//        /// 主入口方法
//        /// </summary>
//        public static async Task Main()
//        {
//            try
//            {
//                Console.WriteLine("开始获取哔哩哔哩Cookie...");

//                var uploader = new BilibiliUploader("bilibili_cookie.json");
//                //await uploader.GetNewCookieAsync();

//                Console.WriteLine("Cookie获取成功，已保存到 bilibili_cookie.json");
//                Console.WriteLine("请将cookie文件复制到项目的cookies/bilibili_uploader目录下");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"获取Cookie失败: {ex.Message}");
//            }
//        }
//    }
//}

//using System;
//using System.Threading.Tasks;
//namespace VideoAutoUpload.Playwright
//{
//    /// <summary>
//    /// 抖音Cookie获取示例
//    /// </summary>
//    public class GetDouyinCookieExample
//    {
//        /// <summary>
//        /// 主入口方法
//        /// </summary>
//        public static async Task Main()
//        {
//            try
//            {
//                Console.WriteLine("开始获取抖音Cookie...");

//                var uploader = new DouyinUploader("douyin_cookie.json");
//                await uploader.GetNewCookieAsync();

//                Console.WriteLine("Cookie获取成功，已保存到 douyin_cookie.json");
//                Console.WriteLine("请将cookie文件复制到项目的cookies/douyin_uploader目录下");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"获取Cookie失败: {ex.Message}");
//            }
//        }
//    }
//}
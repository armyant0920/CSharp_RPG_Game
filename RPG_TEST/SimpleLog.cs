using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RPG_TEST
{
    public static class SimpleLog
    {
        static string log_dir;
        static string log_path;


        public static void SetLog()
        {

            log_dir = System.AppDomain.CurrentDomain.BaseDirectory + "log\\";
            Console.WriteLine(log_dir);

            if (!Directory.Exists(log_dir))
            {
                Directory.CreateDirectory(log_dir);
            }

            log_path = string.Format("{0}E-Logisitics_Log_{1}.log", log_dir, DateTime.Now.ToString("yyyyMMdd-HHmmss"));
            WriteLog("E-Logisitics-ShippingAlert Start");



        }

        public static void SetLog(string path, string log_name)
        {

            log_dir = path + @"\LOG\";
            Console.WriteLine(log_dir);

            if (!Directory.Exists(log_dir))
            {
                Directory.CreateDirectory(log_dir);
            }

            log_path = string.Format("{0}{1}_{2}.log", log_dir, log_name, DateTime.Now.ToString("yyyyMMdd-HHmmss"));

            WriteLog("Start");

        }

        /// <summary>
        /// 寫入本機log
        /// </summary>
        /// <param name="s">log訊息</param>
        public static void WriteLog(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss fff]"));
            sb.Append(s);
            Console.WriteLine(sb.ToString());

            using (StreamWriter sw = File.AppendText(log_path))
            {
                sw.WriteLine(sb.ToString());
            }
        }
    }
}

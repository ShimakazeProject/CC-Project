namespace Crape_Client.LogMgr
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Logger
    {

        private string fileName;
        private string loggerName;

        private static string LOG_DIR = $"{AppDomain.CurrentDomain.BaseDirectory}Debug";
        private static FileStream fileStream;
        private static StreamWriter streamWriter;

        public Logger(string tag)
        {
            loggerName = tag;
            fileName = $"{DateTime.Now.ToShortDateString().Replace('/', '_')}.log";
            if (!Directory.Exists(LOG_DIR))
            {
                Directory.CreateDirectory(LOG_DIR);
            }
            fileStream = new FileStream($@"{LOG_DIR}\{fileName}", FileMode.Append,FileAccess.Write);
            streamWriter = new StreamWriter(fileStream);
            //streamWriter.WriteLine($"*** Crape Studio Logger *** [{loggerName}] *** {DateTime.Now.ToShortTimeString()} ***");
            //streamWriter.Flush();
        }

        #region 静态方法
        /// <summary>
        /// 静态 写入日志
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="loggerName"></param>
        /// <param name="msg"></param>
        public static  void WriteLine(LogRank rank, string loggerName, string msg)
        {
            string Rank = string.Empty;
            switch (rank)
            {
                case LogRank.INFO:
                    Rank = "Info\t";
                    break;
                case LogRank.DEBUG:
                    Rank = "Debug\t";
                    break;
                case LogRank.WARN:
                    Rank = "Warn\t";
                    break;
                case LogRank.ERROR:
                    Rank = "Error\t";
                    break;
                case LogRank.FATAL:
                    Rank = "Fatal\t";
                    break;
                default:
                    break;
            }
             streamWriter.WriteLine($"{Rank} [{loggerName}]:{DateTime.Now.ToShortTimeString()} | {msg}");
             streamWriter.Flush();
        }
        public static  void Write(LogRank rank, string loggerName, string msg)
        {
            string Rank = string.Empty;
            switch (rank)
            {
                case LogRank.INFO:
                    Rank = "Info\t";
                    break;
                case LogRank.DEBUG:
                    Rank = "Debug\t";
                    break;
                case LogRank.WARN:
                    Rank = "Warn\t";
                    break;
                case LogRank.ERROR:
                    Rank = "Error\t";
                    break;
                case LogRank.FATAL:
                    Rank = "Fatal\t";
                    break;
                default:
                    break;
            }
             streamWriter.Write($"{Rank} [{loggerName}]:{DateTime.Now.ToShortTimeString()} | {msg}");
             streamWriter.Flush();
        }
        public static  void Except(Exception e, string loggerName)
        {
             streamWriter.WriteLine($"Fatal * [{loggerName}]:{DateTime.Now.ToShortTimeString()} | {e.Message}");
             streamWriter.WriteLine($"{e.StackTrace}\n{e.Source}\n{e.TargetSite}");
             streamWriter.Flush();
        }
        #endregion

        public  void WriteLine(LogRank rank, string msg)
        {
             WriteLine(rank, loggerName, msg);
        }
        public  void Write(LogRank rank, string msg)
        {
             Write(rank, loggerName, msg);
        }
        public  void Except(Exception e)
        {
             Except(e, loggerName);
        }

    }
}


using Crape_Client.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Crape_Client.Configs
{
    public static class GameConfigs
    {
        private static string inipath = AppDomain.CurrentDomain.BaseDirectory + "ra2md.ini";
        public static int Height { get; set; }
        public static int Width { get; set; }
        public static int Difficult { get; set; }
        public static bool IsWindow { get; set; }
        public static bool NoFrame { get; set; }
        public static bool SpeedCtrl { get; set; }
        public static bool UseLog { get; set; }

        public static string Summary { get; set; }
        public static Brush MWBG { get; set; }
        public static List<MissionList> Missions { get; set; }
        public static List<RendererJson> Graphics { get; set; }
        static GameConfigs()
        {
            Missions = new List<MissionList>();
            Graphics = new List<RendererJson>();
            if (System.IO.File.Exists(inipath))
            {

            }
        }

    }
}

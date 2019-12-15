using Microsoft.Win32;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Json;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace Crape_Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static LogMgr.Logger Logger = new LogMgr.Logger("Crape Client");
        public App()
        {
            RendererInit();
            SideInit();
            MessageBoxX.MessageBoxXConfigurations.Add("InfoTheme", new Panuon.UI.Silver.Core.MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Modern,
                MessageBoxIcon = MessageBoxIcon.Info,
            });
            MessageBoxX.MessageBoxXConfigurations.Add("WarnTheme", new Panuon.UI.Silver.Core.MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Modern,
                MessageBoxIcon = MessageBoxIcon.Warning,
            });
            MessageBoxX.MessageBoxXConfigurations.Add("ErrorTheme", new Panuon.UI.Silver.Core.MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Modern,
                MessageBoxIcon = MessageBoxIcon.Error,
            });
            MessageBoxX.MessageBoxXConfigurations.Add("SuccessTheme", new Panuon.UI.Silver.Core.MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Modern,
                MessageBoxIcon = MessageBoxIcon.Success,
            });
            MessageBoxX.MessageBoxXConfigurations.Add("NoneTheme", new Panuon.UI.Silver.Core.MessageBoxXConfigurations()
            {
                MessageBoxStyle = MessageBoxStyle.Modern,
                MessageBoxIcon = MessageBoxIcon.None,
            });
            Logger.WriteLine(LogMgr.LogRank.INFO, "初始化完成 Crape Client正常工作中");
        }

        private bool RendererInit()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Resource\GraphicsAPIs.json"))
                return false;
            var text = File.ReadAllText(@"Resource\GraphicsAPIs.json");
            text = System.Text.RegularExpressions.Regex.Replace(text, @"\/\*.+?\*\/|\/\/.+?\n", string.Empty);
            JsonArray renderers = (JsonArray)JsonValue.Parse(text);
            List<JsonValue> rendererList = renderers.ToList();

            foreach (JsonObject renderer in rendererList)
            {
                if (renderer.JsonType != JsonType.Object) throw new FormatException();
                Crape_Client.Configs.GameConfigs.Graphics.Add(new Crape_Client.Tools.RendererJson(renderer));
                //apis.Items.Add(new RendererJson(renderer));
            }
            return true;
        }
        private bool SideInit()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Side.json"))
                return false;
            var text = File.ReadAllText(@"Resource\Side.json");
            text = System.Text.RegularExpressions.Regex.Replace(text, @"\/\*.+?\*\/|\/\/.+?\n", string.Empty);
            JsonArray side = (JsonArray)JsonValue.Parse(text);
            List<JsonValue> sideList = side.ToList();
            Crape_Client.Configs.GameConfigs.Sides.Add(new Tools.SideJson("随机", "#FFFFFF"));
            for (int i = 0; i < sideList.Count; i++)
            {
                var item = (JsonObject)sideList[i];
                item.TryGetValue("Side", out JsonValue sideName);
                item.TryGetValue("Image", out JsonValue imgjv);
                item.TryGetValue("Color", out JsonValue clr);
                string img = imgjv;
                Crape_Client.Configs.GameConfigs.Sides.Add(new Tools.SideJson($"随机 {sideName.ToString()}", clr,
                    $"{AppDomain.CurrentDomain.BaseDirectory}Resource\\Image\\{img}"));
            }

            foreach (JsonObject item in sideList)
            {
                if (item.JsonType != JsonType.Object) throw new FormatException();
                item.TryGetValue("Image", out JsonValue imgjv);
                item.TryGetValue("Color", out JsonValue clr);
                item.TryGetValue("Country", out JsonValue countrys);
                string img = imgjv;
                foreach (var name in countrys as JsonArray)
                {
                    Crape_Client.Configs.GameConfigs.Sides.Add(
                        new Crape_Client.Tools.SideJson(
                            name,
                            clr,
                            $"{AppDomain.CurrentDomain.BaseDirectory}Resource\\Image\\{img}"));
                }
            }
            return true;
        }
        /// <summary>
        /// 运行游戏
        /// </summary>
        public static void RunGame()
        {
            Logger.WriteLine(LogMgr.LogRank.INFO, "开始执行游戏");
            bool isWin8 = Environment.OSVersion.Version.Major >= 6 ? Environment.OSVersion.Version.Minor >= 2 ? true : false : false;
            string gamemd = "syringe.exe \"gamemd.exe\" ";
            string command = "-SPAWN -CD ";
            command += Crape_Client.Configs.GameConfigs.SpeedCtrl ? "-SPEEDCONTROL " : string.Empty;
            command += Crape_Client.Configs.GameConfigs.UseLog ? command += "-LOG " : string.Empty;

            Logger.WriteLine(LogMgr.LogRank.INFO, $"操作系统{Environment.OSVersion.Version.ToString()}");
            if (isWin8)
            {
                var reg = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers", true);
                string regstr = (string)reg.GetValue(AppDomain.CurrentDomain.BaseDirectory + "gamemd.exe");
                reg.SetValue(AppDomain.CurrentDomain.BaseDirectory + "gamemd.exe", regstr + " 16BITCOLOR", RegistryValueKind.String);
            }
            else
            {
                if (Crape_Client.Configs.GameConfigs.IsWindow) //设置16色
                    ChangeRes();
            }

            try
            {
                Logger.WriteLine(LogMgr.LogRank.INFO, $"开始运行游戏");
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + gamemd + command);
                Logger.WriteLine(LogMgr.LogRank.INFO, $"游戏已运行 等待游戏退出");
                proc.WaitForExit();
                Logger.WriteLine(LogMgr.LogRank.INFO, $"程序退出 退出值:{proc.ExitCode}");
                if (Crape_Client.Configs.GameConfigs.IsWindow)// 还原
                    DisChangeRes();//还原色深
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                Logger.Except(e);
                return;
            }
            catch (NullReferenceException e)
            {
                Logger.Except(e);
                return;
            }
        }

        #region 屏幕信息
        static Rectangle rect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;//保存当前屏幕分辨率
        static readonly int j = rect.Width; //宽（像素）
        static readonly int i = rect.Height; //高（像素）
        static readonly int b = System.Windows.Forms.Screen.PrimaryScreen.BitsPerPixel;//BitsPerPixel
        #endregion
        #region Dll引用
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public short dmOrientation;
            public short dmPaperSize;
            public short dmPaperLength;
            public short dmPaperWidth;
            public short dmScale;
            public short dmCopies;
            public short dmDefaultSource;
            public short dmPrintQuality;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)] static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)] static extern bool EnumDisplaySettings(string lpszDeviceName, Int32 iModeNum, ref DEVMODE lpDevMode);
        #endregion
        /// <summary>
        /// 修改色深
        /// </summary>
        public static void ChangeRes()
        {
            DEVMODE DevM = new DEVMODE
            {
                dmSize = (short)Marshal.SizeOf(typeof(DEVMODE))
            };
            EnumDisplaySettings(null, 0, ref DevM);
            DevM.dmPelsWidth = j;
            DevM.dmPelsHeight = i;
            DevM.dmDisplayFrequency = 0;//刷新频率
            DevM.dmBitsPerPel = 16;//颜色象素
            int result = ChangeDisplaySettings(ref DevM, 0);
            /*
            if (result != 0)
            {
                Global.Globals.LogMGR.Error("SetBitsPerPixel     ChangeDisplaySettings Returned:" + result.ToString());
                Global.Globals.LogMGR.NoTimeMsg("\t Width: " + j.ToString());
                Global.Globals.LogMGR.NoTimeMsg("\tHeight: " + i.ToString());
                Global.Globals.LogMGR.NoTimeMsg("\t  Bits: " + b.ToString());
            }//*/
            //long result = ChangeDisplaySettings(ref DevM, 0);
        }
        /// <summary>
        /// 还原修改
        /// </summary>
        public static void DisChangeRes()
        {
            DEVMODE DevM = new DEVMODE
            {
                dmSize = (short)Marshal.SizeOf(typeof(DEVMODE))
            };
            EnumDisplaySettings(null, 0, ref DevM);
            DevM.dmPelsWidth = j;
            DevM.dmPelsHeight = i;
            DevM.dmDisplayFrequency = 0;//刷新频率
            DevM.dmBitsPerPel = b;//颜色象素
            long result = ChangeDisplaySettings(ref DevM, 0);
            /*
            if (result != 0)
            {
                Global.Globals.LogMGR.Error("RestoreBitsPerPixel ChangeDisplaySettings Returned:" + result.ToString());
                Global.Globals.LogMGR.NoTimeMsg("\t Width: " + j.ToString());
                Global.Globals.LogMGR.NoTimeMsg("\tHeight: " + i.ToString());
                Global.Globals.LogMGR.NoTimeMsg("\t  Bits: " + b.ToString());
            }//*/
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Logger.WriteLine(LogMgr.LogRank.INFO, $"Crape Client 程序退出 Code:{e.ApplicationExitCode}");
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Except(e.Exception);
        }
    }
}

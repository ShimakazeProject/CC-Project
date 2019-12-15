namespace Crape_Client.Configs.Ra2md
{
    using Crape_Client.Tools;
    public static class Video //视频设置
    {
        public static bool VideoBackBuffer
        {
            set { IniIO.I("Video", "VideoBackBuffer", value); }
            get { return IniIO.Obool("Video", "VideoBackBuffer"); }
        }
        public static bool AllowHiResModes
        {
            set { IniIO.I("Video", "AllowHiResModes", value); }
            get { return IniIO.Obool("Video", "AllowHiResModes"); }
        }
        public static bool AllowVRAMSidebar
        {
            set { IniIO.I("Video", "AllowVRAMSidebar", value); }
            get { return IniIO.Obool("Video", "AllowVRAMSidebar"); }
        }
        public static bool StretchMovies
        {
            set { IniIO.I("Video", "StretchMovies", value); }
            get { return IniIO.Obool("Video", "StretchMovies"); }
        }
        public static bool Windowed
        {
            set
            {
                IniIO.I("Video", "Video.Windowed", value);
            }
            get
            {
                return IniIO.Obool("Video", "Video.Windowed");
            }
        }// 窗口化
        public static bool ForceLowestDetailLevel
        {
            set
            {
                IniIO.I("Video", "ForceLowestDetailLevel", value);
            }
            get
            {
                return IniIO.Obool("Video", "ForceLowestDetailLevel");
            }
        }
        public static bool NoWindowFrame
        {
            set
            {
                IniIO.I("Video", "NoWindowFrame", value);
            }
            get
            {
                return IniIO.Obool("Video", "NoWindowFrame");
            }
        }// 无边框
        public static int ScreenWidth
        {
            set
            {
                IniIO.I("Video", "ScreenWidth", value);
            }
            get
            {
                return IniIO.Oint("Video", "ScreenWidth");
            }
        }// 分辨率X长
        public static int ScreenHeight
        {
            set
            {
                IniIO.I("Video", "ScreenHeight", value);
            }
            get
            {
                return IniIO.Oint("Video", "ScreenHeight");
            }
        }// 分辨率Y宽
        public static string Screen
        {
            set
            {
                var a = value.Split('*');
                if (a.Length>=2)
                {
                    IniIO.I("Video", "ScreenWidth", a[0]);
                    IniIO.I("Video", "ScreenHeight", a[1]);
                }
            }
            get
            {
                return ScreenWidth + "*" + ScreenHeight;
            }
        }
        public static bool UseRenderer
        {
            set
            {
                IniIO.I("Video", "UseRenderer", value);
            }
            get
            {
                return IniIO.Obool("Video", "UseRenderer");
            }
        }
        public static int Renderer
        {
            set
            {
                IniIO.I("Video", "Renderer", value);
            }
            get
            {
                return IniIO.Oint("Video", "Renderer");
            }
        }// 渲染器
    }
}

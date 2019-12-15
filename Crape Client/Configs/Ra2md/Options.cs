namespace Crape_Client.Configs.Ra2md
{
    using Crape_Client.Tools;
    public static class Options
    {
        public static int DetailLevel
        {
            get { return IniIO.Oint("Options", "DetailLevel"); }
            set { IniIO.I("Options", "DetailLevel", value); }
        }
        public static bool UnitActionLines
        {
            get { return IniIO.Obool("Options", "UnitActionLines"); }
            set { IniIO.I("Options", "UnitActionLines", value); }
        }
        public static bool ScrollMethod
        {
            get { return IniIO.Obool("Options", "ScrollMethod"); }
            set { IniIO.I("Options", "ScrollMethod", value); }
        }
        public static bool ShowHidden
        {
            get { return IniIO.Obool("Options", "ShowHidden"); }
            set { IniIO.I("Options", "ShowHidden", value); }
        }
        public static bool ToolTips
        {
            get { return IniIO.Obool("Options", "ToolTips"); }
            set { IniIO.I("Options", "ToolTips", value); }
        }
        public static int ScrollRate
        {
            get { return IniIO.Oint("Options", "ScrollRate"); }
            set { IniIO.I("Options", "ScrollRate", value); }
        }
        public static int Difficulty
        {
            get { return IniIO.Oint("Options", "Difficulty"); }
            set { IniIO.I("Options", "Difficulty", value); }
        }// 难度
    }

}

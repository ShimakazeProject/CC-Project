namespace Crape_Client.Configs.Ra2md
{
    using Crape_Client.Tools;
    public static class Skirmish // 遭遇战 
    {
        public static bool ShortGame
        {
            get => IniIO.Obool("Skirmish", "ShortGame");
            set => IniIO.I("Skirmish", "ShortGame", value);
        }
        public static bool SuperWeaponsAllowed
        {
            get => IniIO.Obool("Skirmish", "SuperWeaponsAllowed");
            set => IniIO.I("Skirmish", "SuperWeaponsAllowed", value);
        }
        public static bool BuildOffAlly
        {
            get => IniIO.Obool("Skirmish", "BuildOffAlly");
            set => IniIO.I("Skirmish", "BuildOffAlly", value);
        }
        public static bool MCVRepacks
        {
            get => IniIO.Obool("Skirmish", "MCVRepacks");
            set => IniIO.I("Skirmish", "MCVRepacks", value);
        }
        public static bool CratesAppear
        {
            get => IniIO.Obool("Skirmish", "CratesAppear");
            set => IniIO.I("Skirmish", "CratesAppear", value);
        }
        public static bool AlliesAllowed
        {
            get => IniIO.Obool("Skirmish", "AlliesAllowed");
            set => IniIO.I("Skirmish", "AlliesAllowed", value);
        }
        public static bool Creates
        {
            get => IniIO.Obool("Skirmish", "Creates");
            set => IniIO.I("Skirmish", "Creates", value);
        }
        public static bool MultiEngineer
        {
            get => IniIO.Obool("Skirmish", "MultiEngineer");
            set => IniIO.I("Skirmish", "MultiEngineer", value);
        }
        public static bool FogOfWar
        {
            get => IniIO.Obool("Skirmish", "FogOfWar");
            set => IniIO.I("Skirmish", "FogOfWar", value);
        }
        public static bool BridgeDestroy
        {
            get => IniIO.Obool("Skirmish", "BridgeDestroy");
            set => IniIO.I("Skirmish", "BridgeDestroy", value);
        }
        public static bool SkipScoreScreen
        {
            get => IniIO.Obool("Skirmish", "AlliesAllowed");
            set => IniIO.I("Skirmish", "AlliesAllowed", value);
        }
        public static bool AttackNeutralUnits
        {
            get => IniIO.Obool("Skirmish", "Creates");
            set => IniIO.I("Skirmish", "Creates", value);
        }
        public static bool LimitedMCV
        {
            get => IniIO.Obool("Skirmish", "MultiEngineer");
            set => IniIO.I("Skirmish", "MultiEngineer", value);
        }
        public static bool PermanentRadar
        {
            get => IniIO.Obool("Skirmish", "FogOfWar");
            set => IniIO.I("Skirmish", "FogOfWar", value);
        }
        public static bool ConYardStart
        {
            get => IniIO.Obool("Skirmish", "BridgeDestroy");
            set => IniIO.I("Skirmish", "BridgeDestroy", value);
        }



        public static int MySide
        {
            get => IniIO.Oint("Skirmish", "MySide");
            set => IniIO.I("Skirmish", "MySide", value);
        }
        public static int MyColor
        {
            get => IniIO.Oint("Skirmish", "MyColor");
            set => IniIO.I("Skirmish", "MyColor", value);
        }



        public static int GameMode
        {
            get => IniIO.Oint("Skirmish", "GameMode");
            set => IniIO.I("Skirmish", "GameMode", value);
        }
        public static int ScenIndex
        {
            get => IniIO.Oint("Skirmish", "ScenIndex");
            set => IniIO.I("Skirmish", "ScenIndex", value);
        }
        public static int GameSpeed
        {
            get => IniIO.Oint("Skirmish", "GameSpeed");
            set => IniIO.I("Skirmish", "GameSpeed", value);
        }
        public static int Credits
        {
            get => IniIO.Oint("Skirmish", "Credits");
            set => IniIO.I("Skirmish", "Credits", value);
        }
        public static int UnitCount
        {
            get => IniIO.Oint("Skirmish", "UnitCount");
            set => IniIO.I("Skirmish", "UnitCount", value);
        }
        public static int TechLevel
        {
            get => IniIO.Oint("Skirmish", "TechLevel");
            set => IniIO.I("Skirmish", "TechLevel", value);
        }
    }
}

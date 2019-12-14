namespace Crape_Client.Configs.Ra2md
{
    using Crape_Client.Tools;
    public static class Skirmish // 遭遇战 
    {
        public static void ShortGame(bool value)
        {
            IniIO.I("Skirmish", "ShortGame", value);
        }
        public static void SuperWeaponsAllowed(bool value)
        {
            IniIO.I("Skirmish", "SuperWeaponsAllowed", value);
        }
        public static void BuildOffAlly(bool value)
        {
            IniIO.I("Skirmish", "BuildOffAlly", value);
        }
        public static void MCVRepacks(bool value)
        {
            IniIO.I("Skirmish", "MCVRepacks", value);
        }
        public static void CratesAppear(bool value)
        {
            IniIO.I("Skirmish", "CratesAppear", value);
        }
        public static void GameMode(int value)
        {
            IniIO.I("Skirmish", "GameMode", value);
        }
        public static void ScenIndex(int value)
        {
            IniIO.I("Skirmish", "ScenIndex", value);
        }
        public static void GameSpeed(int value)
        {
            IniIO.I("Skirmish", "GameSpeed", value);
        }
        public static void Credits(int value)
        {
            IniIO.I("Skirmish", "Credits", value);
        }
        public static void UnitCount(int value)
        {
            IniIO.I("Skirmish", "UnitCount", value);
        }

    }
}

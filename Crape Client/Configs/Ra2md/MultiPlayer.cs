namespace Crape_Client.Configs.Ra2md
{
    using Crape_Client.Tools;

    public static class MultiPlayer // 多人游戏设置
    {
        public static string Handle
        {
            set
            {
                IniIO.I("MultiPlayer", "Handle", value);
            }
            get
            {
                return IniIO.Ostring("MultiPlayer", "Handle");
            }
        }
    }

}

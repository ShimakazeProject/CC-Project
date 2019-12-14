namespace Crape_Client.Configs.Ra2md
{
    using Crape_Client.Tools;
    public static class Audio
    {
        public static bool PlayMenuMusic
        {
            get { return IniIO.Obool("Audio", "PlayMenuMusic"); }
            set { IniIO.I("Audio", "PlayMenuMusic", value); }
        }
        public static bool EnableButtonHoverSound
        {
            get { return IniIO.Obool("Audio", "EnableButtonHoverSound"); }
            set { IniIO.I("Audio", "EnableButtonHoverSound", value); }
        }
        public static bool PlayMainMenuMusic
        {
            get { return IniIO.Obool("Audio", "PlayMainMenuMusic"); }
            set { IniIO.I("Audio", "PlayMainMenuMusic", value); }
        }
        public static bool StopMusicOnMenu
        {
            get { return IniIO.Obool("Audio", "StopMusicOnMenu"); }
            set { IniIO.I("Audio", "StopMusicOnMenu", value); }
        }
        public static bool IsScoreShuffle
        {
            get { return IniIO.Obool("Audio", "IsScoreShuffle"); }
            set { IniIO.I("Audio", "IsScoreShuffle", value);
                IniIO.I("Audio", "IsScoreRepeat", !value);
            }
        }
        public static bool InGameMusic
        {
            get { return IniIO.Obool("Audio", "InGameMusic"); }
            set { IniIO.I("Audio", "InGameMusic", value); }
        }
        public static bool IsScoreRepeat
        {
            get { return IniIO.Obool("Audio", "IsScoreRepeat"); }
            set { IniIO.I("Audio", "IsScoreRepeat", value);
                IniIO.I("Audio", "IsScoreShuffle", !value);
            }
        }
        public static double ClientVolume
        {
            get { return IniIO.Odouble("Audio", "ClientVolume"); }
            set { IniIO.I("Audio", "ClientVolume", value); }
        }
        public static double SoundVolume
        {
            get => IniIO.Odouble("Audio", "SoundVolume");
            set => IniIO.I("Audio", "SoundVolume", value.ToString("#0.0"));

        }// 音乐音量           
        public static double VoiceVolume
        {
            get => IniIO.Odouble("Audio", "VoiceVolume");
            set => IniIO.I("Audio", "VoiceVolume", value.ToString("#0.0"));
        }// 语音音量
        public static double ScoreVolume
        {
            get => IniIO.Odouble("Audio", "ScoreVolume");
            set => IniIO.I("Audio", "ScoreVolume", value.ToString("#0.0"));

        }// 音效音量
        public static int SoundLatency
        {
            get => IniIO.Oint("Audio", "SoundLatency");
            set => IniIO.I("Audio", "SoundLatency", value);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crape_Client
{
    /// <summary>
    /// BattlePage.xaml 的交互逻辑
    /// </summary>
    public partial class BattlePage : Page
    {
        public BattlePage()
        {
            InitializeComponent();
            //dgtc1.Header = Strings.Mission;
            //tbSummary.Text = Strings.Summary;
            //bRun.Content = Strings.Run;
            //tbEasy.Text = Strings.Easy;
            //tbNormal.Text = Strings.Normal;
            //tbHard.Text = Strings.Hard;

            if (!init()) throw new Exception("初始化异常");
        }
        private Spawn spawnIni;
        /// <summary>
        /// Json2Struct格式化
        /// </summary>
        struct MissionJson
        {
            public string Name { get; private set; }
            public string Summary { get; private set; }
            public JsonValue Spawn { get; private set; }
            public MissionJson(JsonObject json)
            {
                JsonValue name, summary, spawn;
                json.TryGetValue("mission", out name);
                json.TryGetValue("summary", out summary);
                json.TryGetValue("spawn", out spawn);
                if (name.JsonType == JsonType.String) Name = name;
                else throw new FormatException();
                if (summary.JsonType == JsonType.String) Summary = summary;
                else throw new FormatException();
                if (spawn.JsonType == JsonType.Object) Spawn = spawn;
                else throw new FormatException();
            }
        }
        /// <summary>
        /// 任务专用 Spawn Ini
        /// </summary>
        class Spawn
        {
            public string Scenario { get; private set; }
            public int GameSpeed { get; private set; }
            public bool Firestrom { get; private set; }
            public string CustomLoadScreen { get; private set; }
            public bool IsSinglePlayer { get; private set; }
            public bool SidebarHack { get; private set; }
            public int Side { get; private set; }
            public bool BuildOffAlly { get; private set; }
            public int DifficultyModeHuman { get; private set; }
            public int DifficultyModeComputer { get; private set; }
            public string Others { get; private set; }
            public Spawn()
            {
                Scenario = "";
                Side = 0;
                GameSpeed = 4;
                Firestrom = false;
                CustomLoadScreen = @"Resources\ls800a01.pcx";
                IsSinglePlayer = true;
                BuildOffAlly = true;
                DifficultyModeHuman = 0;
                DifficultyModeComputer = 2;
                Others = "";
            }
            public Spawn(JsonObject json) : this()
            {
                JsonValue scenario, side, gamespeed, firestrom, customloadscreen, issigleplayer, buildoffally, humanmode, computermode, others;
                if (json.TryGetValue("Scenario", out scenario)) Scenario = scenario;
                if (json.TryGetValue("Side", out side)) Side = side;
                if (json.TryGetValue("GameSpeed", out gamespeed)) GameSpeed = gamespeed;
                if (json.TryGetValue("Firestrom", out firestrom)) Firestrom = firestrom;
                if (json.TryGetValue("CustomLoadScreen", out customloadscreen)) CustomLoadScreen = customloadscreen;
                if (json.TryGetValue("IsSiglePlayer", out issigleplayer)) IsSinglePlayer = issigleplayer;
                if (json.TryGetValue("BuildOffAlly", out buildoffally)) BuildOffAlly = buildoffally;
                if (json.TryGetValue("DifficultyModeHuman", out humanmode)) DifficultyModeHuman = humanmode;
                if (json.TryGetValue("DifficultyModeComputer", out computermode)) DifficultyModeComputer = computermode;
                if (json.TryGetValue("Others", out others)) Others = others;
            }
            public override string ToString()
            {
                string ini = "[Settings]\r\n";
                ini += "Scenario" + ToString(Scenario);
                ini += "Side" + ToString(Side);
                ini += "GameSpeed" + ToString(GameSpeed);
                ini += "Firestrom" + ToString(Firestrom);
                ini += "CustomLoadScreen" + ToString(CustomLoadScreen);
                ini += "IsSiglePlayer" + ToString(IsSinglePlayer);
                ini += "BuildOffAlly" + ToString(BuildOffAlly);
                ini += "DifficultyModeHuman " + ToString(DifficultyModeHuman);
                ini += "DifficultyModeComputer" + ToString(DifficultyModeComputer);
                ini += Others;
                ini += "\r\n\r\n";
                return ini;
            }
            private string ToString(string str)
            {
                return "=" + str + "\r\n";
            }
            private string ToString(bool b)
            {
                if (b) return "=" + "1\r\n";
                else return "=" + "0\r\n";
            }
            private string ToString(int i)
            {
                string ret = "=";
                ret += i.ToString();
                ret += "\r\n";
                return ret;
            }
        }
        private bool init()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Resource\Missions.json"))
                return false;
            JsonObject missionJson = (JsonObject)JsonValue.Parse(File.ReadAllText(@"Resource\Missions.json"));
            JsonValue tmp;
            missionJson.TryGetValue("missions", out tmp);
            JsonArray missions = (JsonArray)tmp;
            List<JsonValue> missionList = missions.ToList();
            foreach (JsonObject mission in missionList)
            {
                if (mission.JsonType != JsonType.Object) throw new FormatException();
                dgMissionList.Items.Add(new MissionJson(mission));
            }
            return true;
        }
        // 运行游戏
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                if (dgMissionList.SelectedItem == null)
                {
                    return;
                }
                FileInfo file = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "spawn.ini");
                file.Delete();
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "spawn.ini", spawnIni.ToString());
                App.RunGame();
            }//*/
        }
        // 选择列表
        private void DgMissionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ml = (MissionJson)dgMissionList.SelectedItem;
            tbSummarys.Text = ml.Summary;
            spawnIni = new Spawn((JsonObject)ml.Spawn);
        }
    }
}

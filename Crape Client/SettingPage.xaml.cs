using System;
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
    /// SettingPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void DDrawSet(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                /*
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"Resource\\ts-ddraw.dll",
                    AppDomain.CurrentDomain.BaseDirectory + @"ts-ddraw.dll", true);
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + @"Resource\\ddraw.ini",
                    AppDomain.CurrentDomain.BaseDirectory + @"ddraw.ini", true);
                //*/
            }
            else
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"ddraw.ini");
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"ddraw.dll");
            }
        }
        private void ScreenSet_SelectionChanged(object sender, SelectionChangedEventArgs e) //调整分辨率
        {
            if ((sender as ComboBox).SelectedItem is ComboBoxItem cbi)
            {
                if (cbi.DataContext is c_ScreenWH wh)
                {
                   Crape_Client.Configs.GameConfigs.Width = (int)wh.Width;
                   Crape_Client.Configs.GameConfigs.Height = (int)wh.Height;
                }
            }
        }

        private struct c_ScreenWH
        {
            public uint Width { set; get; }
            public uint Height { set; get; }
            public c_ScreenWH(uint Width, uint Height)
            {
                this.Width = Width;
                this.Height = Height;
            }
        }

        private void cbxGraphics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var renderer = (Crape_Client.Tools.RendererJson)(sender as ComboBox).SelectedItem;
            string local = AppDomain.CurrentDomain.BaseDirectory, resdir = local + @"Resource\Renderers\";
            File.Copy(resdir + renderer.Dll, local + @"ddraw.dll", true);

            System.Diagnostics.Debug.WriteLine(renderer.Files.Count.ToString());
            if (renderer.Files.Count > 0)
            {
                foreach (var file in renderer.Files)
                {
                    System.Diagnostics.Debug.WriteLine(file);
                    File.Copy(resdir + file, local + file, true);
                }//DisplayMemberPath="Name"
            }
        }
    }
}

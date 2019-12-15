using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowX
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var v = MessageBoxX.Show("您确定要退出程序吗?", "您要退出吗?", this, MessageBoxButton.OKCancel, "InfoTheme");
            if (v != MessageBoxResult.OK)
                e.Cancel = true;
            else e.Cancel = false;
            return;
        }

        private void Battle_Checked(object sender, RoutedEventArgs e)
        {
            frame.Content = new BattlePage();
        }

        private void Setting_Checked(object sender, RoutedEventArgs e)
        {
            frame.Content = new SettingPage();
        }

        private void Exit_Checked(object sender, RoutedEventArgs e)
        {
            (sender as RadioButton).IsChecked = false;
            Close();
        }

        private void SaveLoader_Checked(object sender, RoutedEventArgs e)
        {
            frame.Content = new SaveLoaderPage();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            frame.Content = new SkirmishPage();
        }
    }
}

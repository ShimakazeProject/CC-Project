using System;
using System.Collections.Generic;
using System.Json;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Crape_Client.Tools
{
    public class SideJson
    {
        public string Name { get; private set; }
        public BitmapImage Image { get; private set; }
        public Brush Color { get; private set; }
        public SideJson(string name,string color, string img=null)
        {
            Name = name;
            Color =  new SolidColorBrush(System.Windows.Media.Color.FromRgb(
                Convert.ToByte(color.Substring(1, 2), 16),
                Convert.ToByte(color.Substring(3, 2), 16),
                Convert.ToByte(color.Substring(5, 2), 16)
            ));
            if (System.IO.File.Exists(img))
            {
                Image = new BitmapImage(new Uri(img, UriKind.RelativeOrAbsolute));
            }
        }
    }
}

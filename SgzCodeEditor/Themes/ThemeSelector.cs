using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SgzCodeEditor.Themes
{
    public class ThemeSelector
    {
        public static void SetTheme(bool isDark)
        {
            ResourceDictionary colors = Application.Current.Resources.MergedDictionaries[0];
            if (isDark)
                colors.Source = new Uri("/Themes/DarkColor.xaml", UriKind.Relative);
            else
                colors.Source = new Uri("/Themes/LightColor.xaml", UriKind.Relative);
        }
    }
}

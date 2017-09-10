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
            Application.Current.Resources.MergedDictionaries.Clear();

            if (isDark)
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Themes/DarkColor.xaml", UriKind.Relative) });
            else
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Themes/LightColor.xaml", UriKind.Relative) });

        }
    }
}

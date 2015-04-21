using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using LocalizatorHelper;

namespace PasGen
{
    /// <summary>
    /// Interaction logic for WindowSettings.xaml
    /// </summary>
    public partial class WindowSettings : Window
    {
        
        public WindowSettings(CultureInfo currentCulture)
        {
            
            InitializeComponent();
            if (currentCulture.IetfLanguageTag == "ru-RU") ComboBoxLanguage.Text = "RU";
            else if (currentCulture.IetfLanguageTag == "en-US") ComboBoxLanguage.Text = "EN";
            //ComboBoxLanguage.SelectedIndex = ComboBoxLanguage.Items.IndexOf(currentCulture.IetfLanguageTag);


            //ResourceManagerService.RegisterManager("MainWindowRes", MainWindowRes.ResourceManager, true);
        }

        public string Lang { get; set; }

       /* private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (((Button)e.OriginalSource).Content.ToString() == "RU")
                ResourceManagerService.ChangeLocale("ru-RU");
            else ResourceManagerService.ChangeLocale("en-EN");
        }*/

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Lang = ComboBoxLanguage.Text;
            DialogResult = true;
        }

       
    }
}

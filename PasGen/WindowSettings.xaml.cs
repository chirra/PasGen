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
          
        }

        public string Lang { get; set; }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (((Button)e.OriginalSource).Content.ToString() == "RU")
                ResourceManagerService.ChangeLocale("ru-RU");

            else ResourceManagerService.ChangeLocale("en-EN");
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Lang = ComboBoxLanguage.Text;
            DialogResult = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonRu_Click(object sender, RoutedEventArgs e)
        {
            ResourceManagerService.ChangeLocale("ru-RU");
        }

        private void ButtonEn_Click(object sender, RoutedEventArgs e)
        {
            ResourceManagerService.ChangeLocale("en-US");
        }


        private void ComboBoxLanguage_OnSelected(object sender, RoutedEventArgs e)
        {
            if (((ComboBox)sender).SelectedItem.ToString() == "RU")
                ResourceManagerService.ChangeLocale("ru-RU");
            if (((ComboBox)sender).SelectedItem.ToString() == "EN")
                ResourceManagerService.ChangeLocale("en-GB");

        }

        private void ComboBoxLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((ComboBoxItem)e.AddedItems[0]).Content as string;

            if (text == "RU")
                ResourceManagerService.ChangeLocale("ru-RU");
            if (text == "EN")
                ResourceManagerService.ChangeLocale("en-GB");
        }
    }
}

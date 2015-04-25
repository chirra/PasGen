using System.Globalization;
using System.Windows;
using System.Windows.Controls;
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
            
            ComboBoxLanguage.Text = currentCulture.TextInfo.CultureName;
        }


        public string Lang { get; set; }


        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Lang = ComboBoxLanguage.Text;
            DialogResult = true;
        }


        private void ComboBoxLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = ((ComboBoxItem)e.AddedItems[0]).Content as string;
            ResourceManagerService.ChangeLocale(text);
        }
    }
}

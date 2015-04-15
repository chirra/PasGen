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
using PasswordGenerator;

namespace PasGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
        {
            PasswordConditions passwordConditions = new PasswordConditions(
                (int)SliderVovelsFrequency.Value, 
                (int)SliderConsonantsFrequency.Value, 
                (int)SliderNumbersFrequency.Value,
                (int)SliderSimbolsFrequency.Value);

            Password password = new Password(Int32.Parse(TextBoxCharacters.Text), passwordConditions, true);
            ButtonCopyToClipboard01.Content = password.GetPassword();
        }
    }
}

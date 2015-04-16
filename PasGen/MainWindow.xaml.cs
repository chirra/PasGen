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

            PasswordConditions passwordConditions = new PasswordConditions()
            {
                charactersAmount = Int32.Parse(TextBoxCharacters.Text),
                valueVowels = (int)SliderVovelsFrequency.Value,
                valueConsonant = (int)SliderConsonantsFrequency.Value,
                valueNumbers = (int)SliderNumbersFrequency.Value,
                valueSimbols = (int)SliderSimbolsFrequency.Value,
                vowelsMustHave = (bool)CheckBoxVowelsMustHave.IsChecked,
                consonantMustHave = (bool)CheckBoxConsonantsMustHave.IsChecked,
                numbersMustHave = (bool)CheckBoxNumbersMustHave.IsChecked,
                simbolsMustHave = (bool)CheckBoxSimbolsMustHave.IsChecked,
                isPronounceable = (bool)CheckBoxPronounceable.IsChecked,
                isContainsCapsSimbols = (bool) CheckBoxCaps.IsChecked
            };

            PasswordFactory password  = new PasswordFactory(passwordConditions);
            ButtonCopyToClipboard01.Content = password.GetPassword();
            ButtonCopyToClipboard02.Content = password.GetPassword();
            ButtonCopyToClipboard03.Content = password.GetPassword();
            ButtonCopyToClipboard04.Content = password.GetPassword();
            ButtonCopyToClipboard05.Content = password.GetPassword();
            ButtonCopyToClipboard06.Content = password.GetPassword();
            ButtonCopyToClipboard07.Content = password.GetPassword();
            ButtonCopyToClipboard08.Content = password.GetPassword();
            ButtonCopyToClipboard09.Content = password.GetPassword();
            ButtonCopyToClipboard10.Content = password.GetPassword();

        }
    }
}

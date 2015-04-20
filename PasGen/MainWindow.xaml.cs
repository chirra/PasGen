using System;
using System.Collections.Generic;
using System.Configuration;
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
using Microsoft.Win32;
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
            try
            {
                RegistryKey myKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("PasGen");
                TextBoxCharacters.Text = myKey.GetValue("CharactersAmount").ToString();
                SliderVowelsFrequency.Value = Int32.Parse(myKey.GetValue("ValueVowels").ToString());
                SliderConsonantsFrequency.Value = Int32.Parse(myKey.GetValue("ValueConsonant").ToString());
                SliderNumbersFrequency.Value = Int32.Parse(myKey.GetValue("ValueNumbers").ToString());
                SliderSimbolsFrequency.Value = Int32.Parse(myKey.GetValue("ValueSimbols").ToString());
                CheckBoxVowelsMustHave.IsChecked = Boolean.Parse(myKey.GetValue("VowelsMustHave").ToString());
                CheckBoxConsonantsMustHave.IsChecked = Boolean.Parse(myKey.GetValue("ConsonantMustHave").ToString());
                CheckBoxNumbersMustHave.IsChecked = Boolean.Parse(myKey.GetValue("NumbersMustHave").ToString());
                CheckBoxSimbolsMustHave.IsChecked = Boolean.Parse(myKey.GetValue("SimbolsMustHave").ToString());
                CheckBoxPronounceable.IsChecked = Boolean.Parse(myKey.GetValue("IsPronounceable").ToString());
                CheckBoxCaps.IsChecked = Boolean.Parse(myKey.GetValue("IsContainsCapsSimbols").ToString());
                myKey.Close();
            }
            catch (Exception)
            {
                
                TextBoxCharacters.Text = "8";
            }
            
            
        }

        private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
        {

            PasswordConditions passwordConditions = new PasswordConditions()
            {
                charactersAmount = Int32.Parse(TextBoxCharacters.Text),
                valueVowels = (int)SliderVowelsFrequency.Value,
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                RegistryKey myKey = Registry.CurrentUser.CreateSubKey("Software\\PasGen");
                myKey.SetValue("CharactersAmount", TextBoxCharacters.Text);
                myKey.SetValue("ValueVowels", SliderVowelsFrequency.Value.ToString());
                myKey.SetValue("ValueConsonant", SliderConsonantsFrequency.Value.ToString());
                myKey.SetValue("ValueNumbers", SliderNumbersFrequency.Value.ToString());
                myKey.SetValue("ValueSimbols", SliderSimbolsFrequency.Value.ToString());

                myKey.SetValue("VowelsMustHave", CheckBoxVowelsMustHave.IsChecked.ToString());
                myKey.SetValue("ConsonantMustHave", CheckBoxConsonantsMustHave.IsChecked.ToString());
                myKey.SetValue("NumbersMustHave", CheckBoxNumbersMustHave.IsChecked.ToString());
                myKey.SetValue("SimbolsMustHave", CheckBoxSimbolsMustHave.IsChecked.ToString());
                myKey.SetValue("IsPronounceable", CheckBoxPronounceable.IsChecked.ToString());
                myKey.SetValue("IsContainsCapsSimbols", CheckBoxCaps.IsChecked.ToString());
                myKey.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Can't save settings to registry", "PasGen Error");
            }
        }

        private void ButtonCopyToClipboard01_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }

        private void ButtonCopyToClipboard02_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }

        private void ButtonCopyToClipboard03_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }

        private void ButtonCopyToClipboard04_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }

        private void ButtonCopyToClipboard05_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }

        private void ButtonCopyToClipboard06_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }

        private void ButtonCopyToClipboard07_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }

        private void ButtonCopyToClipboard08_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }

        private void ButtonCopyToClipboard09_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }

        private void ButtonCopyToClipboard10_Click(object sender, RoutedEventArgs e)
        {
            CommandCopyToClipboard(e.OriginalSource, null);
        }



        private void CommandCopyToClipboard(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, ((Button)sender).Content.ToString());
        }
    }
}

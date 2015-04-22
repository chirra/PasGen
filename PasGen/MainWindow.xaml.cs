using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Resources;
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
using System.Windows.Threading;
using LocalizatorHelper;
using Microsoft.Win32;
using PasswordGenerator;

namespace PasGen
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> allPasswordButtons = new List<Button>();
        private PasswordConditions passwordConditions = new PasswordConditions();

        public MainWindow()
        {
            InitializeComponent();
            ResourceManagerService.RegisterManager("MainWindowRes", MainWindowRes.ResourceManager, true);
            allPasswordButtons.Add(ButtonCopyToClipboard01);
            allPasswordButtons.Add(ButtonCopyToClipboard02);
            allPasswordButtons.Add(ButtonCopyToClipboard03);
            allPasswordButtons.Add(ButtonCopyToClipboard04);
            allPasswordButtons.Add(ButtonCopyToClipboard05);
            allPasswordButtons.Add(ButtonCopyToClipboard06);
            allPasswordButtons.Add(ButtonCopyToClipboard07);
            allPasswordButtons.Add(ButtonCopyToClipboard08);
            allPasswordButtons.Add(ButtonCopyToClipboard09);
            allPasswordButtons.Add(ButtonCopyToClipboard10);

            passwordConditions = MainOptions.LoadFromRegistry();
        }

        private void SavePasswordConditions()
        {
            passwordConditions.charactersAmount = Int32.Parse(TextBoxCharacters.Text);
            passwordConditions.valueVowels = (int) SliderVowelsFrequency.Value;
            passwordConditions.valueConsonant = (int) SliderConsonantsFrequency.Value;
            passwordConditions.valueNumbers = (int) SliderNumbersFrequency.Value;
            passwordConditions.valueSimbols = (int) SliderSimbolsFrequency.Value;
            passwordConditions.vowelsMustHave = (bool) CheckBoxVowelsMustHave.IsChecked;
            passwordConditions.consonantMustHave = (bool) CheckBoxConsonantsMustHave.IsChecked;
            passwordConditions.numbersMustHave = (bool) CheckBoxNumbersMustHave.IsChecked;
            passwordConditions.simbolsMustHave = (bool) CheckBoxSimbolsMustHave.IsChecked;
            passwordConditions.isPronounceable = (bool) CheckBoxPronounceable.IsChecked;
            passwordConditions.isContainsCapsSimbols = (bool) CheckBoxCaps.IsChecked;
        }

        private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
        {
            SavePasswordConditions();
            PasswordFactory password  = new PasswordFactory(passwordConditions);
            foreach (var button in allPasswordButtons)
            {
                button.Content = password.GetPassword();
                button.Background = Brushes.LightGray;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SavePasswordConditions();
            MainOptions.SaveToRegistry(passwordConditions);
        }


        private void CommandCopyToClipboard(string text)
        {
            Clipboard.SetData(DataFormats.Text, text);
        }


        private void ButtonCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
           ((Button) e.OriginalSource).Background = Brushes.Orange;
            CommandCopyToClipboard(((Button)e.OriginalSource).Content.ToString());
        }

       

        private void ButtonAllToClipboard_Click(object sender, RoutedEventArgs e)
        {
            string result="";
            foreach (var button in allPasswordButtons)
                result += button.Content.ToString() + "\n";

            CommandCopyToClipboard(result);
        }


      private void ButtonSettings_Click(object sender, RoutedEventArgs e)
      {
          WindowSettings windowSettings = new WindowSettings(CultureInfo.CurrentCulture);
          if (windowSettings.ShowDialog() == true)
          {
              if (windowSettings.Lang == "RU") ResourceManagerService.ChangeLocale("ru-RU");
              else if (windowSettings.Lang == "EN") ResourceManagerService.ChangeLocale("en-US"); ;
          }

          
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (((Button)e.OriginalSource).Content.ToString() == "RU")
                ResourceManagerService.ChangeLocale("ru-RU");
            else ResourceManagerService.ChangeLocale("en-US"); ;
        }

        private void RuMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            ResourceManagerService.ChangeLocale("ru-RU");
        }

        private void EnMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            ResourceManagerService.ChangeLocale("en-US");
        }

    }
}

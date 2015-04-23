using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
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
        //Dictionary<string, string> settings = MainOptions.LoadSettingsFromRegistry(); 

        public MainWindow()
        {
            InitializeComponent();

            // Localization
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ConfigurationManager.AppSettings["Locale"]);
            }
            catch (Exception)
            {
                Console.WriteLine("Error reading app settings");
            }

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
            PasswordConditionsToInterface();
        }


        private void PasswordConditionsToInterface()
        {
            TextBoxCharacters.Text = passwordConditions.charactersAmount.ToString();
            SliderVowelsFrequency.Value = passwordConditions.valueVowels;
            SliderConsonantsFrequency.Value = passwordConditions.valueConsonants;
            SliderNumbersFrequency.Value = passwordConditions.valueNumbers;
            SliderSimbolsFrequency.Value = passwordConditions.valueSimbols;
            CheckBoxVowelsMustHave.IsChecked = passwordConditions.vowelsMustHave;
            CheckBoxConsonantsMustHave.IsChecked = passwordConditions.consonantsMustHave;
            CheckBoxNumbersMustHave.IsChecked = passwordConditions.numbersMustHave;
            CheckBoxSimbolsMustHave.IsChecked = passwordConditions.simbolsMustHave;
            CheckBoxPronounceable.IsChecked = passwordConditions.isPronounceable;
            CheckBoxCaps.IsChecked = passwordConditions.isContainsCapsSimbols;
        }


        private void InterfaceToPasswordConditions()
        {
            passwordConditions.charactersAmount = Int32.Parse(TextBoxCharacters.Text);
            passwordConditions.valueVowels = (int) SliderVowelsFrequency.Value;
            passwordConditions.valueConsonants = (int) SliderConsonantsFrequency.Value;
            passwordConditions.valueNumbers = (int) SliderNumbersFrequency.Value;
            passwordConditions.valueSimbols = (int) SliderSimbolsFrequency.Value;
            passwordConditions.vowelsMustHave = (bool) CheckBoxVowelsMustHave.IsChecked;
            passwordConditions.consonantsMustHave = (bool) CheckBoxConsonantsMustHave.IsChecked;
            passwordConditions.numbersMustHave = (bool) CheckBoxNumbersMustHave.IsChecked;
            passwordConditions.simbolsMustHave = (bool) CheckBoxSimbolsMustHave.IsChecked;
            passwordConditions.isPronounceable = (bool) CheckBoxPronounceable.IsChecked;
            passwordConditions.isContainsCapsSimbols = (bool) CheckBoxCaps.IsChecked;
        }


        private void GetPassword()
        {
            PasswordFactory password = new PasswordFactory(passwordConditions);
            foreach (var button in allPasswordButtons)
            {
                string s = password.GetPassword();
                Dispatcher.BeginInvoke(new ThreadStart(delegate { button.Content = s; }));
            }
        }


        private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var button in allPasswordButtons)
                button.Background = Brushes.LightGray;

            InterfaceToPasswordConditions();
            Action action = new Action(GetPassword);
            Task task = new Task(action);
            task.Start();
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
            windowSettings.ShowDialog();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InterfaceToPasswordConditions();
            MainOptions.SaveToRegistry(passwordConditions);

            //Save Localization settings
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings["Locale"].Value = CultureInfo.CurrentCulture.IetfLanguageTag;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }


    }
}

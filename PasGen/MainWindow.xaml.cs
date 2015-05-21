using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LocalizatorHelper;
using PasswordGenerator;

namespace PasGen
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> allPasswordButtons = new List<Button>();
        private PasswordConditions passwordConditions = MainOptions.LoadPasswordConditionsFromRegistry();
        private Settings settings = MainOptions.LoadSettingsFromRegistry();
        

        public MainWindow()
        {
            InitializeComponent();

            // Localization
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(settings.Locale);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "PasGen Error");
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
            PasswordConditionsToInterface();
        }


        private void PasswordConditionsToInterface()
        {
            TextBoxCharacters.Text = passwordConditions.CharactersAmount.ToString();
            SliderVowelsFrequency.Value = passwordConditions.ValueVowels;
            SliderConsonantsFrequency.Value = passwordConditions.ValueConsonants;
            SliderNumbersFrequency.Value = passwordConditions.ValueNumbers;
            SliderSimbolsFrequency.Value = passwordConditions.ValueSimbols;
/*
            CheckBoxVowelsMustHave.IsChecked = passwordConditions.vowelsMustHave;
            CheckBoxConsonantsMustHave.IsChecked = passwordConditions.consonantsMustHave;
            CheckBoxNumbersMustHave.IsChecked = passwordConditions.numbersMustHave;
            CheckBoxSimbolsMustHave.IsChecked = passwordConditions.simbolsMustHave;
*/

            SliderVowelsFrequency.Value = passwordConditions.ValueVowels > 1 ? passwordConditions.ValueVowels : Convert.ToInt32(passwordConditions.VowelsMustHave);
            SliderConsonantsFrequency.Value = passwordConditions.ValueConsonants > 1 ? passwordConditions.ValueConsonants : Convert.ToInt32(passwordConditions.ConsonantsMustHave);
            SliderNumbersFrequency.Value = passwordConditions.ValueNumbers > 1 ? passwordConditions.ValueNumbers : Convert.ToInt32(passwordConditions.NumbersMustHave);
            SliderSimbolsFrequency.Value = passwordConditions.ValueSimbols > 1 ? passwordConditions.ValueSimbols : Convert.ToInt32(passwordConditions.SimbolsMustHave);
            
            CheckBoxPronounceable.IsChecked = passwordConditions.IsPronounceable;
            CheckBoxCaps.IsChecked = passwordConditions.IsContainsCapsSimbols;
        }


        private void InterfaceToPasswordConditions()
        {

            try
            {
                passwordConditions.CharactersAmount = Int32.Parse(TextBoxCharacters.Text);

                //if sliders values == 1, then only one appropriate simbol contains in password, i.e. MustHave password conditions is true
                passwordConditions.ValueVowels = (int)SliderVowelsFrequency.Value == 1 ? 0 : (int)SliderVowelsFrequency.Value;
                passwordConditions.ValueConsonants = (int)SliderConsonantsFrequency.Value == 1 ? 0 : (int)SliderConsonantsFrequency.Value;
                passwordConditions.ValueNumbers = (int)SliderNumbersFrequency.Value == 1 ? 0 : (int)SliderNumbersFrequency.Value;
                passwordConditions.ValueSimbols = (int)SliderSimbolsFrequency.Value == 1 ? 0 : (int)SliderSimbolsFrequency.Value;
/*
                passwordConditions.vowelsMustHave = (bool) CheckBoxVowelsMustHave.IsChecked;
                passwordConditions.consonantsMustHave = (bool) CheckBoxConsonantsMustHave.IsChecked;
                passwordConditions.numbersMustHave = (bool) CheckBoxNumbersMustHave.IsChecked;
                passwordConditions.simbolsMustHave = (bool) CheckBoxSimbolsMustHave.IsChecked;
*/
                passwordConditions.VowelsMustHave = SliderVowelsFrequency.Value > 0;
                passwordConditions.ConsonantsMustHave = SliderConsonantsFrequency.Value > 0;
                passwordConditions.NumbersMustHave = SliderNumbersFrequency.Value > 0;
                passwordConditions.SimbolsMustHave = SliderSimbolsFrequency.Value > 0;

                passwordConditions.IsPronounceable = (bool) CheckBoxPronounceable.IsChecked;
                passwordConditions.IsContainsCapsSimbols = (bool) CheckBoxCaps.IsChecked;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "PasGen Error");
            }
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
            {
                button.Background = Brushes.LightGray;
                button.FontWeight = FontWeights.Normal;
            }

            InterfaceToPasswordConditions();
            Action action = new Action(GetPassword);
            Task task = new Task(action);
            task.Start();
        }


        private void CommandCopyToClipboard(string text)
        {
            Thread thread = new Thread(() => Clipboard.SetText(text));
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join();
        }


        private void ButtonCopyToClipboard_Click(object sender, RoutedEventArgs e)
        {
            ((Button) e.OriginalSource).Background = Brushes.Orange;
            ((Button) e.OriginalSource).FontWeight = FontWeights.Bold;
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


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            InterfaceToPasswordConditions();
            MainOptions.SavePasswordConditionsToRegistry(passwordConditions);

            settings.Locale = CultureInfo.CurrentCulture.TextInfo.CultureName;
            MainOptions.SaveSettingsToRegistry(settings);
        }


        private void CheckBoxPronounceable_Checked(object sender, RoutedEventArgs e)
        {
                SliderVowelsFrequency.IsEnabled = false;
                SliderConsonantsFrequency.IsEnabled = false;
        }


        private void CheckBoxPronounceable_Unchecked(object sender, RoutedEventArgs e)
        {
            SliderVowelsFrequency.IsEnabled = true;
            SliderConsonantsFrequency.IsEnabled = true;
        }


    }
}

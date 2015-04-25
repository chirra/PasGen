﻿using System;
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

            try
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
            Clipboard.SetData(DataFormats.Text, text);
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


    }
}

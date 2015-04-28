using System;
using System.Globalization;
using System.Windows;
using Microsoft.Win32;
using PasswordGenerator;

namespace PasGen
{
    internal static class MainOptions
    {
        /// <summary>
        /// Load password conditions from registry or set to default values
        /// </summary>
        /// <returns></returns>
        internal static PasswordConditions LoadPasswordConditionsFromRegistry()
        {
            PasswordConditions passwordConditions;
            try
            {
                RegistryKey myKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("PasGen");
                passwordConditions.CharactersAmount = Int32.Parse(myKey.GetValue("CharactersAmount").ToString());
                passwordConditions.ValueVowels = Int32.Parse(myKey.GetValue("ValueVowels").ToString());
                passwordConditions.ValueConsonants = Int32.Parse(myKey.GetValue("ValueConsonant").ToString());
                passwordConditions.ValueNumbers = Int32.Parse(myKey.GetValue("ValueNumbers").ToString());
                passwordConditions.ValueSimbols = Int32.Parse(myKey.GetValue("ValueSimbols").ToString());
                passwordConditions.VowelsMustHave = Boolean.Parse(myKey.GetValue("VowelsMustHave").ToString());
                passwordConditions.ConsonantsMustHave = Boolean.Parse(myKey.GetValue("ConsonantMustHave").ToString());
                passwordConditions.NumbersMustHave = Boolean.Parse(myKey.GetValue("NumbersMustHave").ToString());
                passwordConditions.SimbolsMustHave = Boolean.Parse(myKey.GetValue("SimbolsMustHave").ToString());
                passwordConditions.IsPronounceable = Boolean.Parse(myKey.GetValue("IsPronounceable").ToString());
                passwordConditions.IsContainsCapsSimbols = Boolean.Parse(myKey.GetValue("IsContainsCapsSimbols").ToString());
                myKey.Close();
            }
            catch (Exception)
            {

                passwordConditions.CharactersAmount = 8;
                passwordConditions.ValueVowels = 2;
                passwordConditions.ValueConsonants = 2;
                passwordConditions.ValueNumbers = 2;
                passwordConditions.ValueSimbols = 2;
                passwordConditions.VowelsMustHave = false;
                passwordConditions.ConsonantsMustHave = false;
                passwordConditions.NumbersMustHave = false;
                passwordConditions.SimbolsMustHave = false;
                passwordConditions.IsPronounceable = true;
                passwordConditions.IsContainsCapsSimbols = true;
            }
            return passwordConditions;
        }


        /// <summary>
        /// Save password conditions to registry
        /// </summary>
        /// <param name="passwordConditions"></param>
        internal static void SavePasswordConditionsToRegistry(PasswordConditions passwordConditions)
        {
            try
            {
                RegistryKey myKey = Registry.CurrentUser.CreateSubKey("Software\\PasGen");
                myKey.SetValue("CharactersAmount", passwordConditions.CharactersAmount.ToString());
                myKey.SetValue("ValueVowels", passwordConditions.ValueVowels.ToString());
                myKey.SetValue("ValueConsonant", passwordConditions.ValueConsonants.ToString());
                myKey.SetValue("ValueNumbers", passwordConditions.ValueNumbers.ToString());
                myKey.SetValue("ValueSimbols", passwordConditions.ValueSimbols.ToString());

                myKey.SetValue("VowelsMustHave", passwordConditions.VowelsMustHave.ToString());
                myKey.SetValue("ConsonantMustHave", passwordConditions.ConsonantsMustHave.ToString());
                myKey.SetValue("NumbersMustHave", passwordConditions.NumbersMustHave.ToString());
                myKey.SetValue("SimbolsMustHave", passwordConditions.SimbolsMustHave.ToString());
                myKey.SetValue("IsPronounceable", passwordConditions.IsPronounceable.ToString());
                myKey.SetValue("IsContainsCapsSimbols", passwordConditions.IsContainsCapsSimbols.ToString());
                myKey.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Can't save settings to registry", "PasGen Error");
            }
        }

        /// <summary>
        /// Load app settings from registry or set to default values
        /// </summary>
        /// <returns></returns>
      internal static Settings LoadSettingsFromRegistry()
        {
            Settings result;
            try
            {

                RegistryKey myKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("PasGen");
                result.Locale = myKey.GetValue("Locale").ToString();
                myKey.Close();
            }
            catch (Exception)
            {
                result.Locale = CultureInfo.CurrentCulture.TextInfo.CultureName;
            }
            return result;
        }

        /// <summary>
        /// Save app settings to registry
        /// </summary>
        /// <param name="settings"></param>
        internal static void SaveSettingsToRegistry(Settings settings)
        {
            try
            {
                RegistryKey myKey = Registry.CurrentUser.CreateSubKey("Software\\PasGen");
                myKey.SetValue("Locale", settings.Locale);
                myKey.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't save settings to registry", "PasGen Error");
            }
        }

     
    }
}

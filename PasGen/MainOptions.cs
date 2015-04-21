﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using PasswordGenerator;

namespace PasGen
{
    internal static class MainOptions
    {
        internal static void SaveToRegistry(PasswordConditions passwordConditions)
        {
            try
            {
                RegistryKey myKey = Registry.CurrentUser.CreateSubKey("Software\\PasGen");
                myKey.SetValue("CharactersAmount", passwordConditions.charactersAmount.ToString());
                myKey.SetValue("ValueVowels", passwordConditions.valueVowels.ToString());
                myKey.SetValue("ValueConsonant", passwordConditions.valueConsonant.ToString());
                myKey.SetValue("ValueNumbers", passwordConditions.valueNumbers.ToString());
                myKey.SetValue("ValueSimbols", passwordConditions.valueSimbols.ToString());

                myKey.SetValue("VowelsMustHave", passwordConditions.vowelsMustHave.ToString());
                myKey.SetValue("ConsonantMustHave", passwordConditions.consonantMustHave.ToString());
                myKey.SetValue("NumbersMustHave", passwordConditions.numbersMustHave.ToString());
                myKey.SetValue("SimbolsMustHave", passwordConditions.simbolsMustHave.ToString());
                myKey.SetValue("IsPronounceable", passwordConditions.isPronounceable.ToString());
                myKey.SetValue("IsContainsCapsSimbols", passwordConditions.isContainsCapsSimbols.ToString());
                myKey.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Can't save settings to registry", "PasGen Error");
            }


        }

        internal static PasswordConditions LoadFromRegistry()
        {
            PasswordConditions passwordConditions;
            try
            {
                RegistryKey myKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("PasGen");
                passwordConditions.charactersAmount = Int32.Parse(myKey.GetValue("CharactersAmount").ToString());
                passwordConditions.valueVowels = Int32.Parse(myKey.GetValue("ValueVowels").ToString());
                passwordConditions.valueConsonant = Int32.Parse(myKey.GetValue("ValueConsonant").ToString());
                passwordConditions.valueNumbers = Int32.Parse(myKey.GetValue("ValueNumbers").ToString());
                passwordConditions.valueSimbols = Int32.Parse(myKey.GetValue("ValueSimbols").ToString());
                passwordConditions.vowelsMustHave = Boolean.Parse(myKey.GetValue("VowelsMustHave").ToString());
                passwordConditions.consonantMustHave = Boolean.Parse(myKey.GetValue("ConsonantMustHave").ToString());
                passwordConditions.numbersMustHave = Boolean.Parse(myKey.GetValue("NumbersMustHave").ToString());
                passwordConditions.simbolsMustHave = Boolean.Parse(myKey.GetValue("SimbolsMustHave").ToString());
                passwordConditions.isPronounceable = Boolean.Parse(myKey.GetValue("IsPronounceable").ToString());
                passwordConditions.isContainsCapsSimbols = Boolean.Parse(myKey.GetValue("IsContainsCapsSimbols").ToString());
                myKey.Close();
            }
            catch (Exception)
            {

                passwordConditions.charactersAmount = 8;
                passwordConditions.valueVowels = 2;
                passwordConditions.valueConsonant = 2;
                passwordConditions.valueNumbers = 2;
                passwordConditions.valueSimbols = 2;
                passwordConditions.vowelsMustHave = false;
                passwordConditions.consonantMustHave = false;
                passwordConditions.numbersMustHave = false;
                passwordConditions.simbolsMustHave = false;
                passwordConditions.isPronounceable = true;
                passwordConditions.isContainsCapsSimbols = true;
            }
            return passwordConditions;
        }

     
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public struct PasswordConditions
    {
        public int valueVowels;
        public int valueConsonant;
        public int valueNumbers;
        public int valueSimbols;
        

        public PasswordConditions(int valueVowels, int valueConsonant,int valueNumbers,  int valueSimbols)
        {
            this.valueVowels = valueVowels;
            this.valueConsonant = valueConsonant;
            this.valueNumbers = valueNumbers;
            this.valueSimbols = valueSimbols;
        }
    }
}

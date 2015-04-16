using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public struct PasswordConditions
    {
        public int charactersAmount;

        public int valueVowels;
        public int valueConsonant;
        public int valueNumbers;
        public int valueSimbols;

        public bool vowelsMustHave;
        public bool consonantMustHave;
        public bool numbersMustHave;
        public bool simbolsMustHave;

        public bool isPronounceable;
        public bool isContainsCapsSimbols;
        
    }
}

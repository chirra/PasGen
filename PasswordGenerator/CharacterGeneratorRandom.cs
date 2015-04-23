using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    class CharacterGeneratorRandom : CharacterGeneratorAbstract
    {

        protected override double[] GetProbabilityVector()
        {
            double v = (double)passwordConditions.valueVowels;
            double c = (double)passwordConditions.valueConsonants;
            double n = (double)passwordConditions.valueNumbers;
            double s = (double)passwordConditions.valueSimbols;

            return new[] { v / (v + c + n + s), c / (v + c + n + s), n / (v + c + n + s), s / (v + c + n + s) };
        }

        public CharacterGeneratorRandom(PasswordConditions passwordConditions)
        {
            this.passwordConditions = passwordConditions;
        }
    }
}

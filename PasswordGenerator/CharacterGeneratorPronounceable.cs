

namespace PasswordGenerator
{
    class CharacterGeneratorPronounceable : CharacterGeneratorAbstract
    {
        /// <summary>
        /// Return probabilkity vector, depends on the current character type and conditions of the password
        /// </summary>
        /// <returns></returns>
        protected override double[] GetProbabilityVector()
        {
            var v = (double)PasswordConditions.valueVowels;
            var c = (double)PasswordConditions.valueConsonants;
            var n = (double)PasswordConditions.valueNumbers;
            var s = (double)PasswordConditions.valueSimbols;


            double[][] probabilityMatrix =
            {
                new []{0, c/(c + n + s), n/(c + n + s), s/(c + n + s)},
                new []{v/(v+n+s), 0, n/(v+n+s), s/(v+n+s)}, 
                new []{v/(v+c), c/(v+c), 0, 0}, 
                new []{v/(v+c), c/(v+c), 0, 0}
            };

            return probabilityMatrix[(int)CurrentCharacterType];
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="passwordConditions"></param>
        /// <param name="currentCharacterType"></param>
        public CharacterGeneratorPronounceable(PasswordConditions passwordConditions, CharactersType currentCharacterType)
        {
            // fields of the base abstract class
            this.PasswordConditions = passwordConditions;
            this.CurrentCharacterType = currentCharacterType;
        }
    }
}

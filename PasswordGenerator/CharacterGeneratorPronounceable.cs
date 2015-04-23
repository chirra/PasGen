

namespace PasswordGenerator
{
    class CharacterGeneratorPronounceable : CharacterGeneratorAbstract
    {

        protected override double[] GetProbabilityVector()
        {
            var v = (double)passwordConditions.valueVowels;
            var c = (double)passwordConditions.valueConsonants;
            var n = (double)passwordConditions.valueNumbers;
            var s = (double)passwordConditions.valueSimbols;


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
        /// <param name="currentCharacterType"></param>
        public CharacterGeneratorPronounceable(PasswordConditions passwordConditions, CharactersType currentCharacterType)
        {
            this.passwordConditions = passwordConditions;
            CurrentCharacterType = currentCharacterType;
        }
    }
}

namespace PasswordGenerator
{
    class CharacterGeneratorRandom : CharacterGeneratorAbstract
    {
        /// <summary>
        /// Return random probability vector
        /// </summary>
        /// <returns></returns>
        protected override double[] GetProbabilityVector()
        {
            double v = (double)PasswordConditions.valueVowels;
            double c = (double)PasswordConditions.valueConsonants;
            double n = (double)PasswordConditions.valueNumbers;
            double s = (double)PasswordConditions.valueSimbols;

            return new[] { v / (v + c + n + s), c / (v + c + n + s), n / (v + c + n + s), s / (v + c + n + s) };
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="passwordConditions"></param>
        public CharacterGeneratorRandom(PasswordConditions passwordConditions)
        {
            this.PasswordConditions = passwordConditions;
        }
    }
}

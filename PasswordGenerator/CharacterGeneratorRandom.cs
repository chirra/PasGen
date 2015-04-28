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
            double v = (double)PasswordConditions.ValueVowels;
            double c = (double)PasswordConditions.ValueConsonants;
            double n = (double)PasswordConditions.ValueNumbers;
            double s = (double)PasswordConditions.ValueSimbols;

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

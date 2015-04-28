namespace PasswordGenerator
{
    public struct PasswordConditions
    {
        public int CharactersAmount;

        public int ValueVowels;
        public int ValueConsonants;
        public int ValueNumbers;
        public int ValueSimbols;

        public bool VowelsMustHave;
        public bool ConsonantsMustHave;
        public bool NumbersMustHave;
        public bool SimbolsMustHave;

        public bool IsPronounceable;
        public bool IsContainsCapsSimbols;
        
    }
}

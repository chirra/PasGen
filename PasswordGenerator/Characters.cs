using System;

namespace PasswordGenerator
{
    class Characters
    {
        private char[] vowels = {'a', 'e', 'i', 'o', 'u', 'y'};
        private char[] consonants = {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p'};

        Random random = new Random();
        public char GetRandomVowel()
        {
            return vowels[random.Next(vowels.Length)];
        }

        public char GetRandomConsonant()
        {
            return consonants[random.Next(consonants.Length)];
        }

    }
}

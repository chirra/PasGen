using System;

namespace PasswordGenerator
{
    class Characters
    {
        private char[] vowels = {'a', 'e', 'i', 'o', 'u', 'y'};
        private char[] consonants = {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z'};
        private char[] numbers = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private char[] simbols ={'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '/', '>', '<', '?'};

        Random random = new Random();
        public char GetRandomVowel()
        {
            return vowels[random.Next(vowels.Length)];
        }

        public char GetRandomConsonant()
        {
            return consonants[random.Next(consonants.Length)];
        }

        public char GetRandomNumber()
        {
            return numbers[random.Next(numbers.Length)];
        }
        public char GetRandomSimbol()
        {
            return simbols[random.Next(simbols.Length)];
        }

    }
}

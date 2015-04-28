using System;
using System.Linq;

namespace PasswordGenerator
{
    class Characters
    {
        private char[] vowels = {'a', 'e', 'o', 'u', 'y'};
        private char[] consonants = {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z'};
        private char[] numbers = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private char[] simbols ={'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=', '/', '>', '<', '?'};


        Random random = new Random();


        private char GetRandomVowel()
        {
            return vowels[random.Next(vowels.Length)];
        }


        private char GetRandomConsonant()
        {
            return consonants[random.Next(consonants.Length)];
        }


        private char GetRandomNumber()
        {
            return numbers[random.Next(numbers.Length)];
        }


        private char GetRandomSimbol()
        {
            return simbols[random.Next(simbols.Length)];
        }


        public char GetRandomCharacterByType(CharactersType characterType)
        {
            switch (characterType)
            {
                case CharactersType.Vowels:
                    return GetRandomVowel();
                case CharactersType.Consonants:
                    return GetRandomConsonant();
                case CharactersType.Numbers:
                    return GetRandomNumber();
                default:
                    return GetRandomSimbol();
            }
        }


        public CharactersType GetCharacterType(char character)
        {
            CharactersType result = CharactersType.Simbols;

            if (vowels.Contains(character)) result = CharactersType.Vowels;
            else if (consonants.Contains(character)) result = CharactersType.Consonants;
            else if (numbers.Contains(character)) result = CharactersType.Numbers;
            
            return result;
        }
    }
}

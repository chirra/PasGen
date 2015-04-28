using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PasswordGenerator
{
    public class PasswordFactory
    {
        private PasswordConditions passwordConditions;
        private Characters characters = new Characters();
        private Random random = new Random();


        /// <summary>
        /// Run process of generating password
        /// </summary>
        /// <returns></returns>
        public string GetPassword()
        {
            StringBuilder password = new StringBuilder();
            
            CharactersType currentCharacterType = random.Next(2) == 1 ? CharactersType.Vowels : CharactersType.Consonants;
            

            //If password must contains one or more concrete type of character, add this type to mustHaveCharactersGroups
            List<CharactersType> mustHaveCharactersGroups = new List<CharactersType>();
            if (passwordConditions.VowelsMustHave) mustHaveCharactersGroups.Add(CharactersType.Vowels);
            if (passwordConditions.ConsonantsMustHave) mustHaveCharactersGroups.Add(CharactersType.Consonants);
            if (passwordConditions.NumbersMustHave) mustHaveCharactersGroups.Add(CharactersType.Numbers);
            if (passwordConditions.SimbolsMustHave) mustHaveCharactersGroups.Add(CharactersType.Simbols);
           
            //Character Generator initialization
            CharacterGeneratorAbstract characterGenerator;
            if (passwordConditions.IsPronounceable)
                characterGenerator = new CharacterGeneratorPronounceable(passwordConditions, currentCharacterType);
            else
                characterGenerator = new CharacterGeneratorRandom(passwordConditions);

            //Get simbol
            for (int i = password.Length; i < passwordConditions.CharactersAmount; i++)
            {
                char someCharacter = characterGenerator.GetSimbol();
                currentCharacterType = characters.GetCharacterType(someCharacter);

                //Random CAPS, if CAPS condition is true
                if (passwordConditions.IsContainsCapsSimbols)
                    someCharacter = random.Next(2) == 1 ? Char.ToUpper(someCharacter) : someCharacter;

                password.Append(someCharacter);
                mustHaveCharactersGroups.Remove(currentCharacterType);
                Thread.Sleep(2); //Random correction time, random.next() works incorrectly without it
            }

            //if mustHaveCharactersGroups contains simbols, append it to our password
            foreach (var characterType in mustHaveCharactersGroups)
            {
                password[random.Next(password.Length)] = characters.GetRandomCharacterByType(characterType);
            }

            return password.ToString();
        }

    
        public PasswordFactory(PasswordConditions passwordConditions)
        {
            this.passwordConditions = passwordConditions;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            
            CharactersType currentCharacterType = CharactersType.Consonants;
            if (password.Length>0)
                currentCharacterType = characters.GetCharacterType(password[password.Length-1]);

            List<CharactersType> mustHaveSimbolGroups = new List<CharactersType>();
            if (passwordConditions.vowelsMustHave) mustHaveSimbolGroups.Add(CharactersType.Vowels);
            if (passwordConditions.consonantMustHave) mustHaveSimbolGroups.Add(CharactersType.Consonants);
            if (passwordConditions.numbersMustHave) mustHaveSimbolGroups.Add(CharactersType.Numbers);
            if (passwordConditions.simbolsMustHave) mustHaveSimbolGroups.Add(CharactersType.Simbols);
           

            CharacterGeneratorAbstract characterGenerator;
            if (passwordConditions.isPronounceable)
                characterGenerator = new CharacterGeneratorPronounceable(passwordConditions, currentCharacterType);
            else
                characterGenerator = new CharacterGeneratorRandom(passwordConditions);

            char someCharacter;
            for (int i = password.Length; i < passwordConditions.charactersAmount; i++)
            {
                someCharacter = characterGenerator.GetSimbol();
                currentCharacterType = characters.GetCharacterType(someCharacter);
                if ((passwordConditions.isContainsCapsSimbols) && (currentCharacterType == CharactersType.Consonants || currentCharacterType == CharactersType.Vowels))
                    someCharacter = random.Next(2) == 1 ? Char.ToUpper(someCharacter) : someCharacter;
                password.Append(someCharacter);
                mustHaveSimbolGroups.Remove(currentCharacterType);
                Thread.Sleep(2); //random correction time
            }

            foreach (var characterType in mustHaveSimbolGroups)
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

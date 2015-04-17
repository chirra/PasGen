using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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
            
            password.Append(GetMustHaveSimbols()); // If password must have some type of characters, generate it
            
            CharactersType currentCharacterType = CharactersType.Consonants;
            if (password.Length>0)
                currentCharacterType = characters.GetCharacterType(password[password.Length-1]);


            CharacterGeneratorAbstract characterGenerator;
            if (passwordConditions.isPronounceable)
                characterGenerator = new CharacterGeneratorPronounceable(passwordConditions, currentCharacterType);
            else
                characterGenerator = new CharacterGeneratorRandom(passwordConditions);

            char simbol;
            for (int i = password.Length; i < passwordConditions.charactersAmount; i++)
            {
                simbol = characterGenerator.GetSimbol();
                password.Append(simbol);
                Thread.Sleep(1);
            }
            return password.ToString();
        }


        /// <summary>
        /// If password must have some type of characters, generate it
        /// </summary>
        /// <returns></returns>
        private string GetMustHaveSimbols()
        {
            StringBuilder result = new StringBuilder("");
            if (passwordConditions.vowelsMustHave)
                result.Append(characters.GetRandomCharacterByType(CharactersType.Vowels));
            if (passwordConditions.consonantMustHave)
                result.Append(characters.GetRandomCharacterByType(CharactersType.Consonants));
            if (passwordConditions.numbersMustHave)
                result.Append(characters.GetRandomCharacterByType(CharactersType.Numbers));
            if (passwordConditions.simbolsMustHave)
                result.Append(characters.GetRandomCharacterByType(CharactersType.Simbols));

            // Mix characters
            for (int i = 0; i < result.Length; i++)
            {
                int hlpIndex = random.Next(result.Length);
                char hlp = result[i];
                result[i] = result[hlpIndex];
                result[hlpIndex] = hlp;
            }
            return result.ToString();
        }


        public PasswordFactory(PasswordConditions passwordConditions)
        {
            this.passwordConditions = passwordConditions;
        }
    }
}

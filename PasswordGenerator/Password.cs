using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public class Password
    {
        private bool pronounceable;
        private PasswordConditions passwordConditions;
        private int charactersAmount;
        //private string password = "";
/*
        public string Password
        {
            get { return getPassword(); }
        }
*/

        public string GetPassword()
        {
            //Добавить сюда предварительные условия для маст хев символов
            CharactersType currentCharacterType = CharactersType.Vovels;
            string password = "";

            for (int i = 0; i < charactersAmount; i++)
            {
                char simbol = GetNextSimbol(currentCharacterType);
                password += simbol;
            }
            return password;
        }


        Random random = new Random();
        private char GetNextSimbol(CharactersType currentCharacterType)
        {
            
            double randomCube = random.NextDouble();
            double[] probabilityVector = GetProbabilityVector(currentCharacterType);
            double sumPVectorElement = 0;
            CharactersType ct = 0;
            char result = ' ';

            foreach (double p in probabilityVector)
            {
                sumPVectorElement += p;
                if (randomCube > sumPVectorElement)
                {
                    ct++;
                    //continue;

                }
                else
                {
                    result = GetCharacterByType(ct);
                    break;

                }
                
            }

            return result;

        }

        Characters characters = new Characters();
        private char GetCharacterByType(CharactersType ct)
        {
            if (ct == CharactersType.Vovels) return characters.GetRandomVowel();
            else return characters.GetRandomConsonant();
        }

        private double[] GetProbabilityVector(CharactersType currentCharacterType)
        {
            int sumValues = passwordConditions.valueVowels + passwordConditions.valueConsonant +
                            passwordConditions.valueNumbers + passwordConditions.valueSimbols;
            double vovelProbability = (double)passwordConditions.valueVowels / (double)sumValues;
            double consonantProbability = (double)passwordConditions.valueConsonant / (double)sumValues;
            double numbersProbability = (double)passwordConditions.valueNumbers / (double)sumValues;
            double simbolsProbability = (double)passwordConditions.valueSimbols / (double)sumValues;

            return new[]{vovelProbability, consonantProbability, numbersProbability, simbolsProbability};
        }

        public Password(int charactersAmount, PasswordConditions passwordConditions, bool pronounceable = true)
        {
            this.charactersAmount = charactersAmount;
            this.passwordConditions = passwordConditions;
            this.pronounceable = pronounceable;
        }
    }
}

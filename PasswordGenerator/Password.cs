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
                char simbol = GetNextSimbol(ref currentCharacterType);
                password += simbol;
            }
            return password;
        }


        Random random = new Random();
        private char GetNextSimbol(ref CharactersType currentCharacterType)
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
                }
                else
                {
                    result = GetCharacterByType(ct);
                    currentCharacterType = ct;
                    break;

                }
                
            }

            return result;

        }


        Characters characters = new Characters();
        private char GetCharacterByType(CharactersType ct)
        {
            switch (ct)
            {
                case CharactersType.Vovels:
                    return characters.GetRandomVowel();
                case CharactersType.Consonant:
                    return characters.GetRandomConsonant();
                case CharactersType.Numbers:
                    return characters.GetRandomNumber();
                default:
                    return characters.GetRandomSimbol();
            }
        }


        private double[] GetProbabilityVector(CharactersType currentCharacterType)
        {
            /*int sumValues = passwordConditions.valueVowels + passwordConditions.valueConsonant +
                            passwordConditions.valueNumbers + passwordConditions.valueSimbols;
            double vovelProbability = (double)passwordConditions.valueVowels / (double)sumValues;
            double consonantProbability = (double)passwordConditions.valueConsonant / (double)sumValues;
            double numbersProbability = (double)passwordConditions.valueNumbers / (double)sumValues;
            double simbolsProbability = (double)passwordConditions.valueSimbols / (double)sumValues;*/

            double v = (double) passwordConditions.valueVowels;
            double c = (double) passwordConditions.valueConsonant;
            double n = (double) passwordConditions.valueNumbers;
            double s = (double) passwordConditions.valueSimbols;


            double[][] probabilityMatrix =
            {
                new []{0, c/(c + n + s), n/(c + n + s), s/(c + n + s)},
                new []{v/(v+n+s), 0, n/(v+n+s), s/(v+n+s)}, 
                new []{v/(v+c+s), c/(v+c+s), 0, 0}, 
                new []{v/(v+c+n), v/(v+c+n), 0, 0}
            };


            //return new[]{vovelProbability, consonantProbability, numbersProbability, simbolsProbability};
            return probabilityMatrix[(int)currentCharacterType];
        }


        public Password(int charactersAmount, PasswordConditions passwordConditions, bool pronounceable = true)
        {
            this.charactersAmount = charactersAmount;
            this.passwordConditions = passwordConditions;
            this.pronounceable = pronounceable;
        }
    }
}

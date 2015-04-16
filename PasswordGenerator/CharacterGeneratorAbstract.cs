using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    abstract class CharacterGeneratorAbstract
    {

        private Random random = new Random();
        Characters characters = new Characters();
        protected PasswordConditions passwordConditions;


        public CharactersType CurrentCharacterType { get; set; }
    

        //public abstract char GetNextSimbol();

        protected abstract double[] GetProbabilityVector();
    
        public char GetSimbol()
        {
            double[] probabilityVector = GetProbabilityVector();
            double randomCube = random.NextDouble();
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
                    result = characters.GetCharacterByType(ct);
                    CurrentCharacterType = ct;
                    break;
                }

            }

            return result;
        }

    }
}

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
    

        protected abstract double[] GetProbabilityVector();
    
        
        public char GetSimbol()
        {
            double[] probabilityVector = GetProbabilityVector();
            double randomCube = random.NextDouble();
            double sumPVectorElement = 0;
            CurrentCharacterType = 0;
            
            foreach (double p in probabilityVector)
            {
                sumPVectorElement += p;
                if (sumPVectorElement < randomCube)
                    CurrentCharacterType++;
                else
                    return characters.GetRandomCharacterByType(CurrentCharacterType);
            }

            return ' ';
        }

    }
}

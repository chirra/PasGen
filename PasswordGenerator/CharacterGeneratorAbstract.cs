using System;
using System.Security.Cryptography;

namespace PasswordGenerator
{
    abstract class CharacterGeneratorAbstract
    {

        //private readonly RNGCryptoServiceProvider _random = new RNGCryptoServiceProvider();
        private readonly Random _random = new Random();
        private readonly Characters _characters = new Characters();
        protected PasswordConditions PasswordConditions;


        public CharactersType CurrentCharacterType { get; set; }
    

        /// <summary>
        /// Contains a vector of probabilities, depends on concrete implementation 
        /// </summary>
        /// <returns></returns>
        protected abstract double[] GetProbabilityVector();
    
        
        /// <summary>
        /// Return simbol of the password
        /// </summary>
        /// <returns></returns>
        public char GetSimbol()
        {
            //Values init
            double[] probabilityVector = GetProbabilityVector();
            double randomCube = _random.NextDouble(); //throw a cube
            double sumPVectorElement = 0;
            CurrentCharacterType = 0;
            

            foreach (double p in probabilityVector)
            {
                sumPVectorElement += p;
                if (sumPVectorElement < randomCube)
                    CurrentCharacterType++;
                else
                    return _characters.GetRandomCharacterByType(CurrentCharacterType);
            }

            return ' ';
        }

    }
}

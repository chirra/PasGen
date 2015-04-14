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
        private int quantities;
/*
        public string Password
        {
            get { return getPassword(); }
        }
*/

        public string GetPassword()
        {
            return "OK";
        }

        public Password(int quantities, PasswordConditions passwordConditions, bool pronounceable = true)
        {
            this.quantities = quantities;
            this.passwordConditions = passwordConditions;
            this.pronounceable = pronounceable;
        }
    }
}

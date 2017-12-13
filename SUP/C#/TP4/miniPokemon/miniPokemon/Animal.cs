using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;

namespace miniPokemon
{
    public class Animal
    {
        #region Constructor

        private string name;

        public Animal(string name)
        {
            this.name = name;
        }

        #endregion Constructor
        
        #region Methods

        public virtual void WhoAmI()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public virtual void Describe()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public void Rename(string NewName)
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        #endregion Methods
        
    }
}

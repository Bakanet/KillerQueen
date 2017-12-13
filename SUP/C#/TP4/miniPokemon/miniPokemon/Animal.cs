using System;
using System.Collections.Generic;
using System.Reflection;

namespace miniPokemon
{
    public class Animal
    {
        #region Constructor

        public Animal(string name)
        {
            // TODO
            throw new TargetInvocationException(new InvalidOperationException("Constructor is not implemented yet"));
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

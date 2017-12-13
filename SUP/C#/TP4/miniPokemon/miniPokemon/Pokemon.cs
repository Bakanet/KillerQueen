using System;
using System.Collections.Generic;
using System.Reflection;

namespace miniPokemon
{
    public class Pokemon : Animal
    {
        public enum Poketype
        {
            POISON,
            FIRE,
            WATER,
            GRASS,
            ELECTRICK
        };

        #region Constructor

        
        public Pokemon(string name, int life, int damage, Poketype poketype)
        : base(name)
        {
            // TODO
            throw new TargetInvocationException(new InvalidOperationException("Constructor is not implemented yet"));
        }

        #endregion Constructor
        

        #region Methods

        
        public override void WhoAmI()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public override void Describe()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }
        
        public void LevelUp()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public int Attack()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public void GetHurt(int damage)
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public void Heal(int life)
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        #endregion Methods
        
    }
}

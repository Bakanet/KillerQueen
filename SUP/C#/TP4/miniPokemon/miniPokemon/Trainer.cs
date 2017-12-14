using System;
using System.Collections.Generic;
using System.Reflection;

namespace miniPokemon
{
    class Trainer : Animal
    {
        #region Constructor

        private int age;

        public int Age
        {
            get => age;
            set => age = value;
        }

        public Trainer(string name, int age)
        : base(name)
        {
            this.age = age;
            listPokemon = new List<Pokemon>();
        }

        #endregion Constructor

        private List<Pokemon> listPokemon;

        #region Methods

        public override void WhoAmI()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public int NumberOfPokemon()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public override void Describe()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public void Birthday()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public void MyPokemon()
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }

        public void CatchAPokemon(Pokemon pokemon)
        {
            // TODO
            throw new NotImplementedException("Please fix this quickly");
        }
        
        #endregion Methods
    }
}

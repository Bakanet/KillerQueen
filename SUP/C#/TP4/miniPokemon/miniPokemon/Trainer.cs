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
            get { return age; }
            set { age = value; }
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
            Console.WriteLine("I'm a Pokemon trainer !");
        }

        public int NumberOfPokemon()
        {
            int nb = 0;
            foreach (var pomon in listPokemon)
            {
                ++nb;
            }
            return nb;
        }

        public override void Describe()
        {
            Console.WriteLine("My name is " + Name + ", I'm " + age + " and I have " + NumberOfPokemon() + " Pokemons !");
        }

        public void Birthday()
        {
            ++Age;
        }

        public void MyPokemon()
        {
            Console.WriteLine("My Pokemon are :");
            foreach (var pomon in listPokemon)
            {
                Console.WriteLine("- " + pomon.Name);
            }
        }

        public void CatchAPokemon(Pokemon pokemon)
        {
            listPokemon.Add(pokemon);
        }

        public void ReleaseAPokemon(Pokemon pokemon)
        {
            listPokemon.Remove(pokemon);
        }
        
        #endregion Methods
    }
}

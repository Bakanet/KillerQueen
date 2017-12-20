using System;
using System.Collections.Generic;
using System.Globalization;
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

        private int life;
        private int damage;
        private int level;
        private bool isKO;
        private Poketype poketype;

        public bool IsKo
        {
            get { return isKO; }
            set { isKO = value; }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }


        public Pokemon(string name, int life, int damage, Poketype poketype)
        : base(name)
        {
            this.poketype = poketype;
            this.life = life;
            this.damage = damage;
            level = 1;
        }

        #endregion Constructor
        

        #region Methods

        
        public override void WhoAmI()
        {
            Console.WriteLine("I'm a Pokemon");
        }

        public override void Describe()
        {
            Console.WriteLine("My name is " + Name + " I'm a Pokemon of type " + poketype + " and I'm level " + level);
        }
        
        public void LevelUp()
        {
            level += 1;
        }

        public int Attack()
        {
            Console.WriteLine(Name + " uses cut, it's super effective");
            return damage;
        }

        public void GetHurt(int damage)
        {
            life -= damage;
            if (life <= 0)
            {
                life = 0;
                isKO = true;
            }
            
        }

        public void Heal(int life)
        {
            this.life += life;
            isKO = false;
        }

        #endregion Methods
        
    }
}

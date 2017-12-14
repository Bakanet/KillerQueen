using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace miniPokemon
{
    public enum Poketype
    {
        None,
        NORMAL,
        FIRE,
        GRASS,
        WATER,
        ELECTRICK,
        FLY,
        ROCK,
        GROUND,
        STEEL,
        PSY,
        DARK,
        FAIRY,
        DRAGON,
        GHOST,
        FIGHT,
        INSECT,
        POISON,
        ICE
    };
    
    public class stratPokemon
    {
        #region Constructor

        private string name;
        private Poketype type;
        private Poketype type2;
        private List<int> stats;
        private bool isKO;
        private int life;
        // attaques

        public stratPokemon(string name)
        {
            this.name = name;
            stats = new List<int>();
        }




        #endregion

        #region Methods

        public void GetHurt(int damage)
        {
            life -= damage;
            if (life <= 0)
            {
                life = 0;
                isKO = true;
            }
        }

        public void Heal(int heal)
        {
            life += life;
            isKO = false;
        }

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;

namespace miniPokemon
{

    public class stratPokemon
    {
        #region Constructor

        private Pomon name;
        private Poketype type;
        private Poketype type2;
        private List<int> stats;
        private bool isKO;
        private int life;
        private State state;
        // attaques

        public stratPokemon(Pomon name)
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

        public void StateChange(State state)
        {
            if (state == miniPokemon.State.BRN || state == State.PSN || state == State.LeechSeed)
            {
                life -= life / 12;
                Console.WriteLine(name + " prend des dégâts de statut.");
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Security.Cryptography;

namespace miniPokemon
{
    public class Stats    // HP - Atk - Def - SpA - SpD - Spe - Type1 - Type2
    {
        public int HP { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int SpA { get; set; }
        public int SpD { get; set; }
        public int Spe { get; set; }
        public Poketype Type1 { get; set; }
        public Poketype Type2 { get; set; }
        public Move Attack1 { get; set; }
        public Move Attack2 { get; set; }
        public Move Attack3 { get; set; }
        public Move Attack4 { get; set; }
    }

    public class StratPokemon
    {
        #region Constructor

        private Pomon pokemon;
        public Pomon Pokemon => pokemon;
        private string name;
        public string Name => name;
        private Poketype type;
        private Poketype type2;
        private bool isKO;
        public bool IsKo => isKO;
        private int maxlife;
        public int Maxlife => maxlife;
        private int life;
        public int Life => life;
        private State state;
        public Dictionary<Pomon, Stats> Poke;
        private Attack[,] moves;
        // attaques

        public StratPokemon(Pomon pokemon, string name)
        {
            this.pokemon = pokemon;
            this.name = name;
            Poke = new Dictionary<Pomon, Stats>
            {
                {Pomon.AlakazamMega, new Stats {HP = 55, Atk = 50, Def = 65, SpA = 175, SpD = 105, Spe = 150, Type1 = Poketype.PSYCHIC}},
                {Pomon.Bisharp, new Stats {HP = 65, Atk = 125, Def = 100, SpA = 60, SpD = 70, Spe = 70, Type1 = Poketype.DARK, Type2 = Poketype.STEEL}},
                {Pomon.Blacephalon, new Stats {HP = 53, Atk = 127, Def = 53, SpA = 151, SpD = 79, Spe = 107, Type1 = Poketype.FIRE, Type2 = Poketype.GHOST}},
                {Pomon.Celesteela, new Stats {HP = 97, Atk = 101, Def = 103, SpA = 107, SpD = 101, Spe = 61, Type1 = Poketype.STEEL, Type2 = Poketype.FLYING}},
                {Pomon.Chansey, new Stats {HP = 250, Atk = 5, Def = 5, SpA = 35, SpD = 105, Spe = 50, Type1 = Poketype.NORMAL}},
                {Pomon.CharizardMegaX, new Stats {HP = 78, Atk = 130, Def = 111, SpA = 130, SpD = 85, Spe = 100, Type1 = Poketype.FIRE, Type2 = Poketype.DRAGON, Attack1 = new Move(Attack.FlareBlitz), Attack2 = new Move(Attack.DragonDance), Attack3 = new Move(Attack.Outrage), Attack4 = new Move(Attack.Roost)}}
            };
            maxlife = ((((2 * Poke[pokemon].HP) * 100)) / 100) + 110;
            life = maxlife;
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
                Console.WriteLine(name + " is KO !");
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
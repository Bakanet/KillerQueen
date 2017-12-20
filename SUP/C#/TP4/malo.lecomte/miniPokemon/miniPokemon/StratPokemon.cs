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
        public Attack Attack1 { get; set; }
        public Attack Attack2 { get; set; }
        public Attack Attack3 { get; set; }
        public Attack Attack4 { get; set; }
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

        public Dictionary<Pomon, Stats> Poke;
        private Attack[,] moves;
        // attaques

        public StratPokemon(Pomon pokemon, string name)
        {
            this.pokemon = pokemon;
            this.name = name;
            Poke = new Dictionary<Pomon, Stats>
            {
                {Pomon.AlakazamMega, new Stats {HP = 55, Atk = 50, Def = 65, SpA = 175, SpD = 105, Spe = 150, Type1 = Poketype.PSYCHIC, Attack1 = Attack.Psychic, Attack2 = Attack.FocusBlast, Attack3 = Attack.ShadowBall, Attack4 = Attack.Psyshock}},
                {Pomon.Blacephalon, new Stats {HP = 53, Atk = 127, Def = 53, SpA = 151, SpD = 79, Spe = 107, Type1 = Poketype.FIRE, Type2 = Poketype.GHOST, Attack1 = Attack.ShadowBall, Attack2 = Attack.Flamethrower, Attack3 = Attack.FireBlast, Attack4 = Attack.Overheat}},
                {Pomon.CharizardMegaX, new Stats {HP = 78, Atk = 130, Def = 111, SpA = 130, SpD = 85, Spe = 100, Type1 = Poketype.FIRE, Type2 = Poketype.DRAGON, Attack1 = Attack.FlareBlitz, Attack2 = Attack.DragonRush, Attack3 = Attack.Outrage, Attack4 = Attack.Flamethrower}},
                {Pomon.DiancieMega, new Stats {HP = 50, Atk = 160, Def = 110, SpA = 160, SpD = 110, Spe = 110, Type1 = Poketype.ROCK, Type2 = Poketype.FAIRY, Attack1 = Attack.Moonblast, Attack2 = Attack.DiamondStorm, Attack3 = Attack.Flamethrower, Attack4 = Attack.EarthPower}},
                {Pomon.Dragonite, new Stats {HP = 91, Atk = 134, Def = 95, SpA = 100, SpD = 100, Spe = 80, Type1 = Poketype.DRAGON, Type2 = Poketype.FLYING, Attack1 = Attack.Earthquake, Attack2 = Attack.ExtremeSpeed, Attack3 = Attack.DragonRush, Attack4 = Attack.Hurricane}},
                {Pomon.Garchomp, new Stats {HP = 108, Atk = 130, Def = 95, SpA = 80, SpD = 85, Spe = 120, Type1 = Poketype.DRAGON, Type2 = Poketype.GROUND, Attack1 = Attack.Earthquake, Attack2 = Attack.FireBlast, Attack3 = Attack.Outrage, Attack4 = Attack.DragonRush}},
                {Pomon.Gengar, new Stats {HP = 60, Atk = 65, Def = 60, SpA = 130, SpD = 75, Spe = 110, Type1 = Poketype.GHOST, Type2 = Poketype.POISON, Attack1 = Attack.DarkPulse, Attack2 = Attack.FocusBlast, Attack3 = Attack.ShadowBall, Attack4 = Attack.SludgeWave}}
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
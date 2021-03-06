﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Xml.Schema;
using Microsoft.Win32;

namespace miniPokemon
{
    public class MoveStats
    {
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public string Kind { get; set; }
        public Poketype Type { get; set; }
    }
    
    public class Move
    {
        #region Constructor

        private static Attack name;
        public Attack Name => name;

        public static Dictionary<Attack, MoveStats> PokeAttack;

        public Move(Attack name)
        {
           
            PokeAttack = new Dictionary<Attack, MoveStats>()
            {
                {Attack.Psychic, new MoveStats{Power = 90, Accuracy = 100, Kind = "special", Type = Poketype.PSYCHIC}},
                {Attack.FocusBlast, new MoveStats{Power = 120, Accuracy = 70, Kind = "special", Type = Poketype.FIGHT}},
                {Attack.ShadowBall, new MoveStats{Power = 80, Accuracy = 100, Kind = "special", Type = Poketype.GHOST}},
                {Attack.FlareBlitz, new MoveStats {Power = 120, Accuracy = 100, Kind = "physique", Type = Poketype.FIRE}},
                {Attack.Flamethrower, new MoveStats {Power = 90, Accuracy = 100, Kind = "special", Type = Poketype.FIRE}},
                {Attack.FireBlast, new MoveStats {Power = 110, Accuracy = 85, Kind = "special", Type = Poketype.FIRE}},
                {Attack.Overheat, new MoveStats {Power = 130, Accuracy = 90, Kind = "special", Type = Poketype.FIRE}},
                {Attack.Psyshock, new MoveStats {Power = 80, Accuracy = 100, Kind = "special", Type = Poketype.PSYCHIC}},
                {Attack.Moonblast, new MoveStats {Power = 95, Accuracy = 100, Kind = "special", Type = Poketype.FAIRY}},
                {Attack.DiamondStorm, new MoveStats {Power = 100, Accuracy = 95, Kind = "physique", Type = Poketype.ROCK}},
                {Attack.EarthPower, new MoveStats {Power = 90, Accuracy = 100, Kind = "special", Type = Poketype.GROUND}},
                {Attack.Earthquake, new MoveStats {Power = 100, Accuracy = 100, Kind = "physique", Type = Poketype.GROUND}},
                {Attack.DragonRush, new MoveStats {Power = 100, Accuracy = 75, Kind = "physique", Type = Poketype.DRAGON}},
                {Attack.Hurricane, new MoveStats {Power = 110, Accuracy = 70, Kind = "special", Type = Poketype.FLYING}},
                {Attack.ExtremeSpeed, new MoveStats {Power = 80, Accuracy = 100, Kind = "physique", Type = Poketype.NORMAL}},
                {Attack.DarkPulse, new MoveStats {Power = 80, Accuracy = 100, Kind = "special", Type = Poketype.DARK}},
                {Attack.SludgeWave, new MoveStats {Power = 95, Accuracy = 100, Kind = "special", Type = Poketype.POISON}},
                {Attack.Outrage, new MoveStats {Power = 120, Accuracy = 100, Kind = "physque", Type = Poketype.DRAGON}}
            };
        }

        #endregion

        #region Methods
        
        public static int Damages(int Atk, int SpA, int Def, int SpD, string kind, Poketype poke1, Poketype poke2, Poketype move, Poketype type1, Poketype type2)
        {
            if (new Random().Next(0, 100) > PokeAttack[name].Accuracy)
            {
                Console.WriteLine("Missed !");
                return 0;
            }
            int damage = (42 * PokeAttack[name].Power * (kind == "physique" ? Atk / Def : SpA / SpD)) / 50 + 2;
            int stab = poke1 == move || poke2 == move ? 3/2 : 1;
            int critical = new Random().Next(0, 10000) < 625 ? 3/2 : 1;
            
            if (critical == 3 / 2)
                Console.WriteLine("A critical hit !");

            return damage * stab * new Random().Next(85, 100) / 100 * TypeTable.Affinity(move, type1, type2);
        }

        #endregion
    }
    
    static class TypeTable
    {
        private static int[,] table;
        static TypeTable()
        {
            table = new int[,]
            {
                {1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1, 1/2,   0,   1,   1, 1/2,   1},
                {1, 1/2, 1/2,   2,   1,   2,   1,   1,   1,   1,   1,   2, 1/2,   1, 1/2,   1,   2,   1},
                {1,   2, 1/2, 1/2,   1,   1,   1,   1,   2,   1,   1,   1,   2,   1, 1/2,   1,   1,   1},
                {1, 1/2,   2, 1/2,   1,   1,   1, 1/2,   2, 1/2,   1, 1/2,   2,   1, 1/2,   1, 1/2,   1},
                {1,   1,   2, 1/2, 1/2,   1,   1,   1,   0,   2,   1,   1,   1,   1, 1/2,   1,   1,   1},
                {1, 1/2, 1/2,   2,   1, 1/2,   1,   1,   2,   2,   1,   1,   1,   1,   2,   1, 1/2,   1},
                {2,   1,   1,   1,   1,   2,   1, 1/2,   1, 1/2, 1/2, 1/2,   2,   0,   1,   2,   2, 1/2},
                {1,   1,   1,   2,   1,   1,   1, 1/2, 1/2,   1,   1,   1, 1/2, 1/2,   1,   1,   0,   2},
                {1,   2,   1, 1/2,   2,   1,   1,   2,   1,   0,   1, 1/2,   2,   1,   1,   1,   2,   1},
                {1,   1,   1,   2, 1/2,   1,   2,   1,   1,   1,   1,   2, 1/2,   1,   1,   1, 1/2,   1},
                {1,   1,   1,   1,   1,   1,   2,   2,   1,   1, 1/2,   1,   1,   1,   1,   0, 1/2,   1},
                {1, 1/2,   1,   2,   1,   1, 1/2, 1/2,   1, 1/2,   2,   1,   1, 1/2,   1,   2, 1/2, 1/2},
                {1,   2,   1,   1,   1,   2, 1/2,   1, 1/2,   2,   1,   2,   1,   1,   1,   1, 1/2,   1},
                {0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   2,   1,   1,   2,   1, 1/2,   1,   1},
                {1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   2,   1, 1/2,   0},
                {1,   1,   1,   1,   1,   1, 1/2,   1,   1,   1,   2,   1,   1,   2,   1, 1/2,   1, 1/2},
                {1, 1/2, 1/2,   1, 1/2,   2,   1,   1,   1,   1,   1,   1,   2,   1,   1,   1, 1/2,   2},
                {1, 1/2,   1,   1,   1,   1,   2, 1/2,   1,   1,   1,   1,   1,   1,   2,   2, 1/2,   1}
            };
        }

        public static int Affinity(Poketype AtkType, Poketype DefType1, Poketype DefType2)
        {
            int affinity1 = table[(int) AtkType, (int) DefType1];

            int affinity2 = DefType2 == Poketype.None ? 1 : table[(int) AtkType, (int) DefType2];

            int total = affinity1 * affinity2;

            if (total > 1)
                Console.WriteLine("It's super effective !");
            else if (total > 0 && total < 1)
                Console.WriteLine("It's not very effective");
            else if (total == 0)
                Console.WriteLine("It's not effective");

            return total;
        }
    }
        
}
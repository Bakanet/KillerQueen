using System;
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
        public State Effect { get; set; }
        public string Kind { get; set; }
        public Poketype Type { get; set; }
    }
    
    public class Move
    {
        #region Constructor

        private Attack name;
        private Dictionary<Attack, MoveStats> PokeAttack;   

        public Move(Attack name)
        {
            this.name = name;
            PokeAttack = new Dictionary<Attack, MoveStats>()
            {
                {Attack.FlareBlitz, new MoveStats {Power = 120, Accuracy = 100, Effect = State.Recoil, Kind = "physique", Type = Poketype.FIRE}} 
            };
        }

        #endregion

        #region Methods

        public void StateEffect(State state)
        {
            

        }

        public int Damages(int Atk, int SpA, int Def, int SpD, string kind, Poketype poke, Poketype move, State state, Poketype type1, Poketype type2)
        {
            if (new Random().Next(0, 100) > PokeAttack[name].Accuracy)
            {
                Console.WriteLine("Missed !");
                return 0;
            }
            int damage = (42 * PokeAttack[name].Power * (kind == "physique" ? Atk / Def : SpA / SpD)) / 50 + 2;
            int stab = poke == move ? 3/2 : 1;
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
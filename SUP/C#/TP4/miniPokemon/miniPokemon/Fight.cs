using System;
using System.Data.Odbc;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace miniPokemon
{
    public static class Fight
    {
        #region Constructor

        private static StratPokemon[] Team1;
        private static StratPokemon[] Team2;

        static Fight()
        {
            Team1 = new StratPokemon[6];
            Team2 = new StratPokemon[6];
        }

        #endregion

        #region Methods

        public static void AvailablePokemon()
        {
            for (int i = 1; i < 56; i++)
            {
                if (i % 5 != 0)
                    Console.Write(i + ". " + (Pomon) i + "    ");
                else
                    Console.WriteLine(i + ". " + (Pomon) i);
            }
            Console.WriteLine("56. " + (Pomon) 56);
        }

        public static void CreateTeam()
        {
            AvailablePokemon();
            Console.WriteLine();
            Console.WriteLine("Team 1 :");
            for (int i = 1; i <= 6; i++)
            {
                Console.Write("Choose the Pokemon " + i + " : ");
                string temp = "0";
                while (int.Parse(temp) < 1 || int.Parse(temp) > 56)
                {
                    while ((temp = Console.ReadLine()) == "") ;
                    if (int.Parse(temp) < 1 || int.Parse(temp) > 56)
                    {
                        Console.Write("Choose a valid number : ");
                    }
                }
                Pomon tempPomon = (Pomon) int.Parse(temp);
                Console.Write("Name it : ");
                string tempname;
                while ((tempname = Console.ReadLine()) == "") ;
                Team1[i - 1] = new StratPokemon(tempPomon, tempname);
            }
            Console.WriteLine();
            Console.WriteLine("Team 2 :");
            for (int i = 1; i <= 6; i++)
            {
                Console.Write("Choose the Pokemon " + i + " : ");
                string temp = "0";
                while (int.Parse(temp) < 1 || int.Parse(temp) > 56)
                {
                    while ((temp = Console.ReadLine()) == "") ;
                    if (int.Parse(temp) < 1 || int.Parse(temp) > 56)
                    {
                        Console.Write("Choose a valid number : ");
                    }
                }
                Pomon tempPomon = (Pomon) int.Parse(temp);
                Console.Write("Name it : ");
                string tempname;
                while ((tempname = Console.ReadLine()) == "") ;
                Team2[i - 1] = new StratPokemon(tempPomon, tempname);
            }
        }

        public static void Switch(int pokemon, StratPokemon[] team)
        {
            StratPokemon temp = team[pokemon];
            team[pokemon] = team[0];
            team[0] = temp;
        }

        public static void PrintBoard()
        {
            Console.WriteLine("Team 2 : ");
            Console.WriteLine(Team2[0].Name + " : " + Team2[0].Life + "/" + Team2[0].Maxlife);
            Console.WriteLine("Available attacks : ");
            Console.WriteLine("1. " + Team2[0].Poke[Team2[0].Pokemon].Attack1);
            Console.WriteLine("2. " + Team2[0].Poke[Team2[0].Pokemon].Attack2);
            Console.WriteLine("3. " + Team2[0].Poke[Team2[0].Pokemon].Attack3);
            Console.WriteLine("4. " + Team2[0].Poke[Team2[0].Pokemon].Attack4);
            Console.WriteLine("5. Switch");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Team 1 : ");
            Console.WriteLine(Team1[0].Name + " : " + Team1[0].Life + "/" + Team1[0].Maxlife);
            Console.WriteLine("Available attacks :");
            Console.WriteLine("1. " + Team1[0].Poke[Team1[0].Pokemon].Attack1);
            Console.WriteLine("2. " + Team1[0].Poke[Team1[0].Pokemon].Attack2);
            Console.WriteLine("3. " + Team1[0].Poke[Team1[0].Pokemon].Attack3);
            Console.WriteLine("4. " + Team1[0].Poke[Team1[0].Pokemon].Attack4);
            Console.WriteLine("5. Switch");
        }

        public static void PrintTeam(StratPokemon[] team)
        {
            int i = 1;
            foreach (StratPokemon pokemon in team)
            {
                if (pokemon.IsKo)
                    Console.Write(i + ". " + pokemon.Name + " : 0 HP.");
                else
                    Console.Write(i + ". " + pokemon.Name + "  ");
                ++i;
            }
        }

        public static void Turn()
        {
            // definition de variables utiles

            MoveStats attack1 = Move.PokeAttack[Team1[0].Poke[Team1[0].Pokemon].Attack1.Name],
                attack2 = Move.PokeAttack[Team1[0].Poke[Team1[0].Pokemon].Attack2.Name],
                attack3 = Move.PokeAttack[Team1[0].Poke[Team1[0].Pokemon].Attack3.Name],
                attack4 = Move.PokeAttack[Team1[0].Poke[Team1[0].Pokemon].Attack4.Name];
            Stats team1 = Team1[0].Poke[Team1[0].Pokemon], team2 = Team2[0].Poke[Team2[0].Pokemon];
            int team1Damages = 0, team2Damages = 0, team1Alive = 6, team2Alive = 6;

            while (team1Alive > 0 || team2Alive > 0)
            {
                // Team 1

                PrintBoard();
                Console.WriteLine("Team 1 : choose your move");
                string move1 = "0";
                while (int.Parse(move1) < 1 || int.Parse(move1) > 5)
                {
                    while ((move1 = Console.ReadLine()) == "") ;
                    if (int.Parse(move1) < 1 || int.Parse(move1) > 5)
                        Console.Write("Choose a valid number : ");
                }

                if (int.Parse(move1) == 5)
                {
                    PrintTeam(Team1);
                    Console.WriteLine("With which Pokemon do you want to switch ?");
                    string pomon = "0";
                    while (int.Parse(pomon) < 2 || int.Parse(pomon) > 6 || Team1[int.Parse(pomon)].IsKo)
                    {
                        while ((pomon = Console.ReadLine()) == "") ;
                        if (int.Parse(pomon) < 1 || int.Parse(pomon) > 6)
                            Console.Write("Choose a valid number : ");

                        if (int.Parse(pomon) == 1)
                            Console.WriteLine("You can't switch a Pokemon with himself !");

                        if (Team1[int.Parse(pomon)].IsKo)
                            Console.WriteLine("This Pokemon is KO !");
                    }
                    Switch(int.Parse(pomon), Team1);
                    PrintBoard();
                }

                if (int.Parse(move1) == 1)
                {
                    team1Damages = Move.Damages(team1.Atk, team1.SpA, team2.Def, team2.SpD,
                        attack1.Kind, team1.Type1, team1.Type2, attack1.Type, attack1.Effect, team2.Type1, team2.Type2, 
                        Team1[0], Team2[0]);
                }

                if (int.Parse(move1) == 2)
                {
                    team1Damages = Move.Damages(team1.Atk, team1.SpA, team2.Def, team2.SpD,
                        attack2.Kind, team1.Type1, team1.Type2, attack2.Type, attack2.Effect, team2.Type1, team2.Type2,
                    Team1[0], Team2[0]);
                }

                if (int.Parse(move1) == 3)
                {
                    team1Damages = Move.Damages(team1.Atk, team1.SpA, team2.Def, team2.SpD,
                        attack3.Kind, team1.Type1, team1.Type2, attack3.Type, attack3.Effect, team2.Type1, team2.Type2,
                        Team1[0], Team2[0]);
                }

                if (int.Parse(move1) == 4)
                {
                    team1Damages = Move.Damages(team1.Atk, team1.SpA, team2.Def, team2.SpD,
                        attack4.Kind, team1.Type1, team1.Type2, attack4.Type, attack4.Effect, team2.Type1, team2.Type2,
                        Team1[0], Team2[0]);
                }

                // Team 2

                Console.WriteLine("Team 2 : choose your move");
                string move2 = "0";
                while (int.Parse(move2) < 1 || int.Parse(move2) > 5)
                {
                    while ((move2 = Console.ReadLine()) == "") ;
                    if (int.Parse(move2) < 1 || int.Parse(move2) > 5)
                        Console.Write("Choose a valid number : ");
                }

                if (int.Parse(move2) == 5)
                {
                    PrintTeam(Team2);
                    Console.WriteLine("With which Pokemon do you want to switch ?");
                    string pomon = "0";
                    while ((int.Parse(pomon) < 2 || int.Parse(pomon) > 6) || Team2[int.Parse(pomon)].IsKo)
                    {
                        while ((pomon = Console.ReadLine()) == "") ;
                        if (int.Parse(pomon) < 1 || int.Parse(pomon) > 6)
                            Console.Write("Choose a valid number : ");

                        if (int.Parse(pomon) == 1)
                            Console.WriteLine("You can't switch a Pokemon with himself !");

                        if (Team2[int.Parse(pomon)].IsKo)
                            Console.WriteLine("This Pokemon is KO !");
                    }
                    Switch(int.Parse(pomon), Team2);
                    PrintBoard();
                }

                if (int.Parse(move2) == 1)
                {
                    team2Damages = Move.Damages(team2.Atk, team2.SpA, team1.Def, team1.SpD,
                        attack1.Kind, team2.Type1, team2.Type2, attack1.Type, attack1.Effect, team1.Type1, team1.Type2,
                        Team2[0], Team1[0]);
                }

                if (int.Parse(move2) == 2)
                {
                    team2Damages = Move.Damages(team2.Atk, team2.SpA, team1.Def, team1.SpD,
                        attack2.Kind, team2.Type1, team2.Type2, attack2.Type, attack2.Effect, team1.Type1, team1.Type2,
                        Team2[0], Team1[0]);
                }

                if (int.Parse(move2) == 3)
                {
                    team2Damages = Move.Damages(team1.Atk, team1.SpA, team2.Def, team2.SpD,
                        attack3.Kind, team1.Type1, team1.Type2, attack3.Type, attack3.Effect, team2.Type1, team2.Type2,
                        Team2[0], Team1[0]);
                }

                if (int.Parse(move2) == 4)
                {
                    team2Damages = Move.Damages(team1.Atk, team1.SpA, team2.Def, team2.SpD,
                        attack4.Kind, team1.Type1, team1.Type2, attack4.Type, attack4.Effect, team2.Type1, team2.Type2,
                        Team2[0], Team1[0]);
                }

                // Pokemon le plus rapide qui tape en premier

                if (team1.Spe > team2.Spe)
                {
                    Team2[0].GetHurt(team1Damages);
                    PrintBoard();
                    // gestion de la mort et du switch de Pokemon a la mort
                    if (Team2[0].IsKo)
                    {
                        --team2Alive;
                        if (team2Alive <= 0)
                        {
                            Console.WriteLine("Team 1 wins");
                            return;
                        }
                        Console.WriteLine("Team 2 : switch with an other Pokemon");
                        PrintTeam(Team2);
                        string pomon = "0";
                        while (int.Parse(pomon) < 2 || int.Parse(pomon) > 6 || Team2[int.Parse(pomon)].IsKo)
                        {
                            while ((pomon = Console.ReadLine()) == "") ;
                            if (int.Parse(pomon) < 1 || int.Parse(pomon) > 6)
                                Console.Write("Choose a valid number : ");

                            if (int.Parse(pomon) == 1)
                                Console.WriteLine("You can't switch a Pokemon with himself !");

                            if (Team1[int.Parse(pomon)].IsKo)
                                Console.WriteLine("This Pokemon is KO !");
                        }
                        Switch(int.Parse(pomon), Team2);
                        PrintBoard();
                    }
                }

                else
                {
                    // version team1
                    Team1[0].GetHurt(team1Damages);
                    PrintBoard();
                    if (Team1[0].IsKo)
                    {
                        --team1Alive;
                        if (team1Alive <= 0)
                        {
                            Console.WriteLine("Team 2 wins");
                            return;
                        }
                        Console.WriteLine("Team 1 : switch with an other Pokemon");
                        PrintTeam(Team1);
                        string pomon = "0";
                        while (int.Parse(pomon) < 2 || int.Parse(pomon) > 6 || Team1[int.Parse(pomon)].IsKo)
                        {
                            while ((pomon = Console.ReadLine()) == "") ;
                            if (int.Parse(pomon) < 1 || int.Parse(pomon) > 6)
                                Console.Write("Choose a valid number : ");

                            if (int.Parse(pomon) == 1)
                                Console.WriteLine("You can't switch a Pokemon with himself !");

                            if (Team1[int.Parse(pomon)].IsKo)
                                Console.WriteLine("This Pokemon is KO !");
                        }
                        Switch(int.Parse(pomon), Team1);
                        PrintBoard();
                    }
                }
            }
        }

        #endregion
    }
}
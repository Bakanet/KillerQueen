using System;

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
                string temp = "";
                while ((temp = Console.ReadLine()) == "") ;
                Pomon tempPomon = (Pomon) int.Parse(temp);
                Team1[i-1] = tempPomon;
            }
            Console.WriteLine();
            Console.WriteLine("Team 2 :");
            for (int i = 1; i <= 6; i++)
            {
                Console.Write("Choose the Pokemon " + i + " : ");
                string temp = "";
                while ((temp = Console.ReadLine()) == "") ;
                Pomon tempPomon = (Pomon) int.Parse(temp);
                Team2[i-1] = tempPomon;
            }
            
        }

        #endregion
        
        


    }
}
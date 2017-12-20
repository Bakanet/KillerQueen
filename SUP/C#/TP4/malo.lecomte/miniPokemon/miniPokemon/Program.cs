using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniPokemon
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void Game()
        {
            Fight.CreateTeam();
            Fight.Turn();
        }

    }
}

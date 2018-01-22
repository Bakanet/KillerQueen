using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WestWorldTycoon
{
    internal class Program
    {
        private const int NB_ROUNDS = 100;
        private const long INITIAL_MONEY = 11000;
        
        public static void Main(string[] args)
        {
            Game game = new Game("agave_plantation.map", NB_ROUNDS, INITIAL_MONEY);
            long score = game.Launch(new MyBot());
            Console.WriteLine("Score: {0}", score);
            TycoonIO.Viewer();
        }
    }
}
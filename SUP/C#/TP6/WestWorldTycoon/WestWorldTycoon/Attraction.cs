using System;

namespace WestWorldTycoon
{
    public class Attraction :Building
    {
        public const long BUILD_COST = 10000;
        public static readonly long[] UPGRADE_COST = { 5000, 10000, 45000 };
        public static readonly long[] ATTRACTIVENESS = { 500, 1000, 1300, 1500 };
        private int lvl;



        public Attraction()
        {
            throw new NotImplementedException();
        }


        public Attraction(Attraction attraction)
        {
            // BONUS
            throw new NotImplementedException();
        }

        public long Attractiveness()
        {
            throw new NotImplementedException();
        }


        public bool Upgrade(ref long money)
        {
            throw new NotImplementedException();
        }


        public int Lvl
        {
            get { throw new NotImplementedException(); }
        }
    }
}

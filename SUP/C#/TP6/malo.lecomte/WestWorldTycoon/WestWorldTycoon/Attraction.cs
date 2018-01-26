using System;
using System.Runtime.InteropServices.WindowsRuntime;

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
            lvl = 0;
            type = BuildingType.ATTRACTION;
        }


        public Attraction(Attraction attraction)
        {
            // BONUS
            throw new NotImplementedException();
        }

        public long Attractiveness()
        {
            return ATTRACTIVENESS[lvl];
        }


        public bool Upgrade(ref long money)
        {
            if (lvl >= 3 || UPGRADE_COST[lvl] > money)
                return false;

            money -= UPGRADE_COST[lvl];
            ++lvl;
            return true;
        }


        public int Lvl
        {
            get { return lvl; }
        }
    }
}

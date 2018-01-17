using System;

namespace WestWorldTycoon
{
    public class House : Building
    {
        public const long BUILD_COST = 250;
        public static readonly long[] UPGRADE_COST ={ 750, 3000, 10000 };
        public static readonly long[] HOUSING ={ 300, 500, 650, 750 };
        public int lvl;
        
        
        
        public House()
        {
            lvl = 0;
            type = BuildingType.HOUSE;
        }


        public House(House house)
        {
            // BONUS
            throw new NotImplementedException();
        }

        
        public long Housing()
        {
            return HOUSING[lvl];
        }


        public bool Upgrade(ref long money)
        {
            if (UPGRADE_COST[lvl] > money || lvl < 3)
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
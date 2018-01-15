using System;

namespace WestWorldTycoon
{
    public class House : Building
    {
        public const long BUILD_COST = 250;
        public static readonly long[] UPGRADE_COST ={ 750, 3000, 10000 };
        public static readonly long[] HOUSING ={ 300, 500, 650, 750 };
        
        
        
        public House()
        {
            throw new NotImplementedException();
        }


        public House(House house)
        {
            // BONUS
            throw new NotImplementedException();
        }

        
        public long Housing()
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
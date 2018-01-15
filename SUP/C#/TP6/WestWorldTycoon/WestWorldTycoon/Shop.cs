using System;

namespace WestWorldTycoon
{
    public class Shop : Building
    {
        
        public const long BUILD_COST = 300;
        public static readonly long[] UPGRADE_COST = { 2500, 10000, 50000 };
        public static readonly long[] INCOME = { 7, 8, 9, 10 };

        
        public Shop()
        {
            throw new NotImplementedException();
        }


        public Shop(Shop shop)
        {
            // BONUS
            throw new NotImplementedException();
        }
        
        
        public long Income(long population)
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
﻿using System;

namespace WestWorldTycoon
{
    public class Shop : Building
    {
        
        public const long BUILD_COST = 300;
        public static readonly long[] UPGRADE_COST = { 2500, 10000, 50000 };
        public static readonly long[] INCOME = { 7, 8, 9, 10 };
        private int lvl;

        
        public Shop()
        {
            lvl = 0;
            type = BuildingType.SHOP;
        }


        public Shop(Shop shop)
        {
            lvl = shop.lvl;
            type = BuildingType.SHOP;
        }
        
        
        public long Income(long population)
        {
            return population / 100 * INCOME[lvl];
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
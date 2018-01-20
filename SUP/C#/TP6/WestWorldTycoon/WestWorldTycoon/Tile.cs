using System;
using System.Xml.Schema;

namespace WestWorldTycoon
{
    public class Tile
    {
        public enum Biome
        {
            SEA,
            MOUNTAIN,
            PLAIN
        }

        private Biome biome;
        private Building building;

        public Tile(Biome b)
        {
            biome = b;
            building = null;
        }


        public Tile(Tile tile)
        {
            // BONUS
            throw new NotImplementedException();
        }


        public bool Build(ref long money, Building.BuildingType type)
        {
            if (biome == Biome.PLAIN && building == null)
            {
                switch (type)
                {
                    case Building.BuildingType.ATTRACTION:
                        if (Attraction.BUILD_COST <= money)
                        {
                            building = new Attraction();
                            return true;
                        }

                        break;
                    case Building.BuildingType.HOUSE:
                        if (House.BUILD_COST <= money)
                        {
                            building = new House();
                            return true;
                        }

                        break;
                    case Building.BuildingType.SHOP:
                        if (Shop.BUILD_COST <= money)
                        {
                            building = new Shop();
                            return true;
                        }

                        break;
                }
            }
            return false;
        }


        public bool Upgrade(ref long money)
        {
            switch (building.Type)
            {
                case Building.BuildingType.ATTRACTION:
                    if (Attraction.BUILD_COST <= money && ((Attraction) building).Lvl < 3)
                        ((Attraction) building).Upgrade(ref money);
                    break;
                case Building.BuildingType.HOUSE:
                    if (House.BUILD_COST <= money && ((House) building).Lvl < 3)
                        ((House) building).Upgrade(ref money);
                    break;
                case Building.BuildingType.SHOP:
                    if (Shop.BUILD_COST <= money && ((Shop) building).Lvl < 3) ;
                    break;
            }

            return true;
        }


        public long GetHousing()
        {
            if (building == null || building.Type != Building.BuildingType.HOUSE)
                return 0;
            return ((House) building).Housing();
        }


        public long GetAttractiveness()
        {
            if (building == null || building.Type != Building.BuildingType.ATTRACTION)
                return 0;
            return ((Attraction) building).Attractiveness();
        }


        public long GetIncome(long population)
        {
            if (building == null || building.Type != Building.BuildingType.SHOP)
                return 0;
            return ((Shop) building).Income(population);
        }


        public bool Destroy()
        {
            // BONUS
            throw new NotImplementedException();
        }


        public Biome GetBiome
        {
            get { return biome; }
        }

        public Building GetBuilding
        {
            get { return building; }
        }
    }
}

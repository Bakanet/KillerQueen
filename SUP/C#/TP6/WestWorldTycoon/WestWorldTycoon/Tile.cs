using System;
using System.Xml.Schema;

namespace WestWorldTycoon
{
    public class Tile
    {
        public enum Biome
        {
            SEA, MOUNTAIN, PLAIN
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
            long cost = 0;
            switch (type)
            {
                case Building.BuildingType.ATTRACTION:
                    cost = Attraction.BUILD_COST;
                    break;
                case Building.BuildingType.HOUSE:
                    cost = House.BUILD_COST;
                    break;
                case Building.BuildingType.SHOP:
                    cost = Shop.BUILD_COST;
                    break;
            }

            if (biome != Biome.PLAIN || cost > money)
                return false;

            switch (type)
            {
                    case Building.BuildingType.ATTRACTION:
                        building = new Attraction();
                        break;
                    case Building.BuildingType.HOUSE:
                        building = new House();
                        break;
                    case Building.BuildingType.SHOP:
                        building = new Shop();
                        break;
            }

            return true;
        }


        public bool Upgrade(ref long money)
        {
            long cost = 0;
            int lvl = 0;
            switch (building.Type)
            {
                case Building.BuildingType.ATTRACTION:
                    cost = Attraction.BUILD_COST;
                    lvl = ((Attraction) building).Lvl;
                    break;
                case Building.BuildingType.HOUSE:
                    cost = House.BUILD_COST;
                    lvl = ((House) building).Lvl;
                    break;
                case Building.BuildingType.SHOP:
                    cost = Shop.BUILD_COST;
                    lvl = ((Shop) building).Lvl;
                    break;
            }

            if (money < cost || lvl >= 3)
                return false;

            switch (building.Type)
            {
                    case Building.BuildingType.ATTRACTION:
                        ((Attraction) building).Upgrade(ref money);
                        break;
                    case Building.BuildingType.HOUSE:
                        ((House) building).Upgrade(ref money);
                        break;
                    case Building.BuildingType.SHOP:
                        ((Shop) building).Upgrade(ref money);
                        break;
            }

            return true;
        }
        
        
        public long GetHousing()
        {
            return building.Type != Building.BuildingType.HOUSE ? 0 : ((House) building).Housing();
        }
        
        
        public long GetAttractiveness()
        {
            return building.Type != Building.BuildingType.ATTRACTION ? 0 : ((Attraction) building).Attractiveness();
        }
        
        
        public long GetIncome(long population)
        {
            return building.Type != Building.BuildingType.SHOP ? 0 : ((Shop) building).Income(population);
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
    }
}
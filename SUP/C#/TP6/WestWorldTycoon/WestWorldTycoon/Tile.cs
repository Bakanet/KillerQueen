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
            switch (building.Type)
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
            
            if (money < cost || )
        }
        
        
        public long GetHousing()
        {
            throw new NotImplementedException();
        }
        
        
        public long GetAttractiveness()
        {
            throw new NotImplementedException();
        }
        
        
        public long GetIncome(long population)
        {
            throw new NotImplementedException();
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
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
        
        
        public Tile(Biome b)
        {
            throw new NotImplementedException();
        }

        
        public Tile(Tile tile)
        {
            // BONUS
            throw new NotImplementedException();
        }

        
        public bool Build(ref long money, Building.BuildingType type)
        {
            throw new NotImplementedException();
        }


        public bool Upgrade(ref long money)
        {
            throw new NotImplementedException();
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
            get { throw new NotImplementedException(); }
        }
    }
}
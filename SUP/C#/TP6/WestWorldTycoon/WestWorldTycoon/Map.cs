using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace WestWorldTycoon
{
    public class Map
    {
        public Map(string name)
        {
            throw new NotImplementedException();
        }
        
        
        public Map(Map map)
        {
            // BONUS
            throw new NotImplementedException();
        }


        public bool Build(int i, int j, ref long money, Building.BuildingType type)
        {
            throw new NotImplementedException();
        }


        public bool Destroy(int i, int j)
        {
            // BONUS
            throw new NotImplementedException();
        }

        public bool Upgrade(int i, int j, ref long money)
        {
            throw new NotImplementedException();
        }
        
        
        public long GetAttractiveness()
        {
            throw new NotImplementedException();
        }

        
        public long GetHousing()
        {
            throw new NotImplementedException();
        }


        public long GetPopulation()
        {
            throw new NotImplementedException();
        }
        
        
        public long GetIncome(long population)
        {
            throw new NotImplementedException();
        }
       
    }
}
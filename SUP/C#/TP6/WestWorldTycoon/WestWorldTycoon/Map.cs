using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace WestWorldTycoon
{
    public class Map
    {

        private Tile[,] matrix;
        
        public Map(string name)
        {
            matrix = TycoonIO.ParseMap(name);
        }
        
        
        public Map(Map map)
        {
            // BONUS
            throw new NotImplementedException();
        }


        public bool Build(int i, int j, ref long money, Building.BuildingType type)
        {
            if (i < 0 || j < 0 || i > matrix.GetLength(1) || j > matrix.GetLength(0))
                throw new IndexOutOfRangeException();
            Tile tile = matrix[j, i];
            return tile.Build(ref money, type);
        }


        public bool Destroy(int i, int j)
        {
            // BONUS
            throw new NotImplementedException();
        }

        public bool Upgrade(int i, int j, ref long money)
        {
            if (i < 0 || j < 0 || i > matrix.GetLength(1) || j > matrix.GetLength(0))
                throw new IndexOutOfRangeException();
            Tile tile = matrix[j, i];
            return tile.Upgrade(ref money);
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
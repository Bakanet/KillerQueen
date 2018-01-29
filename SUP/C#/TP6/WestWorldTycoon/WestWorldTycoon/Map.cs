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
            matrix = map.matrix;
        }


        public bool Build(int i, int j, ref long money, Building.BuildingType type)
        {
            return matrix[i, j].Build(ref money, type);
        }


        public bool Destroy(int i, int j)
        {
            return Matrix[i, j].Destroy();
        }

        public bool Upgrade(int i, int j, ref long money)
        {
            return matrix[i, j].Upgrade(ref money);
        }
        
        
        public long GetAttractiveness()
        {
            long attract = 0;
            foreach (Tile tile in matrix)
            {
                attract += tile.GetAttractiveness();
            }

            return attract;
        }

        
        public long GetHousing()
        {
            long visitors = 0;
            foreach (Tile tile in matrix)
            {
                visitors += tile.GetHousing();
            }

            return visitors;
        }


        public long GetPopulation()
        {
            return GetAttractiveness() < GetHousing() ? GetAttractiveness() : GetHousing();
        }
        
        
        public long GetIncome(long population)
        {
            long income = 0;
            foreach (Tile tile in matrix)
            {
                income += tile.GetIncome(population);
            }

            return income;
        }

        public Tile[,] Matrix
        {
            get { return matrix; }
        }

        public Map Map
        {
            get
            {
                Tile[,] matrix2 = new Tile[matrix.GetLength(0),matrix.GetLength(1)];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix2[i, j] = matrix[i, j];
                    }
                }

                return new Map();
            }
        }
    }
}
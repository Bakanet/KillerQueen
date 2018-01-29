using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace WestWorldTycoon
{
    public class MyBot : Bot
    {
        private int[,] upgrade;
        private long money;
        private List<Point> buildableList;
        public override void Start(Game game)
        {
        }

        private List<Point> BuildableList(Game game)
        {
            List<Point> buildable = new List<Point>();
            for (int i = 0; i < game.Map.Matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < game.Map.Matrix.GetLength(1); ++j)
                {
                    if (game.Map.Matrix[i, j].GetBiome == Tile.Biome.PLAIN && game.Map.Matrix[i ,j].GetBuilding == null)
                    {
                        buildable.Add(new Point(i, j));
                    }
                }
            }

            return buildable;
        }

        private void PrintArr(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j] + " ");
                }

                Console.WriteLine();
            }
        }
        
        /*private int[,] UpgradeArr(Game game)
        {
            int[,] upgrades = new int[game.Map.Matrix.GetLength(0), game.Map.Matrix.GetLength(1)];
            int building = 0;
            int lvl = 0;
            for (int i = 0; i < game.Map.Matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < game.Map.Matrix.GetLength(1); ++j)
                {
                    if (game.Map.Matrix[i,j].GetBuilding == null)
                        continue;
                    switch (game.Map.Matrix[i, j].GetBuilding.Type)
                    {
                        case Building.BuildingType.ATTRACTION:
                            building = 1;
                            lvl = ((Attraction) game.Map.Matrix[i, j].GetBuilding).Lvl;
                            break;
                        case Building.BuildingType.HOUSE:
                            building = 2;
                            lvl = ((House) game.Map.Matrix[i, j].GetBuilding).Lvl;
                            break;
                        case Building.BuildingType.SHOP:
                            building = 3;
                            lvl = ((Shop) game.Map.Matrix[i, j].GetBuilding).Lvl;
                            break;
                    }

                    upgrades[i, j] = building * 10 + lvl;
                    
                    //PrintArr(upgrades);
                }
            }

            return upgrades;
        }*/
        
        public override void Update(Game game)
        {
            if (game.Round == 1)
            {
                game.Build(2, 7, Building.BuildingType.HOUSE);
                game.Build(0, 2, Building.BuildingType.ATTRACTION);
                game.Build(8, 18, Building.BuildingType.SHOP);
                game.Build(8, 19, Building.BuildingType.SHOP);
            }
            
            
                    
                
        }          

        public override void End(Game game)
        {
            // Nothing to do...
        }
        
    }

    public class Point
    {
        private int x;
        private int y;
        
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
        }
        
        public int Y
        {
            get { return y; }
        }
    }
}
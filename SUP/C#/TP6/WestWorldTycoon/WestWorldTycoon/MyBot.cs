using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace WestWorldTycoon
{
    public class MyBot : Bot
    {
        public override void Start(Game game)
        {
            //nombres de bâtiments et types
        }

        private List<Point> BuildableList(Game game)
        {
            List<Point> buildable = new List<Point>();
            for (int i = 0; i < game.Map.Matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < game.Map.Matrix.GetLength(1); ++j)
                {
                    if (game.Map.Matrix[i, j].GetBiome == Tile.Biome.PLAIN)
                    {
                        buildable.Add(new Point(i, j));
                    }
                }
            }

            return buildable;
        }
        
        private int[,] UpgradeArr(Game game)
        {
            int[,] upgrades = new int[game.Map.Matrix.GetLength(0), game.Map.Matrix.GetLength(1)];
            int building = 0;
            int lvl = 0;
            for (int i = 0; i < game.Map.Matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < game.Map.Matrix.GetLength(1); ++j)
                {
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
                }
            }

            return upgrades;
        }
        
        public override void Update(Game game)
        {
            List<Point> buildableList = BuildableList(game);

            if (game.Round == 1)
            {
                game.Build(2, 7, Building.BuildingType.HOUSE);
                game.Build(0, 2, Building.BuildingType.ATTRACTION);
                game.Build(8, 18, Building.BuildingType.SHOP);
                game.Build(8, 19, Building.BuildingType.SHOP);
            }
            
            switch (game.Round)
                {
                    case 4: case 41: case 43:
                        game.Build(buildableList[0].X, buildableList[0].Y, Building.BuildingType.HOUSE);
                        break;
                        
                    case 42:
                        game.Build(game.Map.Matrix.GetLength(0) - 1, game.Map.Matrix.GetLength(1) - 1, Building.BuildingType.ATTRACTION);
                        break;

                    case 8: case 11: case 13: case 15: case 17: case 18: case 19: case 20: case 21: case 22: case 24:
                    case 26: case 36: case 37: case 38: case 39: case 40:
                        game.Build(buildableList[0].X, buildableList[0].Y, Building.BuildingType.SHOP);
                        break;
                        
                    case 23: case 25:
                        game.Build(buildableList[0].X, buildableList[0].X, Building.BuildingType.SHOP);
                        game.Build(buildableList[1].X, buildableList[1].Y, Building.BuildingType.SHOP);
                        break;
                        
                    case 34:
                        game.Upgrade(0, 2);
                        game.Build(buildableList[0].X, buildableList[0].Y, Building.BuildingType.HOUSE);
                        break;
                        
                    case 35:
                        game.Build(buildableList[0].X, buildableList[0].Y, Building.BuildingType.SHOP);
                        game.Build(buildableList[1].X, buildableList[1].Y, Building.BuildingType.SHOP);
                        game.Build(buildableList[2].X, buildableList[2].Y, Building.BuildingType.SHOP);
                        game.Build(buildableList[3].X, buildableList[3].Y, Building.BuildingType.HOUSE);
                        break;        
                        
                    case 44:
                        game.Upgrade(game.Map.Matrix.GetLength(0) - 1, game.Map.Matrix.GetLength(1) - 1);
                        break;
                    
                    case 45:
                        game.Build(buildableList[0].X, buildableList[0].Y, Building.BuildingType.HOUSE);
                        Shop:
                        int i = 1;
                        int j = 1;
                        while (game.Money >= 300)
                        {
                            game.Build(buildableList[i].X, buildableList[j].Y, Building.BuildingType.SHOP);
                            ++i;
                            ++j;
                        }
                        break;
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
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
        private int toUpgrade;
        private int nbShop;
        private int nbHouse;
        private int nbAttraction;
        
        
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
        
        public override void Update(Game game)
        {
            buildableList = BuildableList(game);
            
            if (game.Round == 1)
            {
                game.Build(2, 7, Building.BuildingType.HOUSE);
                game.Build(0, 2, Building.BuildingType.ATTRACTION);
                game.Build(8, 18, Building.BuildingType.SHOP);
                game.Build(8, 19, Building.BuildingType.SHOP);
            }
            
            for (int i = 0; i < buildableList.Count && game.Money >= House.BUILD_COST; ++i)
            {
                if (game.Money >= House.BUILD_COST && game.Map.GetAttractiveness() >= game.Map.GetHousing() || nbAttraction == 38 && nbHouse < 77)
                {
                    if (game.Build(buildableList[i].X, buildableList[i].Y, Building.BuildingType.HOUSE))
                        ++nbHouse;
                }

                if (game.Money >= Attraction.BUILD_COST && game.Map.GetAttractiveness() <= game.Map.GetHousing() && nbAttraction < 38)
                {
                    if (game.Build(buildableList[i].X, buildableList[i].Y, Building.BuildingType.ATTRACTION))
                        ++nbAttraction;  
                }

                if (game.Money >= Shop.BUILD_COST && nbShop < 115)
                {
                    game.Build(buildableList[i].X, buildableList[i].Y, Building.BuildingType.SHOP);
                    ++nbShop;
                }
            }

            if (buildableList.Count == 0)
            {   
                for (int i = 0; i < game.Map.Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < game.Map.Matrix.GetLength(1); j++)
                    {
                        if (game.Map.Matrix[i, j].GetBiome != Tile.Biome.PLAIN)
                            continue;
                        
                        switch (game.Map.Matrix[i, j].GetBuilding.Type)
                        {
                            case Building.BuildingType.ATTRACTION:
                                if (game.Map.GetAttractiveness() <= game.Map.GetHousing())
                                    game.Upgrade(i, j);
                                break;
                            case Building.BuildingType.HOUSE:
                                if (game.Map.GetHousing() <= game.Map.GetAttractiveness())
                                    game.Upgrade(i, j);
                                break;
                            case Building.BuildingType.SHOP:
                                if (game.Round >= 65)
                                {
                                    game.Upgrade(i, j);
                                }
                                break;
                        }
                    }
                }
            }
        }          

        public override void End(Game game)
        {
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
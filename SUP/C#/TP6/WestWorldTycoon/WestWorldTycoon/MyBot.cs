using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace WestWorldTycoon
{
    public class MyBot : Bot
    {
        public override void Start(Game game)
        {
        }

        private List<Tile> TileList(Game game, ref List<int> xPos, ref List<int> yPos)
        {
            List<Tile> tileList = new List<Tile>();
            for (int i = 0; i < game.Map.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < game.Map.Matrix.GetLength(1); j++)
                {
                    Tile tile = game.Map.Matrix[i, j];
                    if (tile.GetBiome == Tile.Biome.PLAIN && tile.GetBuilding == null)
                    {
                        tileList.Add(tile);
                        xPos.Add(i);
                        yPos.Add(j);
                    }
                }
            }

            
            return tileList;
        }

        private int[,] UpgradeArr(Game game)
        {
            int[,] upgrades = new int[game.Map.Matrix.GetLength(0), game.Map.Matrix.GetLength(1)];
            int building = 0;
            int lvl = 0;
            for (int i = 0; i < game.Map.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < game.Map.Matrix.GetLength(1); j++)
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
            List<int> xPos = new List<int>();
            List<int> yPos = new List<int>();
            List<Tile> tileList = TileList(game, ref xPos, ref yPos);
            int x = xPos[0];
            int y = yPos[0];
            long money = game.Money - (game.Money - game.Map.GetIncome(game.Map.GetPopulation()));

            if (game.Round == 1)
            {
                game.Build(x, y, Building.BuildingType.HOUSE);
                game.Build(xPos[1], yPos[1], Building.BuildingType.ATTRACTION);
                game.Build(xPos[2], yPos[2], Building.BuildingType.SHOP);
                game.Build(xPos[3], yPos[3], Building.BuildingType.SHOP);
            }

            if (money >= 300 && tileList.Count > 0)
            {
                game.Build(x, y, Building.BuildingType.SHOP);
            }
            
        }          

        public override void End(Game game)
        {
            // Nothing to do...
        }
    }
}
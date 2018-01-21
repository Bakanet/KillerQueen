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
        
        public override void Update(Game game)
        {
            game.Build(2, 7, Building.BuildingType.HOUSE);
            game.Build(0, 2, Building.BuildingType.ATTRACTION);
            game.Build(8, 18, Building.BuildingType.SHOP);
            game.Build(8, 19, Building.BuildingType.SHOP);
            List<int> xPos = new List<int>();
            List<int> yPos = new List<int>();
            List<Tile> tileList = TileList(game, ref xPos, ref yPos);
            int x = xPos[0];
            int y = yPos[0];
            
            switch (game.Round)
                {
                    case 4: case 41: case 43:
                        game.Build(x, y, Building.BuildingType.HOUSE);
                        break;
                        
                    case 42:
                        game.Build(game.Map.Matrix.GetLength(0) - 1, game.Map.Matrix.GetLength(1) - 1, Building.BuildingType.ATTRACTION);
                        break;

                    case 8: case 11: case 13: case 15: case 17: case 18: case 19: case 20: case 21: case 22: case 24:
                    case 26: case 36: case 37: case 38: case 39: case 40:
                        game.Build(x, y, Building.BuildingType.SHOP);
                        break;
                        
                    case 23: case 25:
                        game.Build(x, y, Building.BuildingType.SHOP);
                        game.Build(xPos[1], yPos[1], Building.BuildingType.SHOP);
                        break;
                        
                    case 34:
                        game.Upgrade(0, 2);
                        game.Build(x, y, Building.BuildingType.HOUSE);
                        break;
                        
                    case 35:
                        game.Build(x, y, Building.BuildingType.SHOP);
                        game.Build(xPos[1], yPos[1], Building.BuildingType.SHOP);
                        game.Build(xPos[2], yPos[2], Building.BuildingType.SHOP);
                        game.Build(xPos[3], yPos[3], Building.BuildingType.HOUSE);
                        break;        
                        
                    case 44:
                        game.Upgrade(game.Map.Matrix.GetLength(0) - 1, game.Map.Matrix.GetLength(1) - 1);
                        break;
                    
                    case 45:
                        game.Build(x, y, Building.BuildingType.HOUSE);
                        long money = game.Money - (game.Money - game.Map.GetIncome(game.Map.GetPopulation())) - 250;
                        int i = 1;
                        int j = 1;
                        while (money >= 300)
                        {
                            game.Build(xPos[i], yPos[j], Building.BuildingType.SHOP);
                            ++i;
                            ++j;
                            money -= 300;
                        }
                        break;
                }
            }          

        public override void End(Game game)
        {
            // Nothing to do...
        }
    }
}
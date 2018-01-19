using System;
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

        public override void Update(Game game)
        {
            game.Build(2, 7, Building.BuildingType.HOUSE);
            game.Build(12, 5, Building.BuildingType.ATTRACTION);
            game.Build(8, 18, Building.BuildingType.SHOP);

            if (game.Money > 10000)
                for (int i = 0; i < game.Map.Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < game.Map.Matrix.GetLength(1); j++)
                    {
                        if (game.Map.Matrix[i,j].GetBuilding != null && game.Map.Matrix[i,j].GetBiome == Tile.Biome.PLAIN && game.Map.Matrix[i,j].GetBuilding.Type != Building.BuildingType.NONE)
                        {
                            game.Build(i, j, Building.BuildingType.ATTRACTION);
                            break;
                        }
                    }
                }
            
            if (game.Map.GetAttractiveness() > game.Map.GetHousing())
                for (int i = 0; i < game.Map.Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < game.Map.Matrix.GetLength(1); j++)
                    {
                        if (game.Map.Matrix[i,j].GetBuilding != null && game.Map.Matrix[i,j].GetBiome == Tile.Biome.PLAIN && game.Map.Matrix[i,j].GetBuilding.Type != Building.BuildingType.NONE)
                        {
                            game.Build(i, j, Building.BuildingType.HOUSE);
                            break;
                        }
                    }
                }
            
            else
                for (int i = 0; i < game.Map.Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < game.Map.Matrix.GetLength(1); j++)
                    {
                        if (game.Map.Matrix[i,j].GetBuilding != null && game.Map.Matrix[i,j].GetBiome == Tile.Biome.PLAIN && game.Map.Matrix[i,j].GetBuilding.Type != Building.BuildingType.NONE)
                        {
                            game.Build(i, j, Building.BuildingType.ATTRACTION);
                            break;
                        }
                    }
                }




            // money > 10000 : attraction
            // attraction > house : build house
            // build shop
        }

        public override void End(Game game)
        {
            // Nothing to do...
        }
    }
}
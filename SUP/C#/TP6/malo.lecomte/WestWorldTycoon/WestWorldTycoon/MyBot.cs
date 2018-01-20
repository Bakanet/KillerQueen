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
            game.Build(8, 19, Building.BuildingType.SHOP);




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
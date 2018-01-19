using System;
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
            game.Build(14, 5, Building.BuildingType.SHOP);
            TycoonIO.Viewer();
        }

        public override void End(Game game)
        {
            // Nothing to do...
        }
    }
}
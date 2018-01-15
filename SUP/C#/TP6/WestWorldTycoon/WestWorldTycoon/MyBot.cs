namespace WestWorldTycoon
{
    public class MyBot : Bot
    {
        public override void Start(Game game)
        {
            // Nothing to do...
        }

        public override void Update(Game game)
        {
            game.Build(2, 7, Building.BuildingType.HOUSE);
            game.Build(12, 5, Building.BuildingType.ATTRACTION);
            game.Build(8, 18, Building.BuildingType.SHOP);
        }

        public override void End(Game game)
        {
            // Nothing to do...
        }
    }
}
namespace WestWorldTycoon
{
    public abstract class Bot
    {
        public abstract void Start(Game game);
        public abstract void Update(Game game);
        public abstract void End(Game game);
    }
}
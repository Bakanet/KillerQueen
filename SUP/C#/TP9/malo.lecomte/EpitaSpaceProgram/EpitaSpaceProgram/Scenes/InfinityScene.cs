using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class InfinityScene : Scene
    {
        public InfinityScene()
        {
            Add(new Infinity("Infinity", 250, 1, new Vector2(100, 0), new Vector2(0, 0), 400d));
        }
    }
}
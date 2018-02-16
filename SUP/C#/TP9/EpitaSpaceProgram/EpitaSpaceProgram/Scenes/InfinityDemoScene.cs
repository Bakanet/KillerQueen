using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class InfinityDemoScene : Scene
    {
        public InfinityDemoScene()
        {
            Add(new Spring("SpringX", 250, 1, new Vector2(100, 0), new Vector2(0, 0), 400d));
            Add(new SpringMax("SpringY", 250, 1, new Vector2(0, -50), new Vector2(0, 0), 400d * 4));
        }
    }
}
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class CirclingDemoScene : Scene
    {
        public CirclingDemoScene()
        {
            Add(new Spring("SpringX", 250, 1, new Vector2(0, 50), new Vector2(0, 0), 50d));
            Add(new SpringMax("SpringY", 250, 1, new Vector2(50, 0), new Vector2(0, 0), 50d));
        }
    }
}
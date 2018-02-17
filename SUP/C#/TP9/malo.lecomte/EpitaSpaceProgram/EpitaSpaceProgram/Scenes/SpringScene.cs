using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class SpringScene : Scene
    {
        public SpringScene()
        {
            Add(new Spring("Spring", 100, 1, new Vector2(0, 100), new Vector2(0, 0), 50d));
        }
    }
}
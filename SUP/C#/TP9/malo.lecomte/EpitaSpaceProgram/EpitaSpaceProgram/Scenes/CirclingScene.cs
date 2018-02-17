using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class CirclingScene : Scene
    {
        public CirclingScene()
        {
            Add(new CirclingSpring("Circling1", 250, 1, new Vector2(0, 50), new Vector2(0, 0), 50d));
        }
    }
}
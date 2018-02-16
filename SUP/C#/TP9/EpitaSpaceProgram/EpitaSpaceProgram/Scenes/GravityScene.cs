using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class GravityScene : Scene
    {
        public GravityScene()
        {
            Add(new Gravity("Situation", 100d, 1, new Vector2(0, 0), new Vector2(0, 9.81)));
        }
    }
}
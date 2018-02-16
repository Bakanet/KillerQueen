using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class DamperScene : Scene
    {
        public DamperScene()
        {
            Add(new DamperSpring("Damper", 75, 1, new Vector2(0, 100), new Vector2(0, 0), 100d, 5d));
        }
    }
}
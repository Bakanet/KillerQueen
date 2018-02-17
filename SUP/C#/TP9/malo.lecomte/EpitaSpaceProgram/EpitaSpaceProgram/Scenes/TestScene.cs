using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class TestScene : Scene
    {
        public TestScene()
        {
            // Add a new body called "Boring" to the scene, with a mass of 10000kg, a density of 1kg/m^3, and an initial
            // position of [0, 0].
            // Don't worry about the density parameter: it is only there for visualization purposes. It will come in
            // handy when representing bodies with densities != 1 (for instance, our good Earth).
            Add(new TestBody("Boring", 10000d, 1d, new Vector2(0, 0)));
        }
    }
}
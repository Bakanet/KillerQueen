using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class PendulumScene : Scene
    {
        public PendulumScene()
        {
            var body = new Gravity("Pendulum", 100, 1, new Vector2(100, 0), new Vector2(0, 9.81));
            var distanceJoint = new DistanceJoint(new Vector2(0, 0), body);
            Add(body);
            Add(distanceJoint);
        }
    }
}
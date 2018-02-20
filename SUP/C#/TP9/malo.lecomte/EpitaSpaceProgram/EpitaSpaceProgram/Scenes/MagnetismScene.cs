using System;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class MagnetismScene : Scene
    {
        public MagnetismScene()
        {
            var system = new System(Math.Pow(10, 3));
            var ball1 = new Body("Ball1", 100, 1, new Vector2(-100, 50));
            var ball2 = new Body("Ball2", 100, 1, new Vector2(100, -50));
            system.Add(ball1);
            system.Add(ball2);
            Add(system);
            var distanceJoint1 = new DistanceJoint(new Vector2(-100, -50), ball1);
            var distanceJoint2 = new DistanceJoint(new Vector2(100, 50), ball2);
            Add(distanceJoint1);
            Add(distanceJoint2);
        }
    }
}
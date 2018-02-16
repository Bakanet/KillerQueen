using System;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class TwoBodyScene : Scene
    {
        public TwoBodyScene() : base(Math.Pow(10, -6), 60 * 60 * 24)
        {
            var system = new System(6.67408e-11);
            system.Add(new Body("Earth", 5.972e24, 5514, new Vector2(0, 0)));
            system.Add(new Body("Moon", 7.34767309e22, 3344, new Vector2(384400e3, 0), new Vector2(0, -1022)));
            Add(system);
        }
    }
}
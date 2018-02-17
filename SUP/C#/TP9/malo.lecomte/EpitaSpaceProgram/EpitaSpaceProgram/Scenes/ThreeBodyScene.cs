using System;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class ThreeBodyScene : Scene
    {
        public ThreeBodyScene() : base(Math.Pow(10, -8), 60 * 60 * 24)
        {
            var system = new System(6.67408 * Math.Pow(10, -11));
            system.Add(new Body("Sun", 1.989e30, 1410, new Vector2(0, 0)));
            system.Add(new Body("Earth", 5.972e24, 5514, new Vector2(149.6e9, 0), new Vector2(0, -30e3)));
            system.Add(new Body("Moon", 7.34767309e22, 3344, new Vector2(149.6e9 + 384.4e6, 0),
                new Vector2(0, -30e3 + 1022)));
            Add(system);
        }
    }
}
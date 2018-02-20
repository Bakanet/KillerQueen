using System;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class BouncyEarthScene : Scene
    {
        public BouncyEarthScene() : base(Math.Pow(10, -6), 60 * 60 * 24 * 10)
        {
            var system = new System(6.67408 * Math.Pow(10, -11));
            system.Add(new Infinity("Earth", 5.972e24, 5514, new Vector2(0, 300e6), new Vector2(0, 0), 5e11));
            system.Add(new Body("Moon", 7.34767309e22, 3344, new Vector2(0, 300e6 + 384.4e6), new Vector2(1022, 0)));
            Add(system);
        }
    }
}
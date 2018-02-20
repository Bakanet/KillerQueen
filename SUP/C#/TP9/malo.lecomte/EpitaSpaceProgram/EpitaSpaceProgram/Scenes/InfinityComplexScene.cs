using System;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class InfinityComplexScene : Scene
    {
        public InfinityComplexScene()
        {
            Add(new Infinity("Infinity1", 250, 1, new Vector2(100, 0), new Vector2(0, 0), 400d));
            Add(new Infinity("Infinity2", 250, 1, new Vector2(150 * Math.Sqrt(2), 150 * Math.Sqrt(2)),
                new Vector2(0, 0), 400d));
            Add(new Infinity("Infinity2", 250, 1, new Vector2(150 * Math.Sqrt(2), -150 * Math.Sqrt(2)),
                new Vector2(0, 0), 400d));
        }
    }
}
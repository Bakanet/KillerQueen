using System;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram.Scenes
{
    public class CirclingComplexScene : Scene
    {
        public CirclingComplexScene()
        {
            var offset = new Vector2(50, 0);
            Add(new CirclingSpring("Circling1", 250, 1, new Vector2(0, 50), new Vector2(0, 0), 50d));
            Add(new CirclingSpring("Circling2", 250, 1, offset + new Vector2(Math.Sqrt(2) * 50, Math.Sqrt(2) * 50),
                offset + new Vector2(0, 0), 50d));
            Add(new CirclingSpring("Circling3", 250, 1, 2 * offset + new Vector2(150, 0),
                2 * offset + new Vector2(0, 0), 50d));
            Add(new CirclingSpring("Circling4", 250, 1,
                3 * offset + new Vector2(100 * Math.Sqrt(2), -100 * Math.Sqrt(2)), 3 * offset + new Vector2(0, 0),
                50d));
            Add(new CirclingSpring("Circling5", 250, 1, 4 * offset + new Vector2(0, -250),
                4 * offset + new Vector2(0, 0), 50d));
            Add(new CirclingSpring("Circling6", 250, 1,
                5 * offset + new Vector2(-150 * Math.Sqrt(2), -150 * Math.Sqrt(2)), 5 * offset + new Vector2(0, 0),
                50d));
        }
    }
}
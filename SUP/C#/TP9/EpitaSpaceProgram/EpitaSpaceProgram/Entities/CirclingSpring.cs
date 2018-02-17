using System;
using System.Net.Configuration;

namespace EpitaSpaceProgram
{
    public class CirclingSpring : CompositeBody
    {
        public CirclingSpring(string name, double mass, double density, Vector2 initialPosition, Vector2 origin,
            double spring)
            : base(name, mass, density, initialPosition)
        {
            Vector2 initialSpringMax = initialPosition - origin;
            initialSpringMax = new Vector2(initialSpringMax.Y, -initialSpringMax.X) + origin;

            Add(new Spring(name, mass, density, initialPosition, origin, spring));
            Add(new SpringMax(name, mass, density, initialSpringMax, origin, spring));
        }
    }
}
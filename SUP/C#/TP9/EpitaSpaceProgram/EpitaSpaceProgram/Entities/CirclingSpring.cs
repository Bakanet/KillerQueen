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
            ;
        }
    }
}
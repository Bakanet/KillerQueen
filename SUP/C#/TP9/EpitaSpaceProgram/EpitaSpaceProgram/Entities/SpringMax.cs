using System;

namespace EpitaSpaceProgram
{
    public class SpringMax : Spring
    {
        public SpringMax(string name, double mass, double density, Vector2 initialPosition, Vector2 origin,
            double spring)
            : base(name, mass, density, initialPosition, origin, spring)
        {
            this.origin = origin;
            Velocity = -(initialPosition - origin) * Math.Sqrt(spring / mass);
        }
    }
}
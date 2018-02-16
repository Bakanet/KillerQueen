using System;

namespace EpitaSpaceProgram
{
    public class DamperSpring : Spring
    {
        private double damping;
        private Vector2 previousDisplacement;
        public DamperSpring(string name, double mass, double density, Vector2 initialPosition, Vector2 origin,
            double spring, double damping)
            : base(name, mass, density, initialPosition, origin, spring)
        {
            this.damping = damping;
            previousDisplacement = initialPosition;
        }

        public override void Update(double delta)
        {
            base.Update(delta);
            ApplyForce(-damping * (Position - previousDisplacement) / delta);
            previousDisplacement = Position;
        }
    }
}
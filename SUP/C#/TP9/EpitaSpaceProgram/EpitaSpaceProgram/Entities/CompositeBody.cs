using System.Collections.Generic;

namespace EpitaSpaceProgram
{
    public abstract class CompositeBody : Body
    {
        List<Body> bodies;

        protected CompositeBody(string name, double mass, double density, Vector2 initialPosition)
            : base(name, mass, density, initialPosition)
        {
            bodies = new List<Body>();
        }

        protected void Add(Body body)
        {
            Velocity += body.Velocity;
            Acceleration += body.Acceleration;
            bodies.Add(body);
        }

        public override void Update(double delta)
        {
            base.Update(delta);
            foreach (Body body in bodies)
            {
                body.Update(delta);
                Acceleration += body.Acceleration;
            }
        }
    }
}
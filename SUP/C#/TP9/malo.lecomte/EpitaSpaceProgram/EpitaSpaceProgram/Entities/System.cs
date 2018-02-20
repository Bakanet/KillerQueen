using System;
using System.Collections.Generic;
using System.Linq;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram
{
    public class System : IEntity
    {
        // Use this list to stores your `Body` objects.
        private readonly List<Body> _bodies;
        private double g;

        public System(double g)
        {
            _bodies = new List<Body>();
            this.g = g;
        }


        public void Update(double delta)
        {
            foreach (Body body in _bodies)
            {
                body.Update(delta);
                foreach (Body body2 in _bodies)
                {
                    if (body2 != body)
                    {
                        double force = g * (body.Mass * body2.Mass) /
                                       Math.Pow(Vector2.Dist(body.Position, body2.Position), 2);
                        body.ApplyForce(force * (body2.Position - body.Position).Normalized());
                    }
                }
            }
        }

        // Do not edit this method.
        public IEnumerable<string> Serialize()
        {
            return _bodies.SelectMany(body => body.Serialize());
        }

        public void Add(Body body)
        {
            _bodies.Add(body);
        }
    }
}
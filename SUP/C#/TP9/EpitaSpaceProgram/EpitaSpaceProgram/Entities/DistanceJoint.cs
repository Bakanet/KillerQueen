using System.Collections.Generic;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram
{
    public class DistanceJoint : IEntity
    {
        private Body body;
        private Vector2 origin;
        public DistanceJoint(Vector2 origin, Body body)
        {
            this.origin = origin;
            this.body = body;
        }

        public void Update(double delta)
        {
            Vector2 relativePos = body.Position - origin;
            body.ApplyForce(relativePos * ((Vector2.Dot(-body.Mass * body.Acceleration, relativePos) 
                - body.Mass * Vector2.Dot(body.Velocity, body.Velocity)) / Vector2.Dot(relativePos, relativePos)));
        }

        // Don't change this method.
        public IEnumerable<string> Serialize()
        {
            return new List<string>();
        }
    }
}
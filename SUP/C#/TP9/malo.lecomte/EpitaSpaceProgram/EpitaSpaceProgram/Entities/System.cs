using System.Collections.Generic;
using System.Linq;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram
{
    public class System : IEntity
    {
        // Use this list to stores your `Body` objects.
        private readonly List<Body> _bodies;

        public System(double g)
        {
            _bodies = new List<Body>();
            // FIXME
        }


        public void Update(double delta)
        {
            // FIXME
        }

        // Do not edit this method.
        public IEnumerable<string> Serialize()
        {
            return _bodies.SelectMany(body => body.Serialize());
        }

        public void Add(Body body)
        {
            // FIXME
        }
    }
}
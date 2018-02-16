namespace EpitaSpaceProgram
{
    public abstract class CompositeBody : Body
    {
        protected CompositeBody(string name, double mass, double density, Vector2 initialPosition)
            : base(name, mass, density, initialPosition)
        {
            // FIXME
        }

        protected void Add(Body body)
        {
            // FIXME
        }

        public override void Update(double delta)
        {
            // FIXME
        }
    }
}
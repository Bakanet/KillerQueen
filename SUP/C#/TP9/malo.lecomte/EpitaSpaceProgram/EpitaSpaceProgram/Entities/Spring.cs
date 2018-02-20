namespace EpitaSpaceProgram
{
    public class Spring : Body
    {
        protected Vector2 origin;
        private double spring;
        public Spring(string name, double mass, double density, Vector2 initialPosition, Vector2 origin, double spring)
            : base(name, mass, density, initialPosition)
        {
            this.origin = origin;
            this.spring = spring;
        }

        public override void Update(double delta)
        {
            base.Update(delta);
            ApplyForce(-spring * (Position - origin));
        }
    }
}
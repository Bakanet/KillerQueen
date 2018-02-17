namespace EpitaSpaceProgram
{
    public class Gravity : Body
    {
        private Vector2 gravity;
        public Gravity(string name, double mass, double density, Vector2 initialPosition, Vector2 gravity)
            : base(name, mass, density, initialPosition)
        {
            this.gravity = gravity;
        }

        public override void Update(double delta)
        {
            base.Update(delta);
            Acceleration = gravity;
        }
    }
}
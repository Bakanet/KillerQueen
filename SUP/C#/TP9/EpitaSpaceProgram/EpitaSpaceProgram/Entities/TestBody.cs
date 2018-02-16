namespace EpitaSpaceProgram
{
    public class TestBody : Body
    {
        private Vector2 _initialPosition;
        private double _t;

        // Initialize a physical body in its constructor.
        public TestBody(string name, double mass, double density, Vector2 initialPosition)
            : base(name, mass, density, initialPosition)
        {
            _initialPosition = initialPosition;

            // Here, we set the initial velocity of the body to 10 m/s in the direction of the right.
            // We could also have called the ctor. of the base class `Body` which accepts an initial velocity argument:
            // `base(name, mass, density, initialPosition, new Vector(10, 0))`
            Velocity = new Vector2(10, 0);

            // Try fiddling with the initial attributes of your body. Remember that `Acceleration` gets reset at each
            // update step. As such, setting an initial `Acceleration` has very little effect. Instead, you should set
            // `Acceleration` in the `Update` method of your body.
        }

        // Updates the body during a single update frame. The `delta` argument represents the time that has passed
        // since the previous update. You will seldom need it during this practical, but do remember to pass it to the
        // base class' own `Update` method.
        public override void Update(double delta)
        {
            // Calling the base class' `Update` method as the very first step is extremely important, as our body would
            // not move properly otherwise.
            base.Update(delta);

            _t += delta;

            // Try some of the following:

            // Position = new Vector2(50, 50);

            // Velocity = new Vector2(0, 100);

            // Acceleration = new Vector2(0, 10);

            // Finally, here's the parametric equation of a circle of radius 100:
            // (Remember to set the `Velocity` and `Acceleration` to 0 for this to work properly)
            // Position = _initialPosition + 100 * new Vector2(Math.Cos(_t), Math.Sin(_t));

            // In the following exercises, we will ask that you *do not* modify neither the `Velocity` or the `Position`
            // of your bodies in the `Update` method. Instead, you should only every set an initial velocity and
            // position in their constructor, then set an `Acceleration` in the `Update` method which will eventually
            // affect the velocity, and through the velocity, the position of your bodies.
        }
    }
}
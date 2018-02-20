namespace EpitaSpaceProgram
{
    public class Infinity : CompositeBody
    {
        public Infinity(string name, double mass, double density, Vector2 initialPosition, Vector2 origin,
            double spring)
            : base(name, mass, density, initialPosition)
        {
            Vector2 initialSpringMax = initialPosition - origin;
            initialSpringMax = new Vector2(initialSpringMax.Y, -initialSpringMax.X) + origin;

            Add(new Spring(name, mass, density, initialPosition, origin, spring));
            Add(new SpringMax(name, mass, density, initialSpringMax / 2, origin, 4 * spring));
        }
    }
}
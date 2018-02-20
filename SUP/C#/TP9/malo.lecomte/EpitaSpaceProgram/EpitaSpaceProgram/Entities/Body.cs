using System;
using System.Collections.Generic;
using EpitaSpaceProgram.ACDC;

namespace EpitaSpaceProgram
{
    public class Body : IEntity
    {
        // This constructor exists as a way to create a body without specifying an initial velocity. The corresponding body
        // will be affected an initial velocity of 0.
        // Do *not* modify this constructor.
        public Body(string name, double mass, double density, Vector2 initialPosition)
            : this(name, mass, density, initialPosition, new Vector2(0, 0))
        {
        }

        // Create a new body.
        // Do *not* modify this constructor.
        public Body(string name, double mass, double density, Vector2 initialPosition, Vector2 initialVelocity)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Mass = mass;
            Density = density;
            Position = initialPosition;
            Velocity = initialVelocity;
            Acceleration = new Vector2(0, 0);
        }

        // A unique identifier for this body. This is only useful for visualization purposes.
        public string Id { get; }

        // The display name of the body. This is only useful for visualization purposes.
        public string Name { get; }

        // The mass of the body.
        public double Mass { get; }

        // The density of the body. This is only useful for visualization purposes.
        public double Density { get; }

        // The position of the body (in meters from the origin [0, 0]).
        public Vector2 Position { get; protected set; }

        // The velocity of the body (in m/s).
        public Vector2 Velocity { get; protected set; }

        // The acceleration of the body (in m/s^2).
        public Vector2 Acceleration { get; protected set; }

        // Update the body during a single update frame.
        // The `delta` argument represents the time spent since the last update frame. Since both the `Velocity` and the
        // `Acceleration` of our body represent change over a full second, we only apply a fraction of both corresponding to
        // our `delta` time.
        // This approximation is explained in more details in the practical's subject.
        // Do *not* modify this method.
        public virtual void Update(double delta)
        {
            Velocity += delta * Acceleration;
            Position += delta * Velocity;
            // Once we've applied the previous update frame's acceleration, we can reset the acceleration to zero. It is the
            // responsibility of the body classes that inherit from this one to implement an `Update` method that sets a
            // non-zero acceleration during each update step.
            Acceleration = new Vector2(0, 0);
        }

        // See the definition of this method in Json::ISerializable::Serialize.
        // Do *not* modify this method.
        public IEnumerable<string> Serialize()
        {
            return new List<string>(new[]
            {
                "{" +
                "\"id\": \"" + Json.Escape(Id) + "\", " +
                "\"name\": \"" + Json.Escape(Name) + "\", " +
                "\"radius\": " + Json.Escape(Math.Pow(Mass / Density * 3 / (4 * Math.PI), 1d / 3)) + ", " +
                "\"position\": " + Position + ", " +
                "\"velocity\": " + Velocity + ", " +
                "\"acceleration\": " + Acceleration +
                "}"
            });
        }

        // Applies a force to the body. This method affects the acceleration of the body according to Newton's second law.
        public void ApplyForce(Vector2 force)
        {
            Acceleration += force / Mass;
        }
    }
}
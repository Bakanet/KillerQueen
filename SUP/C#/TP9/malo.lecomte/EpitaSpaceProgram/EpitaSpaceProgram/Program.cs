using System;
using EpitaSpaceProgram.ACDC;
using EpitaSpaceProgram.Scenes;

namespace EpitaSpaceProgram
{
    internal static class Program
    {
        public static void Main()
        {
            // Write your tests for Vector2 here.

            // When you're ready to start playing with the simulation, uncomment the line below!
            RunSimulation();
        }

        public static void RunSimulation()
        {
            var simulation = new Simulation();
            simulation.RegisterScene<TestScene>("0. Test");
            simulation.RegisterScene<GravityScene>("1. Gravity");
            simulation.RegisterScene<PendulumScene>("1.1. Pendulum");
            simulation.RegisterScene<SpringScene>("2. Spring");
            simulation.RegisterScene<DamperScene>("3. Damper");
            simulation.RegisterScene<CirclingScene>("4. Circling");
            simulation.RegisterScene<CirclingDemoScene>("4.1. Circling Demo");
            simulation.RegisterScene<CirclingComplexScene>("4.2. Circling Complex");
            simulation.RegisterScene<InfinityScene>("5. Infinity");
            simulation.RegisterScene<InfinityDemoScene>("5.1. Infinity Demo");
            simulation.RegisterScene<InfinityComplexScene>("5.2. Infinity Complex");
            simulation.RegisterScene<TwoBodyScene>("6. Two Body");
            simulation.RegisterScene<ThreeBodyScene>("7. Three Body");
            simulation.RegisterScene<BouncyEarthScene>("8. Bouncy Earth");
            simulation.RegisterScene<MagnetismScene>("9. Magnetism");
            simulation.Start();    
        }
    }
}
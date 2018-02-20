using System;
using System.Collections.Generic;
using System.Threading;
using Fleck;

namespace EpitaSpaceProgram.ACDC
{
    // A simulation contains many different types of scenes.
    internal class Simulation
    {
        private readonly SortedDictionary<string, Type> _scenes;

        public Simulation()
        {
            _scenes = new SortedDictionary<string, Type>();
        }

        public void Start()
        {
            FleckLog.LogAction = (level, message, ex) => { };
            var server = new WebSocketServer("ws://0.0.0.0:" + Constants.Port);
            server.Start(OnSocket);
            Console.WriteLine("The simulation is now running. Please visit http://esp.surge.sh/ to visualize it.");
            Thread.Sleep(Timeout.Infinite);
        }

        private void OnSocket(IWebSocketConnection socket)
        {
            var client = new Client(socket, CreateScene, GetScenes);
            var clientThread = new Thread(client.Start);
            clientThread.Start();
        }

        public void RegisterScene<T>(string name) where T : Scene
        {
            _scenes.Add(name, typeof(T));
        }

        private Scene CreateScene(string name, Action<string> sendScene)
        {
            if (!_scenes.ContainsKey(name))
                return null;
            Scene scene;
            try
            {
                scene = (Scene) Activator.CreateInstance(_scenes[name]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            scene.Callback = sendScene;
            return scene;
        }

        private IEnumerable<string> GetScenes()
        {
            return _scenes.Keys;
        }
    }
}

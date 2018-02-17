using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Fleck;

namespace EpitaSpaceProgram.ACDC
{
    // Represents a client of the simulation.
    // Upon connection, a client will receive a list of the available scenes.
    // Clients of the simulation can request scenes to be run, at which point they will receive updates on every
    // simulation tick.
    public class Client
    {
        private readonly Func<string, Action<string>, Scene> _createScene;
        private readonly Func<IEnumerable<string>> _getScenes;
        private readonly IWebSocketConnection _socket;
        private Scene _scene;
        private string _sceneName;
        private Thread _sceneThread;
        private Timer _timer;

        public Client(IWebSocketConnection socket, Func<string, Action<string>, Scene> createScene,
            Func<IEnumerable<string>> getScenes)
        {
            _socket = socket;
            _createScene = createScene;
            _getScenes = getScenes;
        }

        public void Start()
        {
            _socket.OnOpen = OnOpen;
            _socket.OnClose = Stop;
            _socket.OnError = e => Stop();
            _socket.OnMessage = OnMessage;
        }

        private void OnOpen()
        {
            _socket.Send(CreateMessage("scenes", SceneListJson()));
        }

        private void Stop()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            _timer = null;
            _scene?.Stop();
            _sceneThread?.Abort();
            _sceneThread = null;
        }

        private void StartScene()
        {
            _sceneThread = new Thread(_scene.Start);
            _sceneThread.Start();
        }

        private void SendScene(string json)
        {
            _socket.Send(CreateMessage("scene", json));
        }

        private void OnMessage(string message)
        {
            var parts = message.Split(new[] {' '}, 2);
            if (parts.Length == 1 && parts[0] == "reset")
            {
                Stop();
                _scene = _createScene(_sceneName, SendScene);
                StartScene();
            }
            else if (parts.Length == 2 && parts[0] == "scene")
            {
                var newScene = _createScene(parts[1], SendScene);
                if (newScene != null)
                {
                    Stop();
                    _sceneName = parts[1];
                    _scene = newScene;
                    StartScene();
                }
            }
        }

        private static string CreateMessage(string type, string data)
        {
            return "{" +
                   "\"type\": \"" + Json.Escape(type) + "\", " +
                   "\"data\": " + data +
                   "}";
        }

        private string SceneListJson()
        {
            return "[" + string.Join(", ", _getScenes().Select(s => "\"" + Json.Escape(s) + "\"")) + "]";
        }
    }
}
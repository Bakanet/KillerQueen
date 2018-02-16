using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EpitaSpaceProgram.ACDC
{
    // A scene contains objects, and updates then on every simulation tick.
    public abstract class Scene : Json.ISerializable
    {
        private readonly List<IEntity> _entities = new List<IEntity>();
        private TimeSpan _span;
        private double _t;
        private Timer _timer;

        protected Scene(double scale = 1d, double speed = 1d)
        {
            _t = 0;
            Scale = scale;
            Speed = speed;
        }

        public Action<string> Callback { get; set; }

        public double Scale { get; }

        public double Speed { get; }

        public string Serialize()
        {
            return "{ " +
                   "\"t\": " + Json.Escape(_t) + ", " +
                   "\"scale\": " + Json.Escape(Scale) + ", " +
                   "\"speed\": " + Json.Escape(Speed) + ", " +
                   "\"entities\": [" + string.Join(", ", _entities.SelectMany(entity => entity.Serialize())) + "]" +
                   "}";
        }

        protected void Add(IEntity entity)
        {
            _entities.Add(entity);
        }

        public void Start()
        {
            _span = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / Constants.RefreshRate);
            _timer = new Timer(Update, null, _span, _span);
        }

        public void Stop()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void Update(object stateInfo)
        {
            // Compute the elapsed time since the last simulation tick, in seconds.
            var delta = _span.Ticks / (double) TimeSpan.TicksPerSecond * Speed;
            _t += delta;
            foreach (var entity in _entities)
                entity.Update(delta);
            Callback(Serialize());
        }
    }
}
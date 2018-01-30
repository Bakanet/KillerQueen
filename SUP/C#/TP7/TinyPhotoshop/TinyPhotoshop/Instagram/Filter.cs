using System.Drawing;

namespace TinyPhotoshop
{
    public abstract class Filter
    {
        private string _name;

        public string Name => _name;

        public Filter(string name)
        {
            _name = name;
        }

        public abstract Bitmap Process(Bitmap image);
        
    }
}
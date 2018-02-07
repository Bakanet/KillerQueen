using System;
using System.Drawing;

namespace TinyPhotoshop
{
    public class MyImage
    {
        private string _name;
        private Bitmap _image = null;
        
        public MyImage(string name)
        {
            _name = name;
        }

        public void LoadImage(string path = "./resources")
        {
            _image = Bitmap.FromFile(path + "/" + _name) as Bitmap;
        }

        public void SaveImage(string path = "./resources")
        {
            _image.Save(path + "/" + _name);
        }

        public void ApplyFilter(Filter filter)
        {
            filter.Process(_image);
        }
    }
}
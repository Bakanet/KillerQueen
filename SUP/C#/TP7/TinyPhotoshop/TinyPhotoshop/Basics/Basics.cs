using System;
using System.Drawing;

namespace TinyPhotoshop
{
    public static class Basics
    {
        public static Color Grey(Color color)
        {
	        Color grey = new Color();
        }

        public static Color Binarize(Color color)
        {
			//FIXME
			throw new NotImplementedException();
		}
        
        public static Color BinarizeColor(Color color)
        {
			//FIXME
			throw new NotImplementedException();
		}
        
        public static Color Negative(Color color)
        {
			//FIXME
			throw new NotImplementedException();
		}
        
        public static Color Tinter(Color color, Color tint, int factor)
        {
			//FIXME
			throw new NotImplementedException();
		}

        public static Image Apply(Bitmap img, Func<Color, Color> func)
        {
			//FIXME
			throw new NotImplementedException();
		}
    }
}
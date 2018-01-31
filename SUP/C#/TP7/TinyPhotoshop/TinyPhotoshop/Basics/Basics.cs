using System;
using System.Drawing;

namespace TinyPhotoshop
{
    public static class Basics
    {
        public static Color Grey(Color color)
        {
	        throw new NotImplementedException();
        }

        public static Color Binarize(Color color)
        {
	        if (color.R + color.G + color.B <= Color.Gray.R + Color.Gray.G + Color.Gray.B)
		        return Color.Black;

	        return Color.White;
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
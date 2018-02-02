using System;
using System.Drawing;
using System.Net.Mime;
using System.Security.Policy;


namespace TinyPhotoshop
{
    public static class Geometry
    {      
        public static Image Resize(Bitmap img, int x, int y)
        {
			//FIXME
			throw new NotImplementedException();
        }
        
        public static Image Shift(Bitmap img, int x, int y)
        {
			// double boucle for -> i, j pour recup le pixel  +x, +y pour le decaler dans une new Image
	        Bitmap shifted = new Bitmap(img.Width, img.Height);
	        
	        for (int i = 0; i < img.Width; i++)
	        {
		        for (int j = 0; j < img.Height; j++)
		        {
			        shifted.SetPixel((i + x) % img.Width, (j + y) % img.Height, img.GetPixel(i, j));
		        }
	        }

	        return shifted;
        }

        public static Image SymmetryHorizontal(Bitmap img)
        {
			//FIXME
			throw new NotImplementedException();
		}
        
        public static Image SymmetryVertical(Bitmap img)
        {
			//FIXME
			throw new NotImplementedException();
		}
        
        public static Image SymmetryPoint(Bitmap img, int x, int y)
        {
			//FIXME
			throw new NotImplementedException();
		}
        
        public static Image RotationLeft(Bitmap img)
        {
			//FIXME
			throw new NotImplementedException();
		}
        
        public static Image RotationRight(Bitmap img)
        {
			//FIXME
			throw new NotImplementedException();
		}
    }
}
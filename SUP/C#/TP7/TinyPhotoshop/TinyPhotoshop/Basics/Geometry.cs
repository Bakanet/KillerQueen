using System;
using System.Drawing;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows.Forms;


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
	        Bitmap shiftalized = new Bitmap(img.Width, img.Height);
	        
	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        shiftalized.SetPixel((i + x) % img.Width, (j + y) % img.Height, img.GetPixel(i, j));
		        }
	        }

	        return shiftalized;
        }

        public static Image SymmetryHorizontal(Bitmap img)
        {
			Bitmap horizontalized = new Bitmap(img.Width, img.Height);

	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        horizontalized.SetPixel(i, img.Height - j - 1, img.GetPixel(i, j));
		        }
	        }

	        return horizontalized;
        }
        
        public static Image SymmetryVertical(Bitmap img)
        {
			Bitmap verticalized = new Bitmap(img.Width, img.Height);

	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; j++)
		        {
			        verticalized.SetPixel(img.Width - i - 1, j, img.GetPixel(i, j));
		        }
	        }

	        return verticalized;
        }
        
        public static Image SymmetryPoint(Bitmap img, int x, int y)
        {
			Bitmap pointalized = new Bitmap(img.Width, img.Height);

	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        //pointalized.SetPixel((2 * x - i) % img.Width,);
		        }
	        }
			throw new NotImplementedException();
		}
        
        public static Image RotationLeft(Bitmap img)
        {
			Bitmap leftalized = new Bitmap(img.Height, img.Width);

	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        leftalized.SetPixel(j, i, img.GetPixel(i, j));
		        }
	        }

	        return leftalized;
        }
        
        public static Image RotationRight(Bitmap img)
        {
	        return SymmetryVertical((Bitmap) RotationLeft(img));
        }
    }
}
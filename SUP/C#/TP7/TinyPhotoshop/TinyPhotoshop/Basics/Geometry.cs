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
	        Bitmap resized = new Bitmap(x, y);
	        double p = y / img.Height;
	        
	        for (int i = 0; i < x; i++)
	        {
		        for (int j = 0; j < y; j++)
		        {
			    	//Color pixel = img.GetPixel()
		        }
	        }
			throw new NotImplementedException();
        }
        
        public static Image Shift(Bitmap img, int x, int y)
        {
	        Bitmap shiftalized = new Bitmap(img.Width, img.Height);
	        int w = img.Width, h = img.Height;
	        
	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        shiftalized.SetPixel(((i + x) % w + w) % w, ((y + j) % h + h) % h, img.GetPixel(i, j));
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
	        int w = img.Width, h = img.Height;

	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        pointalized.SetPixel(((2 * x - i) % w + w) % w, ((2 * y) % h - j + h) % h, img.GetPixel(i, j));
		        }
	        }

	        return pointalized;
        }
        
        public static Image RotationLeft(Bitmap img)
        {
			Bitmap leftalized = new Bitmap(img.Height, img.Width);

	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        leftalized.SetPixel(j, img.Width - i - 1, img.GetPixel(i, j));
		        }
	        }

	        return leftalized;
        }
        
        public static Image RotationRight(Bitmap img)
        {
	        Bitmap rightalized = new Bitmap(img.Height, img.Width);

	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        rightalized.SetPixel(img.Height - j - 1, i, img.GetPixel(i, j));
		        }
	        }

	        return rightalized;
        }
    }
}
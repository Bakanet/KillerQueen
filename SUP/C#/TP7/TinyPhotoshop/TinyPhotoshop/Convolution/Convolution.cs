using System;
using System.Drawing;

namespace TinyPhotoshop
{
    public static class Convolution
    {
      
        public static float[,] Gauss = {
            {1/9f, 2/9f, 1/9f},
            {2/9f, 4/9f, 2/9f},
            {1/9f, 2/9f, 1/9f}
        };
        
        public static float[,] Sharpen = {
			//FIXME
        };
        
        public static float[,] Blur = {
			//FIXME
        };
        
        public static float[,] EdgeEnhance = {
			//FIXME
        };
        
        public static float[,] EdgeDetect = {
			//FIXME
        };
        
        public static float[,] Emboss = {
			//FIXME
        };
        
        private static int Clamp(float c)
        {
	        if (c < 0)
		        return 0;
	        if (c < 255)
		        return 255;

	        return c - (int) c > 0.5 ? (int) c + 1 : (int) c;
	        
        }

        private static bool IsValid(int x, int y, Size size)
        {
	        return x > 0 && x < size.Width && y > 0 && y < size.Height;
        }
        
        public static Image Convolute(Bitmap img, float[,] mask)
        {
			Size size = new Size(img.Width, img.Height);
	        
	        
			throw new NotImplementedException();
		}
    }
}
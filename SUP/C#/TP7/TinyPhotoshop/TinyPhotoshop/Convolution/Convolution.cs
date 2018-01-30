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
			//FIXME
			throw new NotImplementedException();
		}

        private static bool IsValid(int x, int y, Size size)
        {
			//FIXME
			throw new NotImplementedException();
		}
        
        public static Image Convolute(Bitmap img, float[,] mask)
        {
			//FIXME
			throw new NotImplementedException();
		}
    }
}
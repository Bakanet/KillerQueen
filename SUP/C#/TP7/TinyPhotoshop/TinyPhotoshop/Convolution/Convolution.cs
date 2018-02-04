using System;
using System.Drawing;
using System.Threading;

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
	        if (c > 255)
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
	        int w = img.Width, h = img.Height;
	        int maskedLine = mask.GetLength(0) / 2, maskedColumn = mask.GetLength(1) / 2;
	        Bitmap convoluted = new Bitmap(w, h);

	        for (int i = 0; i < w; ++i)
	        {
		        for (int j = 0; j < h; ++j)
		        {
			        float maskedR = 0, maskedG = 0, maskedB = 0;
			        
			        for (int k = -maskedLine; k <= maskedLine; ++k)
			        {
				        for (int l = -maskedColumn; l <= maskedColumn; ++l)
				        {
					        if (IsValid(i + k, j + l, size))
					        {
						        maskedR += mask[k + maskedLine, l + maskedColumn] * img.GetPixel(i + k, j + l).R;
						        maskedG += mask[k + maskedLine, l + maskedColumn] * img.GetPixel(i + k, j + l).G;
						        maskedB += mask[k + maskedLine, l + maskedColumn] * img.GetPixel(i + k, j + l).B;						        
					        }
				        }
			        }

			        convoluted.SetPixel(i, j, Color.FromArgb(Clamp(maskedR), Clamp(maskedG), Clamp(maskedB)));
		        }
	        }

	        return convoluted;
        }
    }
}
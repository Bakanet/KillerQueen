using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TinyPhotoshop
{
    public static class Steganography
    {

        public static Image EncryptImage(Bitmap img, Bitmap enc)
        {
	        int w = enc.Width, h = enc.Height;
	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        double imgRed = 240 & img.GetPixel(i, j).R; // 240(10) = 1111 0000(2)
			        double imgGreen = 240 & img.GetPixel(i, j).G;
			        double imgBlue = 240 & img.GetPixel(i, j).B;

			        imgRed += i < w && j < h ? (240 & enc.GetPixel(i, j).R) * 0.0625 : 0; //decalage de 4 bits
			        imgGreen += i < w && j < h ? (240 & enc.GetPixel(i, j).G) * 0.0625 : 0;
			        imgBlue += i < w && j < h ? (240 & enc.GetPixel(i, j).B) * 0.0625 : 0;
			        
			        img.SetPixel(i, j, Color.FromArgb((int) imgRed, (int) imgGreen, (int) imgBlue));
		        }
	        }

	        return img;
        }

		public static Image DecryptImage(Bitmap img)
		{
			Bitmap decrypted = new Bitmap(img.Width, img.Height);
			
			for (int i = 0; i < img.Width; ++i)
			{
				for (int j = 0; j < img.Height; ++j)
				{
					double decRed = 15 & img.GetPixel(i, j).R * 16; // 15(10) = 0000 1111(2)
					double decGreen = 15 & img.GetPixel(i, j).G * 16;
					double decBlue = 15 & img.GetPixel(i, j).B * 16;
					
					decrypted.SetPixel(i, j, Color.FromArgb((int) decRed, (int) decGreen, (int) decBlue));
				}
			}

			return decrypted;
		}

		public static Image EncryptText(Bitmap img, string text)
		{
			//FIXME
			throw new NotImplementedException();
		}

		public static string DecryptText(Bitmap img)
        {
			//FIXME
			throw new NotImplementedException();
		}
    }
}
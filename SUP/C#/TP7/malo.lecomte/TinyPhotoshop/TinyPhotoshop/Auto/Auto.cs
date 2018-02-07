using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TinyPhotoshop
{
    public static class Auto
    {

        public static Dictionary<char, int[]> GetHistogram(Bitmap img)
        {
            Dictionary<char, int[]> hist = new Dictionary<char, int[]> 
                                           { { 'R', new int[256] },
                                             { 'G', new int[256] },
                                             { 'B', new int[256] } };


	        for (int i = 0; i < img.Width; ++i)
	        {
		        for (int j = 0; j < img.Height; ++j)
		        {
			        hist['R'][img.GetPixel(i, j).R] += 1;
			        hist['G'][img.GetPixel(i, j).G] += 1;
			        hist['B'][img.GetPixel(i, j).B] += 1;
		        }
	        }

	        return hist;
        }

		public static int FindLow(int[] hist)
		{
			int i = 0;

			while (hist[i] == 0)
			{
				++i;
			}

			return i;
		}

		public static int FindHigh(int[] hist)
		{
			int i = 255;

			while (hist[i] == 0)
			{
				--i;
			}

			return i;
		}

		public static Dictionary<char, int>
        FindBound(Dictionary<char, int[]> hist, Func<int[], int> f)
        {
			Dictionary<char, int> bound = new Dictionary<char, int>();

	        foreach (char c in hist.Keys)
	        {
		        bound.Add(c, f(hist[c]));
	        }

	        return bound;
        }


		public static int[] ComputeLUT(int low, int high)
        {
			int[] LUT = new int[256];

	        for (int i = 0; i < 256; ++i)
	        {
		        if (i < low)
			        LUT[i] = 0;
		        else if (i > high)
			        LUT[i] = 255;
		        else
			        LUT[i] = 255 * (i - low) / (high - low);
	        }

	        return LUT;
        }

		public static Dictionary<char, int[]> GetLUT(Bitmap img)
        {
			Dictionary<char, int[]> LUT = new Dictionary<char, int[]>();

			//FIXME

			return LUT;
		}

        public static Image ConstrastStretch(Bitmap img)
        {
			Dictionary<char, int[]> LUT = GetLUT(img);

			//FIXME

			return img;
		}

    }
}

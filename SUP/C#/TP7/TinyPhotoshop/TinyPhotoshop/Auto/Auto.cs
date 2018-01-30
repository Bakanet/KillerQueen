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


			//FIXME
			throw new NotImplementedException();
		}

		public static int FindLow(int[] hist)
        {
			//FIXME
			throw new NotImplementedException();
		}

		public static int FindHigh(int[] hist)
        {
			//FIXME
			throw new NotImplementedException();
		}

		public static Dictionary<char, int>
        FindBound(Dictionary<char, int[]> hist, Func<int[], int> f)
        {
			Dictionary<char, int> bound = new Dictionary<char, int>();
			
			//FIXME

			throw new NotImplementedException();
		}


		public static int[] ComputeLUT(int low, int high)
        {
			int[] LUT = new int[256];

			//FIXME

			throw new NotImplementedException();
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

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace TinyPhotoshop
{
    public abstract class InstaFilter : Filter
    {
        public InstaFilter(string name) : base(name)
        {
        }

        //https://en.wikipedia.org/wiki/Vignetting

		public Bitmap Vignette(Bitmap b, Color c1, Color c2, float crop = 0.5f)
        {

			//FIXME
			throw new NotImplementedException();
		}
    }
}
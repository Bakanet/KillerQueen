using System;
using System.Drawing;

namespace TinyPhotoshop
{
    public static class Basics
    {
        public static Color Grey(Color color)
        {
            int gray = (int) (color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
            return Color.FromArgb(gray, gray, gray);
        }

        public static Color Binarize(Color color)
        {
            return color.R + color.G + color.B <= 3 * Color.Gray.R ? Color.Black : Color.White;
        }

        public static Color BinarizeColor(Color color)
        {
            int r = color.R <= Color.Gray.R ? 0 : 255;
            int g = color.G <= Color.Gray.G ? 0 : 255;
            int b = color.B <= Color.Gray.B ? 0 : 255;
            return Color.FromArgb(r, g, b);
        }

        public static Color Negative(Color color)
        {
            int r = 255 - color.R, g = 255 - color.G, b = 255 - color.B;
            return Color.FromArgb(r, g, b);
        }

        public static Color Tinter(Color color, Color tint, int factor)
        {
            return Color.FromArgb((int) (tint.R * factor / 100.0 + color.R * (100.0 - factor) / 100.0),
                (int) (tint.R * factor / 100.0 + color.G * (100.0 - factor) / 100.0),
                (int) (tint.R * factor / 100.0 + color.B * (100.0 - factor) / 100.0));
        }

        public static Image Apply(Bitmap img, Func<Color, Color> func)
        {
            for (int i = 0; i < img.Width; ++i)
            {
                for (int j = 0; j < img.Height; ++j)
                {
                    img.SetPixel(i, j, func(img.GetPixel(i, j)));
                }
            }

            return img;
        }
    }
}
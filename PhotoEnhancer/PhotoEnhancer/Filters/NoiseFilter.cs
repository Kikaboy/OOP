using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PhotoEnhancer
{
    public class NoiseFilter : PixelFilter<NoiseParameters>
    {
        public override string ToString()
        {
            return "Интенсивность шума";
        }

        public override Pixel ProcessPixel(Pixel originalPixel,
           NoiseParameters parameters)
        {
            var red = originalPixel.R;
            var green = originalPixel.G;
            var blue = originalPixel.B;
            var rnd = new Random();
            for (var i = 0; i < 340; i++)
            {
                var r = (rnd.NextDouble());
                red = (parameters.Intensity * r + (1 - parameters.Intensity) * originalPixel.R);
                var r2 = (rnd.NextDouble());
                green = (parameters.Intensity * r2 + (1 - parameters.Intensity) * originalPixel.G);
                var r3 = (rnd.NextDouble());
                blue = (parameters.Intensity * r3 + (1 - parameters.Intensity) * originalPixel.B);
            }
            return new Pixel(red, green, blue);

        }
    }
}

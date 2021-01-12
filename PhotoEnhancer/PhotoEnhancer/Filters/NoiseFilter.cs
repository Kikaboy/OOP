using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class NoiseFilter : PixelFilter<NoiseParameters>
    {
        static Random rnd = new Random();
        public override string ToString()
        {
            return "Интенсивность шума";
        }

        public override Pixel ProcessPixel(Pixel originalPixel,
           NoiseParameters parameters)
        {
            double red, green, blue;
            
                var r = (rnd.NextDouble());
                red = (parameters.Intensity * r + (1 - parameters.Intensity) * originalPixel.R);
                var r2 = (rnd.NextDouble());
                green = (parameters.Intensity * r2 + (1 - parameters.Intensity) * originalPixel.G);
                var r3 = (rnd.NextDouble());
                blue = (parameters.Intensity * r3 + (1 - parameters.Intensity) * originalPixel.B);

            return new Pixel(red, green, blue);

        }
    }
}

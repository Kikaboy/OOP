using System;
using System.Windows.Forms;
using System.Drawing;

namespace PhotoEnhancer
{
    static class Program
    {
        static Random rnd = new Random();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var mainForm = new MainForm();

            mainForm.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение",
                (pixel, parameters) => pixel * parameters.Coefficient
                ));

            mainForm.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (pixel, parameters) =>
                {
                    var chanel = 0.3 * pixel.R +
                                0.6 * pixel.G +
                                0.1 * pixel.B;

                    return new Pixel(chanel, chanel, chanel);
                }
                ));
            
            mainForm.AddFilter(new PixelFilter<NoiseParameters>(
                "Интенсивность Шума",
                (originalPixel, parameters) =>
                {
                    
                    var intensity = (parameters as NoiseParameters).Intensity;
                    return new Pixel(
                        NoiseGen(originalPixel.R, intensity),
                        NoiseGen(originalPixel.G, intensity),
                        NoiseGen(originalPixel.B, intensity));

                    double NoiseGen(double channel, double intensity1)
                    {
                        var r = rnd.NextDouble();
                        return Pixel.Trim((intensity1 * r + (1 - intensity1)) * channel);
                    }

                    
                }
                ));

            mainForm.AddFilter(new TransformFilter(
                "Отражение по вертикали",
                size => size,
                (point, size) => new Point(point.X, size.Height - 1 - point.Y)));

            mainForm.AddFilter(new TransformFilter<HorizontalTiltParameters>(
            "Скос по горизонтали", new HorizontalTiltTransformer()));

            Application.Run(mainForm);
        }
    }
}

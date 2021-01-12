using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PhotoEnhancer
{
    class HorizontalTiltTransformer : ITransformer<HorizontalTiltParameters>
    {
        public Size ResultSize { get; set; }

        Size originalSize;
        double angleInRadians;
        public void Initialize(Size size, HorizontalTiltParameters parameters)
        {
            originalSize = size;
            angleInRadians = parameters.AngleInDegrees * Math.PI / 180;

            ResultSize = new Size(
            originalSize.Width + (int)(size.Height * Math.Abs( Math.Tan(angleInRadians))), 
            originalSize.Height);
        }

        public Point? MapPoint(Point point)
        {
            point = new Point(point.X, point.Y );
            int x;
            var y = (int)(point.Y);
            if (angleInRadians > 0)
                x = (int)(point.X - (originalSize.Height - point.Y-1)*Math.Tan(angleInRadians));
            else
                x = (int)(point.X + point.Y * Math.Tan(angleInRadians));
            

            if (x < 0 || x >= originalSize.Width || y < 0 || y >= originalSize.Height)
                return null;

            return new Point(x, y);
        }
    }
}

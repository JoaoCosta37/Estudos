using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Customizers.ImagesCustomizer
{
    public class TransformImageSepia : TransformImages
    {
        protected override string getTransformationName()
        {
            return "sepia";
        }

        protected override void transformPixel(Bitmap bmp, Color p, int y, int x)
        {
            int tr = Convert.ToInt32((0.393 * p.R) + (0.769 * p.G) + (0.189 * p.B));
            int tg = Convert.ToInt32((0.349 * p.R) + (0.686 * p.G) + (0.168 * p.B));
            int tb = Convert.ToInt32((0.272 * p.R) + (0.534 * p.G) + (0.131 * p.B));

            int r = tr > 255 ? 255 : tr;
            int g = tg > 255 ? 255 : tg;
            int b = tb > 255 ? 255 : tb;

            bmp.SetPixel(x, y, Color.FromArgb(255, r, g, b));
        }
    }
}

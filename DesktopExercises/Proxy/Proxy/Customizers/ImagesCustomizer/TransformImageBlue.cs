using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Customizers.ImagesCustomizer
{
    public class TransformImageBlue : TransformImages
    {
        protected override string getTransformationName()
        {
            return "blue";
        }

        protected override void transformPixel(Bitmap bmp, Color p, int y, int x)
        {
            int a = p.A;
            int r = p.R;
            int g = p.G;
            int b = p.B;

            bmp.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));
        }
    }
}

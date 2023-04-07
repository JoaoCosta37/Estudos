using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Customizers.ImagesCustomizer
{
    public class TransformImageInvert : TransformImages
    {
        protected override string getTransformationName()
        {
            return "invert";
        }

        protected override void transformPixel(Bitmap bmp, Color p, int y, int x)
        {
            int a = p.A;
            int r = 255 - p.R;
            int g = 255 - p.G;
            int b = 255 - p.B;


            //set new pixel value
            bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
        }
    }
}

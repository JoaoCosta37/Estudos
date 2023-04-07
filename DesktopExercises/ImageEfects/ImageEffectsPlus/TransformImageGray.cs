using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEffectsLibrary
{
    public class TransformImageGray : TransformImages
    {
        protected override string getTransformationName()
        {
            return "gray";
        }

        protected override void transformPixel(Bitmap bmp, Color p, int y, int x)
        {
            //extract pixel component ARGB
            int a = p.A;
            int r = p.R;
            int g = p.G;
            int b = p.B;

            //find average
            int avg = (r + g + b) / 3;

            //set new pixel value
            bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
        }
    }
}

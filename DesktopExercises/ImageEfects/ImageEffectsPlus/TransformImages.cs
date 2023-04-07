using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEffectsLibrary
{
    public abstract class TransformImages
    {

        public void TransformImage(Stream originalStream, Stream modifiedStream, ImageFormat imageFormat)
        {

            //read image
            Bitmap bmp = new Bitmap(originalStream);

            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p;

            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);
                    transformPixel(bmp, p, y, x);
                }
            }

            bmp.Save(modifiedStream, imageFormat);

            //SaveNewImage(bmp, path, getTransformationName());
        }

        protected abstract string getTransformationName();
        protected abstract void transformPixel(Bitmap bmp, Color p, int y, int x);

        //public void SaveNewImage(Bitmap bmp, string path, string transformtype)
        //{
        //    var saveDir = Path.GetDirectoryName(path);
        //    var savePath = Path.Combine(saveDir, Path.GetFileNameWithoutExtension(path) + transformtype + Path.GetExtension(path));
        //    bmp.Save(savePath);
        //}
    }
}

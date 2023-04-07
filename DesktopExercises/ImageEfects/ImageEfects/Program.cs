using ImageEffectsLibrary;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageEfects
{
    public class Program
    {
        static void Main(string[] args)
        {
            TransformImages transform = new TransformImageSepia();
            MemoryStream ms = new MemoryStream();
            using (FileStream fsOut = File.OpenWrite(@"c:\temp\images\vaticano-out.jpg"))
            {

                using (FileStream fs = File.OpenRead(@"c:\temp\images\vaticano.jpg"))
                {
                    transform.TransformImage(fs, fsOut, ImageFormat.Jpeg);
                }
            }

            ms.Position = 0;

        }
    }
}

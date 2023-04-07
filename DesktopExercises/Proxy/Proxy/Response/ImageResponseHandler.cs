using Proxy.Customizers.Factory;
using Proxy.Customizers.ImagesCustomizer;
using Proxy.Customizers.ImagesCustomizer.Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Response
{
    public class ImageResponseHandler : IResponseHandler
    {
        public Stream GetResponse(Stream responseFromWebSiteBeingRelayedStream, WebResponse responseFromWebSiteBeingRelayed)
        {

            var format = GetImageFormat(responseFromWebSiteBeingRelayed);
            if (format is null)
                return responseFromWebSiteBeingRelayedStream;
            else
            {
                ITransformImagesFactory transformImageFactory = new TransformImagesFactory();
                var transform = transformImageFactory.GetTransformImages();
                MemoryStream ms = new MemoryStream();
                transform.TransformImage(responseFromWebSiteBeingRelayedStream, ms, format);
                ms.Position = 0;
                return ms;
            }
        }

        private ImageFormat GetImageFormat(WebResponse response)
        {
            if (response.ContentType.EndsWith("png"))
                return ImageFormat.Png;
            if (response.ContentType.EndsWith("jpeg"))
                return ImageFormat.Jpeg;
            else if (response.ContentType.EndsWith("gif"))
                return ImageFormat.Gif;
            else if (response.ContentType.EndsWith("bmp"))
                return ImageFormat.Bmp;
            else if (response.ContentType.EndsWith("icon"))
                return ImageFormat.Icon;
            else
                return null;
        }
    }
}

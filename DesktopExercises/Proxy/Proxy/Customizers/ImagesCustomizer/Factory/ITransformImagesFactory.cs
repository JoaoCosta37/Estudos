using Proxy.Customizers.ImagesCustomizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Customizers.Factory
{
    internal interface ITransformImagesFactory
    {
        TransformImages GetTransformImages();
    }
}

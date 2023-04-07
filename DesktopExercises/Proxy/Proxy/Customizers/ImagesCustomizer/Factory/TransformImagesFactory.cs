using Proxy.Config;
using Proxy.Customizers.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Customizers.ImagesCustomizer.Factory
{
    public class TransformImagesFactory : ITransformImagesFactory
    {
        public TransformImages GetTransformImages()
        {
            var imageCustomizerConfig = Configs.GetConfig("customizeImage");

            //            var imageTransform = Activator.CreateInstance(typeof(TransformImages).Assembly.FullName, imageCustomizerConfig).Unwrap();

            var imageTransform = typeof(TransformImages).Assembly.GetType(imageCustomizerConfig);


            return (TransformImages)imageTransform.GetConstructor(new Type[0]).Invoke(new Type[0]);
            
            //if (imageCustomizerConfig == "gray")
            //    return new TransformImageGray();

            //else if (imageCustomizerConfig == "blue")
            //    return new TransformImageBlue();

            //else if (imageCustomizerConfig == "invert")
            //    return new TransformImageBlue();

            //else if (imageCustomizerConfig == "sepia")
            //    return new TransformImageSepia();
            //else
            //    throw new InvalidOperationException("Invalid Customizer!");
        }
    }
}

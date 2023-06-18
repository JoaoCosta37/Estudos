using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PaintApp.Droid.Services;
using PaintApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(PathProviderAndroid))]

namespace PaintApp.Droid.Services
{

    public class PathProviderAndroid : IPathProvider
    {
        public string GetImagesPath()
        {
            var path = Android.OS.Environment.GetExternalStoragePublicDirectory(
            Android.OS.Environment.DirectoryPictures).AbsolutePath;

            return path;
        }
    }
}
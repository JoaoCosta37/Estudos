using PaintApp.Services;
using PaintApp.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchTracking;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace PaintApp
{
    public partial class MainPage : ContentPage
    {
        Dictionary<long, SKPath> inProgressPaths = new Dictionary<long, SKPath>();
        List<SKPath> completedPaths = new List<SKPath>();
        

        private SKPaint paint = new SKPaint()
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 80,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };

        public MainPage()
        {
            InitializeComponent();
            var vm = new MainPageViewModel();
            BindingContext = vm;

            vm.OnStreamLoaded += Vm_OnStreamLoaded;
        }
        SKBitmap imageBitmap;
        private void Vm_OnStreamLoaded(Stream obj)
        {
           
            using (Stream stream = obj)
            {

                imageBitmap = SKBitmap.Decode(stream);

             
            }
            SkCanvasView.InvalidateSurface();
        }

        private void SkCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            if (imageBitmap != null)
            {
                canvas.DrawBitmap(imageBitmap,200,200);
            }

            //foreach(var path in paths)
            //{
            //    canvas.DrawPath(path, paint);
            //}
            foreach (SKPath path in completedPaths)
            {
                canvas.DrawPath(path, paint);
            }

            foreach (SKPath path in inProgressPaths.Values)
            {
                canvas.DrawPath(path, paint);
            }

            var image = args.Surface.Snapshot();

           //var data = image.Encode(SKEncodedImageFormat.Png, 80);

            //var pathProvider = DependencyService.Get<IPathProvider>();

            //var folder = Environment.GetFolderPath(Environment.SpecialFolder.PrinterShortcuts);
            //var file = System.IO.Path.Combine(pathProvider.GetImagesPath(), "image.png");
            
            //var stream = File.OpenWrite(file);

            //data.SaveTo(stream);

            

        }

        private void TouchEffect_TouchAction(object sender, TouchTracking.TouchActionEventArgs args)
        {

            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = new SKPath();
                        path.MoveTo(ConvertToPixel(args.Location));
                        inProgressPaths.Add(args.Id, path);
                        SkCanvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Moved:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = inProgressPaths[args.Id];
                        path.LineTo(ConvertToPixel(args.Location));
                        SkCanvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Released:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = inProgressPaths[0];
                        if (path.PointCount == 1)
                        {
                            path.LineTo(ConvertToPixel(args.Location));
                        }
                        completedPaths.Add(inProgressPaths[args.Id]);
                        inProgressPaths.Remove(args.Id);
                        SkCanvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Cancelled:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        inProgressPaths.Remove(args.Id);
                        SkCanvasView.InvalidateSurface();
                    }
                    break;
            }
        }

        SKPoint ConvertToPixel(TouchTrackingPoint pt)
        {
            return new SKPoint((float)(SkCanvasView.CanvasSize.Width * pt.X / SkCanvasView.Width),
                               (float)(SkCanvasView.CanvasSize.Height * pt.Y / SkCanvasView.Height));
        }



    }
}

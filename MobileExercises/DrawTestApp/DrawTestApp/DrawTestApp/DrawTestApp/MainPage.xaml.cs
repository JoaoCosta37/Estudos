using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DrawTestApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        public void SkCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            var circlePaint = new SKPaint()
            {
                Color = SKColors.White,
                Style = SKPaintStyle.Fill,
                StrokeWidth = 30,
            };
            var circlePaint2 = new SKPaint()
            {
                Color = SKColors.Blue,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 30,
            };

            canvas.Clear();
            SKPoint referencesPoint = new SKPoint(info.Width / 2, info.Height / 2);

            float externalRadius = Math.Min(referencesPoint.X, referencesPoint.Y) - 140;

            canvas.DrawCircle(referencesPoint.X, referencesPoint.Y, externalRadius, circlePaint);

            var radius = externalRadius + 50;

            SKRect rect = new SKRect(referencesPoint.X - radius, referencesPoint.Y - radius,
                         referencesPoint.X + radius, referencesPoint.Y + radius);

            int quantidadeDeDivisores = 6;

            var degree = 360 / quantidadeDeDivisores;
            var point = 270;

            for (int i = 1; i <= quantidadeDeDivisores; i++)
            {
            var inicialArc = validationDegree(point-2);
                var endArc = 2;

                canvas.DrawArc(rect, inicialArc, endArc, false, circlePaint2);

                point += degree;
                point = validationDegree(point);
            }

        }

        //private int calcularGrau(int degree, int valueForSum)
        //{
        //    var resultado = degree + valueForSum;
        //    if(resultado > 360)
        //    {
        //        resultado -= 360;
        //    }
        //    return resultado;
        //}
        //private int arcPointCalculator(int degree)
        //{
        //    degree -= 2;
        //    validationDegree(degree);
        //    return degree;
        //}
        private int validationDegree(int degree)
        {
            if (degree > 360)
            {
                degree -= 360;
            }
            else if (degree < 0)
            {
                degree = 360 + degree; 
            }
            return degree;
        }

    }
}

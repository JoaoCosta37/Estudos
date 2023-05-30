using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Timers;
using PomodoroApp.ViewModels;
using SkiaSharp.Views.Forms;
using System.Globalization;

namespace PomodoroApp.Views
{
    public partial class MainPage : ContentPage
    {

        private float startAngle = 270;
        private float sweepAngle = 359;
        private float referenceRadius;
        private SKPaint partitionCircle = new SKPaint()
        {
            Color = SKColors.Blue,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 30,
        };
        private SKPaint internalCiclePaint = new SKPaint()
        {
            Color = SKColors.White,
            Style = SKPaintStyle.Fill,
            StrokeWidth = 30,
        };
        private SKPaint externalCiclePaint = new SKPaint()
        {
            Color = SKColors.White,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 30,
        };
        private SKPoint referencesPoint;
        MainPageViewModel viewModel { get => this.BindingContext as MainPageViewModel; }

        public MainPage()
        {
            InitializeComponent();

            this.BindingContextChanged += MainPage_BindingContextChanged;
        }

        private void MainPage_BindingContextChanged(object sender, EventArgs e)
        {
            if (viewModel != null)
            {
                viewModel.PropertyChanged += ViewModel_PropertyChanged;
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainPageViewModel.CurrentTime))
            {
                UpdateDraw();
            }
        }

        private void SkCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            this.referencesPoint = new SKPoint(info.Width / 2, info.Height / 2);

            this.referenceRadius = Math.Min(referencesPoint.X, referencesPoint.Y) - 140;

            this.drawExternalCircle(canvas);

            this.drawInternalCircle(canvas);

        }
        private void drawExternalCircle(SKCanvas canvas)
        {
            canvas.DrawCircle(referencesPoint.X, referencesPoint.Y, referenceRadius, externalCiclePaint);
        }
        private void drawInternalCircle(SKCanvas canvas)
        {
            float innerRadius = referenceRadius - 50;

            SKRect rect = new SKRect(referencesPoint.X - innerRadius, referencesPoint.Y - innerRadius,
                         referencesPoint.X + innerRadius, referencesPoint.Y + innerRadius);
             
            if (!viewModel.Start)
            {
                drawTriangle(canvas, innerRadius); 
            }
            else
            {

                using (SKPath path = new SKPath())
                {
                    using (SKPaint fillPaint = new SKPaint())
                    using (SKPaint outlinePaint = new SKPaint())
                    {
                        path.MoveTo(referencesPoint);
                        path.ArcTo(rect, startAngle, sweepAngle, false);
                    }

                    canvas.DrawPath(path, new SKPaint()
                    {
                        Color = viewModel.IsRunning ? SKColors.White : SKColors.White.WithAlpha(65),
                        Style = SKPaintStyle.Fill,
                    });
                }

                if (!viewModel.IsRunning)
                {
                    drawPause(canvas);
                    
                }
            }
        }
        private void drawTriangle(SKCanvas canvas, float referencesRadius)
        {
            var sideTriangle = referencesRadius / 3;
            var sideTriangleDislocated = sideTriangle - (sideTriangle / 2);

            var path2 = new SKPath { FillType = SKPathFillType.EvenOdd };
            path2.MoveTo(referencesPoint.X + sideTriangle, referencesPoint.Y);
            path2.LineTo(referencesPoint.X - sideTriangleDislocated, referencesPoint.Y - sideTriangle);
            path2.LineTo(referencesPoint.X - sideTriangleDislocated, referencesPoint.Y + sideTriangle);
            path2.LineTo(referencesPoint.X + sideTriangle, referencesPoint.Y);
            path2.Close();

            canvas.DrawPath(path2, internalCiclePaint);
        }
        private void drawPause(SKCanvas canvas)
        {
            SKRect pauseRectLeft = new SKRect(referencesPoint.X - 95, referencesPoint.Y - 100,
                              referencesPoint.X - 35, referencesPoint.Y + 100);

            SKRect pauseRectRight = new SKRect(referencesPoint.X + 35, referencesPoint.Y - 100,
                      referencesPoint.X + 95, referencesPoint.Y + 100);

            canvas.DrawRect(pauseRectLeft, new SKPaint()
            {
                Color = SKColors.White,
                Style = SKPaintStyle.Fill,
            });

            canvas.DrawRect(pauseRectRight, new SKPaint()
            {
                Color = SKColors.White,
                Style = SKPaintStyle.Fill,
            });
        }
        public void UpdateDraw()
        {
            var porcentTime = 100 - (viewModel.CurrentTime.TotalSeconds * 100) / viewModel.Pomodoro.TotalSeconds;

            this.sweepAngle = (float)(360d * porcentTime) / 100;
            SkCanvasView.InvalidateSurface();
        }

    }
}

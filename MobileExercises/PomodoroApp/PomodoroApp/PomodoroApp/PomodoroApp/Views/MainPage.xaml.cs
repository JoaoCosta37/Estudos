using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private float externalRadius;
        private SKPaint partitionCircle = new SKPaint()
        {
            Color = SKColors.White,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 20,
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
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    BindingContext
        //}
        //protected override bool OnBackButtonPressed()
        //{
        //    viewModel.BackgColor = viewModel.BackgColor;
        //    return true;
        //}

        private void MainPage_BindingContextChanged(object sender, EventArgs e)
        {
            if (viewModel != null)
            {
                viewModel.PropertyChanged += ViewModel_PropertyChanged;
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainPageViewModel.CurrentTime) || e.PropertyName == nameof(MainPageViewModel.Pomodoro) || e.PropertyName == nameof(MainPageViewModel.IsRunning ))
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

            this.externalRadius = Math.Min(referencesPoint.X, referencesPoint.Y) - 140;

            this.drawExternalCircle(canvas);

            this.drawInternalCircle(canvas);

            this.drawCircleDivider(canvas);

        }
        private void drawExternalCircle(SKCanvas canvas)
        {
            canvas.DrawCircle(referencesPoint.X, referencesPoint.Y, externalRadius, externalCiclePaint);
        }
        private void drawInternalCircle(SKCanvas canvas)
        {
            float innerRadius = externalRadius - 50;

            SKRect rect = new SKRect(referencesPoint.X - innerRadius, referencesPoint.Y - innerRadius,
                         referencesPoint.X + innerRadius, referencesPoint.Y + innerRadius);
             
            if (!viewModel.IsStarted)
            {
                drawTriangle(canvas, innerRadius); 
            }
            else
            {
                if (!viewModel.IsRunning)
                {
                    drawPause(canvas);

                }

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
        private void drawCircleDivider(SKCanvas canvas)
        {
            if(viewModel.Pomodoro == null || viewModel.Pomodoro.TotalMinutes < 1)
            {
                return;
            }
            float radius = externalRadius + 70;

            SKRect rect = new SKRect(referencesPoint.X - radius, referencesPoint.Y - radius,
                         referencesPoint.X + radius, referencesPoint.Y + radius);
            int dividersQuantity = (int)viewModel.Pomodoro.TotalMinutes;
            var degree = 360 / dividersQuantity;
            var point = 270f;

            for (int i = 1; i <= dividersQuantity; i++)
            {
                float inicialArc = Convert.ToSingle(adjustDegree(point - .5f));
                float endArc = 1f;

                canvas.DrawArc(rect, inicialArc, endArc, false, partitionCircle);

                point += degree;
                point = adjustDegree(point);
            }
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
        private float adjustDegree(float degree)
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

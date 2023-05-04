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

namespace PomodoroApp.Views
{
    public partial class MainPage : ContentPage
    {
        private Timer timer;
        private float startAngle = 270;
        private float sweepAngle = 359;
        //private TimeSpan pomodoro = TimeSpan.FromSeconds(60);

        MainPageViewModel viewModel { get => this.BindingContext as MainPageViewModel; } 


        public MainPage()
        {
            InitializeComponent();
            timerStart();
        }

        private void SkCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
        {
            // e.Surface.Canvas.DrawLine(100,100, 50,

            //);
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            SKPoint referencesPoint = new SKPoint(info.Width / 2, info.Height / 3);

            float externalRadius = Math.Min(info.Width / 2, info.Height / 2) - 2 * 80;

            canvas.DrawCircle(referencesPoint.X, referencesPoint.Y, externalRadius, new SKPaint()
            {
                Color = SKColors.White,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 30,
            }) ;
            
            float innerRadius = externalRadius - 50;
          

            SKRect rect = new SKRect(referencesPoint.X - innerRadius, referencesPoint.Y - innerRadius,
                         referencesPoint.X + innerRadius, referencesPoint.Y + innerRadius);

            //SKRect rect = new SKRect(100, 100, info.Width - 100, info.Height - 100);

            

            // float sweepAngle = 360f * item.Value / totalValues;

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
                    Color = SKColors.White,
                    Style = SKPaintStyle.Fill,
                });

            }
        }
        private void UpdateDraw()
        {
            var porcentTime = 100 - (viewModel.CurrentTime.TotalSeconds * 100)/viewModel.Pomodoro.TotalSeconds;
            
            //var porcentTime = 
            
            this.sweepAngle = (float)(360d * porcentTime) / 100;
            SkCanvasView.InvalidateSurface();
        }
        private void timerStart()
        {
            if (timer == null)
            {
                this.timer = new Timer();
                this.timer.Interval = 1000;
                this.timer.Elapsed += Timer_Elapsed;
            }
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (viewModel.RemainingTime == TimeSpan.Zero)
            {
                this.timer.Stop();
                return;
                //var action = Application.Current.MainPage.DisplayAlert("Fim", "Timer Encerrado", "OK");
            }
            viewModel.CurrentTime = viewModel.CurrentTime.Add(TimeSpan.FromSeconds(1));
            UpdateDraw();
        }
    }
}

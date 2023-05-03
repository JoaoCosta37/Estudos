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

namespace PomodoroApp.Views
{
    public partial class MainPage : ContentPage
    {
        private Timer timer;
        private TimeSpan currentTime;
        private float startAngle = 270;
        private float sweepAngle = 359;
        private TimeSpan pomodoro = TimeSpan.FromSeconds(10);
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
            SKPoint center = new SKPoint(info.Width / 2, info.Height / 2);


            float radius = Math.Min(info.Width / 2, info.Height / 2) - 2 * 50;

            SKRect rect = new SKRect(center.X - radius, center.Y - radius,
                         center.X + radius, center.Y + radius);

            //SKRect rect = new SKRect(100, 100, info.Width - 100, info.Height - 100);

            

            // float sweepAngle = 360f * item.Value / totalValues;

            using (SKPath path = new SKPath())
            {
                using (SKPaint fillPaint = new SKPaint())
                using (SKPaint outlinePaint = new SKPaint())
                {
                    path.MoveTo(center);
                    path.ArcTo(rect, startAngle, sweepAngle, false);
                }

                canvas.DrawPath(path, new SKPaint()
                {
                    Color = SKColors.Green,
                    Style = SKPaintStyle.Fill,
                });

            }
        }
        private void DrawByParameter()
        {
            var porcentTime = 100 - (currentTime.TotalSeconds * 100)/pomodoro.TotalSeconds;
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
            if (currentTime == pomodoro)
            {
                this.timer.Stop();
                //var action = Application.Current.MainPage.DisplayAlert("Fim", "Timer Encerrado", "OK");
            }
            currentTime = currentTime.Add(TimeSpan.FromSeconds(1));
            DrawByParameter();
        }
    }
}

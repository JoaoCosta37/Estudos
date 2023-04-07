using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
   public class Cao
    {
        public static int startinglocation;
        public static int racetracklenght;
        PictureBox MyPictureBox;
        int location;
        Random MyRandom;

        public Cao(PictureBox MyPictureBox)
        {
            this.MyPictureBox = MyPictureBox;
            location = startinglocation;
        }


      public  bool run()
        {
            MyRandom = new Random();
            location += MyRandom.Next(0,5);
            Point p = MyPictureBox.Location;
            p.X = location;
            MyPictureBox.Location = p;
            //System.Threading.Thread.Sleep(3);
            return location >= racetracklenght;

        }

       public void volteparaocomeco()
        {
            Point p = MyPictureBox.Location;
           p.X = startinglocation;
           MyPictureBox.Location = p;
           location = startinglocation;

        }
    }
}

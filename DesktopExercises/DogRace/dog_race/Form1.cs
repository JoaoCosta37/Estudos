using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Cara[] caras= new Cara[3];
        Cao[] caes = new Cao[4];


        public Form1()
        {
            InitializeComponent();
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            Cao.startinglocation = 12;
            Cao.racetracklenght = pcbpista.Size.Width -76;
            caes[0] = new Cao(pcbcao1);
            caes[1] = new Cao(pcbcao2);
            caes[2] = new Cao(pcbcao3);
            caes[3] = new Cao(pcbcao4);
            caras[0] = new Cara("João",rbjoao,lbjoao,50);
            caras[1] = new Cara("Beto", rbbeto, lbbeto,75);
            caras[2] = new Cara("Alfredo", rbalfredo, lbalfredo,45);

            foreach (Cara c in caras)
            {
                c.UpdateLabels();
            }



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool vit=false;
            

            while (!vit)
            {
                pcbpista.Refresh();

                for (int i = 0; i <= 3 & !vit; i++)
                {
                    vit = corre(i);
                }

                for (int i = 3; i >= 0 & !vit; i--)
                {
                    vit = corre(i);

                }

            }
            


        }

        bool corre(int i)
        {

            bool vit;

            vit = caes[i].run();


            if (vit)
            {

                MessageBox.Show("Cão " + (i + 1) + " venceu!");

                for (int j = 0; j <= 3; j++)
                {
                    caes[j].volteparaocomeco();
                }

                foreach (Cara c in caras)
                {
                    c.Collect(i+1);
                }
            }

            return vit;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Cara c in caras)
            {
                if (c.MyRadioButton.Checked & c.minhaaposta.dog==0)
                    if (!c.apostar((int)nvalor.Value, (int)ncao.Value))
                       MessageBox.Show(c.Name + " não tem dinheiro suficiente para apostar!", "Dog Race");

                   
                       

            }


              
        }

    }
}

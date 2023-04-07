using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    class Cara
    {
       public string Name;
       public Aposta minhaaposta;
       public int dinheiro;
       public RadioButton MyRadioButton;
       public Label MyLabel;


       public Cara(string Name,RadioButton MyRadioButton,Label MyLabel,int dinheiro)
       {
           this.Name = Name;
           this.MyRadioButton = MyRadioButton;
           this.MyLabel = MyLabel;
           this.dinheiro = dinheiro;
           minhaaposta = new Aposta(0, 0, this);
       }

      public  void UpdateLabels()
        {
          
            MyLabel.Text = minhaaposta.GetDescription();
            MyRadioButton.Text = Name + " tem " + dinheiro + " reais";
        }

      public void clearbeat()
        {
          minhaaposta = new Aposta(0,0,this);
         

        }

      public bool apostar(int quant, int dog)
        {
            if (quant >= dinheiro)
                return false;
            else
                minhaaposta = new Aposta(quant,dog,this);
            UpdateLabels();

            return true;
          

        }

    
      public void Collect(int Winner)
        {
            dinheiro += minhaaposta.PayOut(Winner);
            clearbeat(); 
          UpdateLabels();
           
        }

    }
}

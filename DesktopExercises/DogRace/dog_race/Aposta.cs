using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Aposta
    {
      public  int quant;
      public int dog;
      public Cara apostador;

        public Aposta(int quant,int dog,Cara apostador)
        {
            this.quant = quant;
            this.dog = dog;
            this.apostador = apostador;
        }

        public string GetDescription()
        {
          return   quant>0 ? apostador.Name + " apostou " + quant + " no cão " + dog : apostador.Name + " não apostou!";
        }

        public int PayOut(int Winner)
        {
            return Winner == dog ? quant : -quant;

        }
    }
}

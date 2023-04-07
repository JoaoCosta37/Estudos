using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Equipamentos
{
    public class Equipamento
    {
        //public bool Ligado { get; set; } = true;

        // lambdas

        bool ligado;

        public bool Ligado
        {
            get => ligado;
            set => ligado = value;
        }



        public Equipamento()
        {
            this.Ligado = true;
        }
        public virtual void TurnOn()
        {
            Ligado = true;
        }
      
        public void TurnOff()
        {
            Ligado = false;
        }           
    }
}

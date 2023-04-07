using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Transportes
{
    public class Transporte
    {
        public bool ligado;

        int velocidade;

        public virtual int Velocidade
        {
            get
            {
                return velocidade;
            }
            set
            {
                if (value >= 0)
                    velocidade = value;
            }
        }

        public void liga()
        {
            this.ligado = true;
        }public void desliga()
        {
            this.ligado = false;
            this.velocidade = 0;
        }
    }
}

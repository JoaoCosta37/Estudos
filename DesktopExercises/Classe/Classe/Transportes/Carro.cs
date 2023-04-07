using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Transportes
{
    public class Carro : Transporte
    {
        // int quilometragem;

        //public void SetQuilometragem(int quilometragem)
        //{
        //    this.quilometragem = quilometragem;
        //}

        private int quilometragem;
        public int Quilometragem

        {
            get
            {
                return quilometragem;
            }
            set
            {
                if (value >= 0 && value <= 999999)
                    quilometragem = value;
            }
        }
        public override int Velocidade
        {
            get
            {
                return base.Velocidade;
            }
            set
            {
                if (value >= 0 && value <= 200)
                    base.Velocidade = value;
            }
        }

    }
}

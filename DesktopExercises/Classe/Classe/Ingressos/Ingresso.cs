using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Ingressos
{
    public class Ingresso : Object
    {
        public decimal Valor { get; set; }

        // Object

        public virtual decimal GetValorTotalComDesconto(decimal percentualDesconto)
        {
            return Valor - (Valor * percentualDesconto / 100);
        }

        public override string ToString()
        {
            return $"Valor do ingresso:{Valor}";
        }

    }
}

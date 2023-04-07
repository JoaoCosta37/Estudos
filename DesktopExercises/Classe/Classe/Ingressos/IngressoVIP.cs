using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.Ingressos
{
    public class IngressoVIP : Ingresso
    {
        //private decimal valorAdicional;

        //public decimal ValorAdicional
        //{
        //    get
        //    {
        //        return valorAdicional;
        //    }
        //    set
        //    {
        //        valorAdicional = value;
        //    }
        //}
      //  public decimal ValorAdicional { get => valorAdicional; set => valorAdicional = value; }

        public decimal ValorAdicional { get; set; }
        public override string ToString()
        {
            // return $"Valor do ingresso:{Valor + ValorAdicional}";

            return base.ToString() + $" Valor adicional:{ValorAdicional}";
        }

        public override decimal GetValorTotalComDesconto(decimal percentualDesconto)
        {
            var valorBase = base.GetValorTotalComDesconto(percentualDesconto);

            var valorAdicionalDesconto = ValorAdicional - (ValorAdicional * percentualDesconto / 100);

            return valorBase + valorAdicionalDesconto;
        }

    }
}

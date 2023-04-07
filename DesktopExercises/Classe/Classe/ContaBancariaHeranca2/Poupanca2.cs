using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ContaBancariaHeranca2
{
    public class Poupanca2 : Conta2
    {
        public float variacao { get; set; }

        Poupanca2(float variacao, float saldo) : base(saldo)
        {
            this.variacao = variacao;
        }
        public float CalculaRendimento()
        {
            return Saldo * variacao;
        }
    }
}

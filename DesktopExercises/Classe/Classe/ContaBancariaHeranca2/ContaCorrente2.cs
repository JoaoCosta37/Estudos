using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ContaBancariaHeranca2
{
    public class ContaCorrente2 : Conta2
    {
        public float taxaTransacao { get; set; }

        public ContaCorrente2(float taxaTransacao, float saldo) :base(saldo)
        {
            this.taxaTransacao = taxaTransacao;   
        }
        public override bool credito(float valor)
        {
            if (base.credito(valor))
            {
                Saldo -= taxaTransacao;
                return true;
            }
            return false;

        }
        public override bool debito(float valor)
        {
            if (base.debito(valor))
            {
                Saldo -= taxaTransacao;
                return true;
            }
            return false;
        }
    }
}

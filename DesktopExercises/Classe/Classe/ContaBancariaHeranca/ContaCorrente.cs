using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ContaBancariaHeranca
{
    public class ContaCorrente
    {
        internal float saldo;
        //public ContaCorrente()
        //{

        //}
        public ContaCorrente(float saldo)
        {
            this.saldo = saldo;
        }


        public void depositar(float valor)
        {
            saldo += valor;
        }
        public virtual bool sacar(float valor)
        {
            if (saldo < valor)
                return false;
            saldo -= valor;
            return true;
        }
        public override string ToString()
        {
            return "contaCorrente";
        }
        public virtual bool transferir(float valor, ContaCorrente conta)
        {
            if (saldo < valor)
                return false;
            saldo -= valor;
            conta.saldo += valor;
            return true;
        }
    }
}

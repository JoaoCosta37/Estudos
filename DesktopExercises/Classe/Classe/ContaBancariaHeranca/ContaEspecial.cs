using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ContaBancariaHeranca
{
    public class ContaEspecial : ContaCorrente
    {
        private float limite;

        public ContaEspecial(float limite, float saldo) : base(saldo)
        {
            this.limite = limite;
        }
        public override bool sacar(float valor)
        {
            if (Math.Abs(saldo - valor) < limite)
                return false;
            saldo -= valor;
            return true;
        }

        

        public override bool transferir(float valor, ContaCorrente conta)
        {
            if (Math.Abs(saldo - valor) < limite)
                return false;
            saldo -= valor;
            conta.saldo += valor;
            return true;
        }

        //public override bool tranferir(float valor)
        //{
        //    if (Math.Abs((saldo - valor)) < limite)
        //        return false;
        //    saldo -= valor;
        //    return true;
        //}
        //public 
    }
}

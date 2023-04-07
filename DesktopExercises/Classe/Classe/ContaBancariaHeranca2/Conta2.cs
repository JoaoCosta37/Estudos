using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ContaBancariaHeranca2
{
    public class Conta2
    {
        public float Saldo { get; set; }
        public Conta2(float valor)
        {
            this.Saldo = valor;
        }
        public string  mostrarSaldo()
        {
            return $"O saldo é de: {Saldo}";
        }
        public virtual bool credito(float valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                return true;
            }

            return false;
        }
        public virtual bool debito(float valor)
        {
            if(Saldo >= valor)
            {
                Saldo -= valor;
                return true;
            }
            return false;
        }

    }
}

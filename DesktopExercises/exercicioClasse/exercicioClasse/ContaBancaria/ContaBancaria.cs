using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioClasse
{
    public class ContaBancaria
    {
        private double saldo;
        private DateTime dataAbertura;
        
        public ContaBancaria()
        {
            this.saldo = 0.0;
            this.dataAbertura = DateTime.Now;
        }
        //{
        //    get
        //    {
        //        return DateTime.Now;
        //    }
        //}
        public double Saldo
        {
            get {
                return this.saldo;
            }
            set
            {
                saldo = value;
            }
        }
        public DateTime DataAbertura
        {
            get
            {
                return dataAbertura;
            }
        }

        public String getDataAberturaFormatada()
        {
            //   return $"{dataAbertura.Day}/{dataAbertura.Month}/{dataAbertura.Year}";

            return dataAbertura.ToString("yyyy/MM/dd");
        }
        public string getSaldoFormatado()
        {
            return $" R$ {saldo:C}";
        }
        public double depositar(double valorDeposito)
        {
            return this.saldo += valorDeposito;
        }
        public double sacar(double valorSaque)
        {
            if (valorSaque > saldo)
            {
                //  Console.WriteLine("Valor solicitado é maior que saldo em conta. Insira um valor disponível em conta");
                throw new Exception("Valor solicitado é maior que saldo em conta");
                return 0;
            }
            else
            {
                return saldo -= valorSaque;
            }
        }
    }
}

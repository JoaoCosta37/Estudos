using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ContaBancaria
{
    public class ContaCorrente
    {
        public int numero;
        public decimal saldo;
        public bool statusEspecial;
        public decimal limite;
        public List<Movimentacao> movimentacoes;

        public ContaCorrente()
        {
            this.movimentacoes = new List<Movimentacao>();
        }

        public void sacar(decimal valor)
        {
            Movimentacao debito = new Movimentacao();
            debito.descricao = "Saque";
            debito.tipo = 'D';
            debito.valor = valor;

            this.movimentacoes.Add(debito);

            this.saldo -= valor;
        }
        public void depositar(decimal valor)
        {
            Movimentacao credito = new Movimentacao();
            credito.descricao = "Depositar";
            credito.tipo = 'C';
            credito.valor = valor;

            this.movimentacoes.Add(credito);
            this.saldo += valor;
        }
    }
}

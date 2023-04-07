using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioClasse.Supermercado
{
    public class Pedido
    {
        public List<Item> Itens;
        public int formaPagamento;

        public Pedido()
        {
            this.Itens = new List<Item>();
        }

        public decimal ValorTotal()
        {
            decimal Total = 0;
            for(int i = 0; i <  Itens.Count; i++)
            {
                Total += (Itens[i].Produto.Preco*Itens[i].QuantidadeProduto);
            }
            return Total;

           
        }

    }
}

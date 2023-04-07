using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ProdutoReal
{
    public class Produto
    {
        //atributos

        private string nome;
        private double precoCusto;
        private double precoVenda;
        //private double margemLucro;

        // atrinutos - métodos
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }
        public double PrecoCusto
        {
            get
            {
                return precoCusto;
            }
            set
            {
                precoCusto = value;
            }
        }
        public double PrecoVenda
        {
            get
            {
                return precoVenda;
            }
            set
            {
                if (value < precoCusto)
                    precoVenda = precoCusto;
                else
                    precoVenda = value;
            }
        }

        public double MargemLucro
        {
            get
            {
                return precoVenda - precoCusto;
            }
        }

        // métodos

        //public string calcularMargemLucro()
        //{
        //    margemLucro = precoVenda - precoCusto;
        //    return $"{margemLucro:C2}";
        //}
        //public string calcularMargemLucroPorcentual()
        //{
        //    margemLucro = ((precoVenda * 100) / precoCusto) - 100;
        //    return $"{margemLucro}%";
        //}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ContaBancaria
{
    public class Banco
    {
        public int codigo;
        public string descricao;
        public List<ContaCorrente> contas;

        public Banco()
        {
            this.contas = new List<ContaCorrente>();
        }
    }
}

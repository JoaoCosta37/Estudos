using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    public class Funcionario
    {
        public int idade;
        public char sexo;
        public decimal salario;

        public Data dataAdmissao;


        public Funcionario()
        {

        }

        public void aumentaSalario(int valorDoAumento)
        {
            salario += valorDoAumento;
        }
    }
}

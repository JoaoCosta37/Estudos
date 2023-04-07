using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEstagiario
{
    public class Aluno
    {
        public string nome;
        public sbyte quantidadeProbelmasResolvidos;

        public Aluno(string dadosAluno)
        {
            var elementosLinha = dadosAluno.Split(' ');
            const int limiteCaracteres = 20;

            if (elementosLinha[0].Length > limiteCaracteres)
                this.nome = elementosLinha[0].Substring(0, limiteCaracteres);
            else
                this.nome = elementosLinha[0];

            this.quantidadeProbelmasResolvidos = Convert.ToSByte(elementosLinha[1]);
        }
    }
}

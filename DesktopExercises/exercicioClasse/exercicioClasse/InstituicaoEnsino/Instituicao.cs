using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioClasse.InstituicaoEnsino
{
    public class Instituicao
    {
        private int id;
        public string nome;
        public Endereco endereco;
        public List<Departamento> departamentos;

        public Instituicao()
        {
            this.departamentos = new List<Departamento>();
        }
    }
}

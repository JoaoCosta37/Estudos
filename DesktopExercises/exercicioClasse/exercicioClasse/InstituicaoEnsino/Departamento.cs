using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioClasse.InstituicaoEnsino
{
    public class Departamento
    {
        static int ultimoId = 0;

        //private int id;

        ////GET
        //public int GetId()
        //{
        //    return id;
        //}

        ////SET
        //public void SetId(int id)
        //{


        //    this.id = id;
        //}

        int id;
        public int Id
        {
             get {
                return id;
            }

           private  set
            {
                if (id < 0)
                    id = id *  - 1;
                id = value;
            }
        }

        public string nome;
        private List<Curso> cursos;

        public void AdicionarCurso(Curso c)
        {
            this.cursos.Add(c);
        }

        public Departamento()
        {
            this.id = ultimoId++;
            this.cursos = new List<Curso>();
        }
    }
}

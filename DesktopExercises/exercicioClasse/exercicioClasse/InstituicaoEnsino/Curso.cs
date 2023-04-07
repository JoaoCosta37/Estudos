using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioClasse.InstituicaoEnsino
{
    public class Curso
    {
        public string nome;
        public string periodo;
        public List<Disciplina> disciplinas;

        public Curso()
        {
            this.disciplinas = new List<Disciplina>(); 
        }

        public decimal getCargaHoraria()
        {
            decimal somaCargaHoraria = 0;
            foreach (Disciplina d in disciplinas)
            {
                somaCargaHoraria += d.cargaHoraria;
            }

            return somaCargaHoraria;

            //LINQ

           // decimal carga = (from Disciplina d in disciplinas select d.cargaHoraria).Sum();

            //for (int i = 0; i<= disciplinas.Count; i++)
            //{
            //    somaCargaHoraria += disciplinas[i].cargaHoraria;
            //}
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioClasse.FormasGeometricas
{
    public class Quadrado
    {
        public int lado;

        public Quadrado(int lado)
        {
            this.lado = lado;
        }
        
        public int calculoArea()
        {
            int area = lado * lado;
            return area;
        }
        public int calculoPerimetro()
        {
            int perimetro = lado * 4;
            return perimetro;
        }
    }
    

}

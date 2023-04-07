using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.FormarGeometricas2
{
    public class FiguraGeometrica
    {
        public decimal lado { get; set; }
        public decimal altura { get; set; }

        string cor;

        //arrow function
       // public string Cor { get => cor.ToUpper(); set => cor = value.Trim(); }

       

        //public string Cor
        //{
        //    get
        //    {
        //        return cor.ToUpper();
        //    }
        //    set
        //    {
        //        cor = value;
        //    }
        //}

        public bool filles { get; set; }

        public virtual decimal CalcularArea()
        {
            return lado * altura;
        }

        public virtual decimal CalcularArea(int adicional)
        {
            return (lado * altura) + adicional;
        }

        //TimeSpan 

        public virtual decimal CalcularPerimetro()
        {
            return lado + lado + altura + altura;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.FormasGeometricas
{
    public class Quadrado : FormaGeometrica
    {
        public int Lado { get; set; }
        public int CalculaArea()
        {
            return Lado * Lado;
        }
    }
}

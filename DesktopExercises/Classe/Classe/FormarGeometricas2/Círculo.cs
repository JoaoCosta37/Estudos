using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.FormarGeometricas2
{
    public class Círculo : FiguraGeometrica
    {
        public decimal raio { get; set; }

        public override decimal CalcularArea()
        {
            return 3.1415m * (raio * raio);
        }
        public override decimal CalcularPerimetro()
        {
            return 6.283m * raio;
        }
    }
}

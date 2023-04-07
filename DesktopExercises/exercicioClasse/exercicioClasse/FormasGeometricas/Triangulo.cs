using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioClasse
{
    public class Triangulo
    {
        private decimal lado1;
        private decimal lado2;
        private decimal lado3;

        public decimal Lado1
        {
            get
            {
                return lado1;
            }
        }

        public Triangulo(int l1, int l2, int l3)
        {
            this.lado1 = l1;
            this.lado2 = l2;
            this.lado3 = l3;
        }

        public bool IsEscaleno()
        {
            //if (lado1 != lado2 && lado1 != lado3 && lado2 != lado3)
            //    return true;
            //else
            //    return false;

            return (lado1 != lado2 && lado1 != lado3 && lado2 != lado3);
        }
        public bool IsIsoceles()
        {
            //if 
            //    return true;
            //else
            //    return false;

            return (lado1 == lado2 && lado1 != lado3 || lado1 == lado3 && lado1 != lado2 || lado2 == lado3 && lado2 != lado1);
        }
        public bool IsEquilatero()
        {
            if (lado1 != lado2 && lado1 != lado3 && lado2 != lado3)
                return true;
            else
                return false;
        }
    }
}

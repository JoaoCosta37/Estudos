using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicioClasse
{
    public class Teste
    {
        private int velMax;

        public int vm
        {
            get//leitura//
            {
                /*obter valor da variável*/
                return velMax;
            }
            set//escrita//
            {
                /*atribuir valor da variável*/ 
                if(value < 0)
                {
                    velMax = 0;
                }
                else if (value > 300)
                {
                    velMax = 300;
                }
                else
                {
                    velMax = value;
                }
            } 
        }
        public Teste()
        {
            this.vm = 120;
        }
    }
    
}

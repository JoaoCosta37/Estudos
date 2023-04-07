using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio
{
    public class Data
    {
        public int dia;
        public int mes;
        public int ano;

        public Data(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }
 
        public string FormatoDDMMAAAA()
        {
            return $"{dia}/{mes}/{ano}";
        }
        //public string FormatoDDMESAAAA()
        //{
        //    if ()
        //    return $"{dia}/{}"
        //}
    }
}

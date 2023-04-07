using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe
{
    public class Data
    {
        public sbyte dia = 8;
        public sbyte mes = 3;
        public int ano = 5;

        public Data(sbyte dia, sbyte mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }
        public string FormatoDDMMAAAA()
        {
            return $"{dia}/{mes}/{ano}";
        }
        public string FormatoAAAAMMDD()
        {
            return $"{ano}/{mes}/{dia}";
        }
        public string FormatoDDMESAAAA()
        {
            string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

            string mesEscrito = meses[mes - 1];
            return $"{dia}/{mesEscrito}/{ano}";
        }
        public string Semestre()
        {
            //if (mes <= 6)
            //    mes = 1;
            //else
            //    mes = 2;

            mes = mes <= 6 ? (sbyte) 1 : (sbyte) 2;
            return $"{mes}/{ano}";
        }

    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ContaBancariaHeranca
{
    public class Cliente
    {
        public  string Nome { get; set; }

        public Cliente()
        {

        }
        public Cliente(string nome)
        {
            Nome = nome;
        }

        //public string Nome
        //{
        //    get
        //    {
        //        return nome;
        //    }
        //    set
        //    {
        //        nome = value;
        //    }
        //}
        public override string ToString()
        {
            return $"Olá, {Nome}!";
            //return base.ToString() + "Hello Word";
        }

    }
}

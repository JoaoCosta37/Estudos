using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classe.ContaBancaria
{
    public abstract class Pessoa
    {

        //public string _nome;

        //public string Nome
        //{ get
        //    {
        //        return _nome;
        //    }
        //    set
        //    {
        //        _nome = value;
        //    }
        //}
     public string Nome { get; set; }
     public string Endereco { get; set; }
    
    }
}

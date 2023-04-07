using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Clientes
    {
        public int id;
        public string login;
        public string senha;
        public DateTime created;
        public DateTime modified;
        public List<Planos> planos;
        public string email;
        public Clientes()
        {
            this.planos = new List<Planos>();
        }
    }
}

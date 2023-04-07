using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Artistas
    {
        public int id;
        public string nome;
        public DateTime created;
        public DateTime modified;
        public List<Gravadoras> gravadoras;

        public Artistas()
        {
            this.gravadoras = new List<Gravadoras>();
        }
    }
}

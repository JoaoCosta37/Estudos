using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Musicas
    {
        public int id;
        public string nome;
        public DateTime created;
        public DateTime modified;
        public TimeSpan tempoDuracao;
        public DateTime dataLancamento;
        public List<Generos> generos;

        //public List<Artistas> artistas;

        // MAPEAMENTO OBJETO-RELACIONAL   --- ORM Object relactional map  NHIBERNATE
        public Musicas()
        {
            this.generos = new List<Generos>();
        }
    }
}

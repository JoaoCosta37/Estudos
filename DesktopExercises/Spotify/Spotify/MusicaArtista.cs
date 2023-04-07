using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class MusicaArtista
    {
        public List<Musicas> musicas;
        public List<Artistas> artistas;

        public MusicaArtista()
        {
            this.musicas = new List<Musicas>();
            this.artistas = new List<Artistas>();
        }
    }
}

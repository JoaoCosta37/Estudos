using System;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Spotify();
        }
        static void Spotify()
        {
            Gravadoras acit = new Gravadoras();
            acit.id = 2;
            acit.nome = "ACIT";
            acit.valorContrato = 5000;

            Artistas manoLima = new Artistas();
            manoLima.id = 1;
            manoLima.nome = "Mano Lima";

            manoLima.gravadoras.Add(acit);

            Planos premium = new Planos();
            premium.id = 1;
            premium.descricao = "Premium";
            premium.limite = 100;
            premium.valor = 29.99m;

            Clientes joao = new Clientes();
            joao.id = 1;
            joao.login = "jcosta@";
            joao.senha = "Jv1234";

            joao.planos.Add(premium);

            Generos gaucha = new Generos();
            gaucha.id = 1;
            gaucha.descricao = "Gaúcha";

            Musicas contaProTio = new Musicas();
            contaProTio.id = 1;
            contaProTio.nome = "Conta pro tio";
            contaProTio.dataLancamento = new DateTime(2022, 3, 14);
            contaProTio.tempoDuracao = TimeSpan.FromMinutes(3);

           // new TimeSpan(0, 2, 0);

            contaProTio.generos.Add(gaucha);

            MusicaArtista primeira = new MusicaArtista();
            primeira.musicas.Add(contaProTio);
            primeira.artistas.Add(manoLima);
        }
    }
}

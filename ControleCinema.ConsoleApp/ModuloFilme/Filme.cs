using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloGenero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloFilme
{
    public class FilmeCinema : EntidadeBase
    {
        private readonly string _nomedofilme;
        private readonly string _duracao;
        

        public string Nomedofilme { get => _nomedofilme; }
        public string Duracao { get => _duracao; }

        public FilmeCinema (string nomedofilme, string duracao)
        {
            _nomedofilme = nomedofilme;
            _duracao = duracao;
            
        }

        public override string ToString()
        {
            return "duracao: " + _duracao + Environment.NewLine +
                "Nome: " + _nomedofilme + Environment.NewLine;
        }
    }
}

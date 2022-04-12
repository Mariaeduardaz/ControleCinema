using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloFilme;
using ControleCinema.ConsoleApp.ModuloSala;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSessao
{
    public class Sessao : EntidadeBase
    {
        public List<Ingresso> ingressos = new List<Ingresso>();

        public Sala sala;

        public FilmeCinema filme;

        public string LocalSala { get; set; }
        public Sessao(string localsala)
        {
            LocalSala = localsala;
            
           
        }



        public override string ToString()
        {
            return "Onde se encontra a sessão do filme?: " + id + Environment.NewLine;
               
        }
    }
}

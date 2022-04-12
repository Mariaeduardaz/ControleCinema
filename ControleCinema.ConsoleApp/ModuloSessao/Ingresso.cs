using ControleCinema.ConsoleApp.Compartilhado;
using System;

namespace ControleCinema.ConsoleApp.ModuloSessao
{
    public class Ingresso : EntidadeBase
    {
        private readonly string _poltronas;
        private readonly string _status;


        public string poltronas { get => _poltronas; }


        public Ingresso(string poltronas, string status)
        {
            _poltronas = poltronas;
            _status = status;

        }
        



        public override string ToString()
        {
            return "Quantidade de poltronas: " + id + Environment.NewLine +
                "Status: " + _status + Environment.NewLine;

           
        }
        
        
    }
}
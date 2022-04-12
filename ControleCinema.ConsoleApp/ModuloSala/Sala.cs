using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSala
{
    public class Sala : EntidadeBase
    {
        private readonly int _capacidade;
        private readonly int _numerodeassentos;
       
        

        public int capacidade { get => _capacidade; }
       

        public Sala(int capacidade, int nmrassentos)
        {
            _capacidade = capacidade;
            _numerodeassentos = nmrassentos;
           
        }

        public override string ToString()
        {
            return "Quantidade De ingressos: " + id + Environment.NewLine +
                "Numero de assentos: " + _numerodeassentos + Environment.NewLine;
        }
    }
}



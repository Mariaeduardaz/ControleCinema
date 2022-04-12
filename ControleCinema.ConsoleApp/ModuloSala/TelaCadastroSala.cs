using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSala
{
    internal class TelaCadastroSalaa
    {
        public class TelaCadastroSala : TelaBase, ITelaCadastravel
        {
            private readonly IRepositorio<Sala> _repositorioSala;
            private readonly Notificador _notificador;

            public TelaCadastroSala(IRepositorio<Sala> repositorioSala, Notificador notificador)
                : base("Cadastro de Sala")
            {
                _repositorioSala = repositorioSala;
                _notificador = notificador;
            }

            public void Inserir()
            {
                MostrarTitulo("Cadastro de Sala");

                

               

                _notificador.ApresentarMensagem("Sala cadastrada com sucesso!", TipoMensagem.Sucesso);
            }

            public void Editar()
            {
                MostrarTitulo("Editando sala");

                bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

                if (temRegistrosCadastrados == false)
                {
                    _notificador.ApresentarMensagem("Nenhuma sala cadastrada para editar.", TipoMensagem.Atencao);
                    return;
                }

                int numeroSala = ObterNumeroRegistro();


            }

            public void Excluir()
            {
                MostrarTitulo("Excluindo Sala");

                bool TemSalaRegistrada = VisualizarRegistros("Pesquisando");

                if (TemSalaRegistrada == false)
                {
                    _notificador.ApresentarMensagem("Nenhuma sala cadastrada para excluir.", TipoMensagem.Atencao);
                    return;
                }

                int numeroSala = ObterNumeroRegistro();

                bool conseguiuExcluir = _repositorioSala.Excluir(numeroSala);

                if (!conseguiuExcluir)
                    _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
                else
                    _notificador.ApresentarMensagem("Sala excluída com sucesso", TipoMensagem.Sucesso);
            }

            public bool VisualizarRegistros(string tipoVisualizacao)
            {
                if (tipoVisualizacao == "Tela")
                    MostrarTitulo("Visualização de Sala");

                List<Sala> salas = _repositorioSala.SelecionarTodos();

                if (salas.Count == 0)
                {
                    _notificador.ApresentarMensagem("Nenhuma sala disponível.", TipoMensagem.Atencao);
                    return false;
                }

                foreach (Sala genero in salas)
                    Console.WriteLine(genero.ToString());

                Console.ReadLine();

                return true;
            }

            

         
            private static Sala NewMethod(int capacidade, int nmrassentos)
            {
                return new Sala(capacidade, nmrassentos) ;
            }

            public int ObterNumeroRegistro()
            {
                int numeroRegistro;
                bool numeroRegistroEncontrado;

                do
                {
                    Console.Write("Digite o nome da sala que deseja editar: ");
                    numeroRegistro = Convert.ToInt32(Console.ReadLine());

                    numeroRegistroEncontrado = _repositorioSala.ExisteRegistro(numeroRegistro);

                    if (numeroRegistroEncontrado == false)
                        _notificador.ApresentarMensagem("nome da sala  não foi encontrado, digite novamente", TipoMensagem.Atencao);

                } while (numeroRegistroEncontrado == false);

                return numeroRegistro;
            }
        }
    }
}

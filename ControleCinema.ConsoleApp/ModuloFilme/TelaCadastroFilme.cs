using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloGenero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloFilme
{

    public class TelaCadastroFilme : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<FilmeCinema> _repositorioFilmeCinema;
        private Notificador _notificador;
        public Genero _genero;
        public TelaCadastroFilme(IRepositorio<FilmeCinema> repositorioFilmeCinema, Notificador notificadorfilme, Genero genero)
            : base("Cadastro de Filmes")
        {
            _repositorioFilmeCinema = repositorioFilmeCinema;
            _notificador = notificadorfilme;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Funcionário");

            FilmeCinema novoFuncionrio = ObterFilmeCinema();

            _repositorioFilmeCinema.Inserir(novoFuncionrio);

            _notificador.ApresentarMensagem("Funcionário cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {

            MostrarTitulo("Editando Filme Cinema");

            bool temFilmeCinemasCadastrados = VisualizarRegistros("Pesquisando");

            if (temFilmeCinemasCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum filme para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroFilmeCinema = ObterNumeroRegistro();

            FilmeCinema funcionarioAtualizado = ObterFilmeCinema();

            bool conseguiuEditar = _repositorioFilmeCinema.Editar(numeroFilmeCinema, funcionarioAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Filme editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Filme");

            bool temFilmeCinemasRegistrados = VisualizarRegistros("Pesquisando");

            if (temFilmeCinemasRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum filme cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroFilmeCinema = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioFilmeCinema.Excluir(numeroFilmeCinema);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Filme excluído com sucesso1", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Filmes");

            List<FilmeCinema> funcionarios = _repositorioFilmeCinema.SelecionarTodos();

            if (funcionarios.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum filme disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (FilmeCinema funcionario in funcionarios)
                Console.WriteLine(funcionario.ToString());

            Console.ReadLine();

            return true;
        }

        private FilmeCinema ObterFilmeCinema()
        {
            Console.Write("Digite o nome do filme: ");
            string nomedofilme = Console.ReadLine();

            Console.Write("Nossa duração é ");
            string duracao = Console.ReadLine();

        


            return new FilmeCinema(nomedofilme, duracao);

        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o nome do filme  que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioFilmeCinema.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("o filme não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
 }  }  

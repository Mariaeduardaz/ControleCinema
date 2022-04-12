using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSessao
{
    internal class TelaCadastroSessao 
    {
        public class TelaCadastroSessaoo
        {
            private readonly IRepositorio<Sessao> _repositorioSessao;
            private readonly Notificador _notificador;

            public class TelaCadastroSessao : TelaBase, ITelaCadastravel
            {
                private readonly IRepositorio<Sessao> _repositorioSessao;
                private readonly Notificador _notificador;
                private RepositorioSessao repositorioSessao;
                private Notificador notificador;

                public TelaCadastroSessao(IRepositorio<Sessao> repositorioSessao, Notificador notificador)
                    : base("Cadastro de sessao")
                {
                    _repositorioSessao = repositorioSessao;
                    _notificador = notificador;
                }



                public void Inserir()
                {
                    MostrarSessao("Cadastro de sessao");

                    Sessao novaSessao = ObterSessao();

                    _repositorioSessao.Inserir(novaSessao);

                    _notificador.ApresentarMensagem("Sua Sessao foi cadastrada com sucesso!", TipoMensagem.Sucesso);
                }

                private void MostrarSessao(string v)
                {
                    throw new NotImplementedException();
                }

                public void EditarSessao()
                {
                    MostrarSessao("Editando Sessao");

                    bool temSessaoCadastradas = VisualizarRegistros("Pesquisando");

                    if (temSessaoCadastradas == false)
                    {
                        _notificador.ApresentarMensagem("Nenhuma sessao cadastrada para editar.", TipoMensagem.Atencao);
                        return;
                    }

                    int numeroSessao = ObterNumeroRegistro();

                    Sessao sessaoAtualizada = ObterSessao();

                    bool conseguiuEditar = _repositorioSessao.Editar(numeroSessao, sessaoAtualizada);

                    if (!conseguiuEditar)
                        _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
                    else
                        _notificador.ApresentarMensagem("Sessao editado com sucesso!", TipoMensagem.Sucesso);
                }

                public void ExcluirSessao()
                {
                    MostrarSessao("Excluindo SalaSessao");

                    bool temSessaoRegistrada = VisualizarRegistros("Pesquisando");

                    if (temSessaoRegistrada == false)
                    {
                        _notificador.ApresentarMensagem("Nenhuma sessao cadastrado para excluir.", TipoMensagem.Atencao);
                        return;
                    }

                    int numeroSessao = ObterNumeroRegistro();

                    bool conseguiuExcluir = _repositorioSessao.Excluir(numeroSessao);

                    if (!conseguiuExcluir)
                        _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
                    else
                        _notificador.ApresentarMensagem("Sessao excluída com sucesso", TipoMensagem.Sucesso);
                }

                public bool VisualizarRegistros(string tipoVisualizacao)
                {
                    if (tipoVisualizacao == "Tela")
                        MostrarSessao("Visualização de Sessões");

                    List<Sessao> sessao = _repositorioSessao.SelecionarTodos();

                    if (sessao.Count == 0)
                    {
                        _notificador.ApresentarMensagem("Nenhuma sessao disponível.", TipoMensagem.Atencao);
                        return false;
                    }

                    foreach (Sessao sessao1 in sessao)
                        Console.WriteLine(sessao.ToString());

                    Console.ReadLine();

                    return true;
                }

                private Sessao ObterSessao()
                {
                    Console.Write("Digite o numero da sessao: ");
                    string localsala = Console.ReadLine();



                    return new Sessao(localsala);
                }

                public int ObterNumeroRegistro()
                {
                    int numeroRegistro;
                    bool numeroRegistroEncontrado;

                    do
                    {
                        Console.Write("Digite o numero da sessao que deseja editar: ");
                        numeroRegistro = Convert.ToInt32(Console.ReadLine());

                        numeroRegistroEncontrado = _repositorioSessao.ExisteRegistro(numeroRegistro);

                        if (numeroRegistroEncontrado == false)
                            _notificador.ApresentarMensagem("O numero da sessao não foi encontrado, digite novamente", TipoMensagem.Atencao);

                    } while (numeroRegistroEncontrado == false);

                    return numeroRegistro;
                }

                public void Vender()
                {
                    Console.WriteLine("Digite quantos ingressos deseja vender ");
                    string numerodosIngresos = Console.ReadLine();

                    Console.WriteLine("Digite quais poltronas deseja comprar: ");
                    string poltronas = Console.ReadLine();

                }

                public void Editar()
                {
                    throw new NotImplementedException();
                }

                public void Excluir()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }

}


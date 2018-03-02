using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
using exemploApp.Dominio.Interfaces.Servicos.Padrao;
using exemploApp.Dominio.Validacoes.ControleSistema;
using exemploApp.Dominio.Validacoes.Padrao;
using System;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Helpers;
using Tykon.Base.Servicos;
using Tykon.Base.Validacoes;

namespace exemploApp.Servico.ControleSistema
{
    /// <summary>
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoUsuarioSistema"/>.
    /// </summary>
    public class ServicoUsuarioSistema : Servico<UsuarioSistema>, IServicoUsuarioSistema
    {
        /// <summary>
        /// O repositório de UsuarioSistema.
        /// </summary>
        private IRepositorioUsuarioSistema repositorioUsuarioSistema;

        /// <summary>
        /// The repositorio credencial acesso
        /// </summary>
        private IRepositorioCredencialAcesso repositorioCredencialAcesso;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoUsuarioSistema"/>.
        /// </summary>
        /// <param name="repositorioUsuarioSistema">O repositório de UsuarioSistema.</param>
        /// <param name="repositorioCredencialAcesso">The repositorio credencial acesso.</param>        
        /// <param name="fabrica">A fabrica.</param>
        public ServicoUsuarioSistema(IRepositorioUsuarioSistema repositorioUsuarioSistema, IRepositorioCredencialAcesso repositorioCredencialAcesso, IFabrica fabrica)
            : base(repositorioUsuarioSistema, fabrica)
        {
            this.repositorioUsuarioSistema = repositorioUsuarioSistema;
            this.repositorioCredencialAcesso = repositorioCredencialAcesso;
        }

        /// <summary>
        /// Indica a validação para o UsuarioSistema.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<UsuarioSistema> Validador
        {
            get
            {
                return new ValidacaoUsuarioSistema(this.repositorioUsuarioSistema);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public UsuarioSistema ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioUsuarioSistema;
            return repositorio.Consultar(id);
        }

        /// <summary>
        /// Consultars the usuario por login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="pontuacaoUsuarioLogado">A pontuacao do usuario logado.</param>
        /// <returns>
        /// O Usuário dono do login.
        /// </returns>
        public UsuarioSistema ConsultarUsuarioPorLoginOuCpf(string login, int pontuacaoUsuarioLogado)
        {
            var repositorio = this.Repositorio as IRepositorioUsuarioSistema;
            var usuarioRetornadoBD = repositorio.ConsultarUsuarioPorLoginOuCpf(login);
            UsuarioSistema usuarioProcessado = new UsuarioSistema();

            if (usuarioRetornadoBD != null)
            {
                var perfisDoUsuario = usuarioRetornadoBD.PerfisAssociadosAoUsuario.Select(x => x.Perfil);
                int maximaPontuacaoUsuario = perfisDoUsuario.Any() ? perfisDoUsuario.Max(x => x.Pontuacao) : 0;

                usuarioRetornadoBD.Pontuacao = perfisDoUsuario.Any() ? perfisDoUsuario.Max(x => x.Pontuacao) : 0;

                if (usuarioRetornadoBD.Pontuacao <= pontuacaoUsuarioLogado)
                {
                    usuarioProcessado = usuarioRetornadoBD;
                }
                else
                {
                    usuarioProcessado = null;
                }

                return usuarioProcessado;
            }
            else
            {
                return usuarioRetornadoBD;
            }
        }

        /// <summary>
        /// Consultars the usuario por login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>
        /// O Usuário dono do login.
        /// </returns>
        public UsuarioSistema ConsultarUsuarioPorLoginOuCpf(string login)
        {
            var repositorio = this.Repositorio as IRepositorioUsuarioSistema;
            return repositorio.ConsultarUsuarioPorLoginOuCpf(login);
        }

        /////// <summary>
        /////// Lista os status de contrato por Nome.
        /////// </summary>
        /////// <param name="nomeItem">Nome ou parte do nome do indicador.</param>        
        /////// <returns>Lista com os status mediante filtro.</returns>
        ////public List<UsuarioSistema> ListarUsuarioPorNome(string nomeItem)
        ////{
        ////    var repositorio = this.Repositorio as IRepositorioUsuarioSistema;
        ////    return repositorio.ListarUsuarioPorNome(nomeItem);
        ////}

        /// <summary>
        /// Lista os status de contrato por Nome.
        /// </summary>
        /// <param name="nomeItem">Nome ou parte do nome do indicador.</param>
        /// <param name="pontuacaoUsuarioLogado">A pontuacao do usuario logado.</param>
        /// <returns>Lista com os status mediante filtro.</returns>
        public List<UsuarioSistema> ListarUsuarioPorNome(string nomeItem, int pontuacaoUsuarioLogado)
        {
            var repositorio = this.Repositorio as IRepositorioUsuarioSistema;
            var listagemRetornadaBD = repositorio.ListarUsuarioPorNome(nomeItem);
            List<UsuarioSistema> listagemProcessada = new List<UsuarioSistema>();
            IEnumerable<Perfil> perfisDoUsuario;

            foreach (var usuario in listagemRetornadaBD)
            {
                perfisDoUsuario = usuario.PerfisAssociadosAoUsuario.Select(x => x.Perfil);
                usuario.Pontuacao = perfisDoUsuario.Any() ? perfisDoUsuario.Max(x => x.Pontuacao) : 0;

                if (usuario.Pontuacao <= pontuacaoUsuarioLogado)
                {
                    listagemProcessada.Add(usuario);
                }
            }

            return listagemProcessada;
        }

        /// <summary>
        /// Lista os status de contrato por Nome.
        /// </summary>
        /// <param name="nomeItem">Nome ou parte do nome do indicador.</param>
        /// <returns>Lista com os status mediante filtro.</returns>
        public List<UsuarioSistema> ListarUsuarioPorNome(string nomeItem)
        {
            var repositorio = this.Repositorio as IRepositorioUsuarioSistema;
            return repositorio.ListarUsuarioPorNome(nomeItem);
        }

        /// <summary>
        /// Consultars the usuario por cpf.
        /// </summary>
        /// <param name="cpf">The login.</param>
        /// <returns>
        /// O Usuário dono do pessoa fisica.
        /// </returns>
        public UsuarioSistema ConsultarUsuarioPorCpf(string cpf)
        {
            var repositorio = this.Repositorio as IRepositorioUsuarioSistema;
            return repositorio.ConsultarUsuarioPorCpf(cpf);
        }

        /// <summary>
        /// Consultars the usuario por login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>
        /// O Usuário dono do login.
        /// </returns>
        public UsuarioSistema ConsultarUsuarioPorLogin(string login)
        {
            var repositorio = this.Repositorio as IRepositorioUsuarioSistema;
            return repositorio.ConsultarUsuarioPorLogin(login);
        }

        /// <summary>
        /// Salvars the informacoes pessoais usuario.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        public void SalvarInformacoesPessoaisUsuario(UsuarioSistema usuario)
        {
            var repositorioUsuarioSistema = this.Repositorio as IRepositorioUsuarioSistema;
            ValidacaoUsuarioSistema validador = new ValidacaoUsuarioSistema(repositorioUsuarioSistema);
            var resultadoValidacao = validador.ValidadorAlteracaoDadosPessoaisUsuario().Validar(usuario);
            this.GarantirValidacao(resultadoValidacao);

            CredencialAcesso credAnteriorBD = this.repositorioCredencialAcesso.Consultar(usuario.Credenciais.Where(x => x.StatusCredencial == EnumSituacao.ATIVO).FirstOrDefault().Id);
            CredencialAcesso novaCredencial = new CredencialAcesso { DtStatusCredencial = DateTime.Now, LembreteSenha = "Nenhum", Senha = usuario.NovaSenha, StatusCredencial = EnumSituacao.ATIVO, UsuarioSistema = usuario };
            credAnteriorBD.StatusCredencial = EnumSituacao.INATIVO;
            this.repositorioCredencialAcesso.Atualizar(credAnteriorBD);
            this.repositorioCredencialAcesso.Adicionar(novaCredencial);
        }
    }
}

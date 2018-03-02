using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Entidades;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Repositorios.ControleSistema
{
    /// <summary>
    /// Classe responsável pela manipulação da entidade <see cref="RepositorioUsuarioSistema"/>.
    /// </summary>
    public class RepositorioUsuarioSistema : RepositorioId<UsuarioSistema>, IRepositorioUsuarioSistema
    {
        #region Construtores

        /// <summary>
        /// Cria uma instância de <see cref="RepositorioUsuarioSistema"/>.
        /// </summary>
        /// <param name="sessao">O objeto sessão.</param>
        /// <param name="usuario">O usuario.</param>
        public RepositorioUsuarioSistema(ISession sessao, IUsuarioLogado usuario)
            : base(sessao)
        {
            this.Usuario = usuario;
        }

        #endregion

        /// <summary>
        /// Consultars the usuario por login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>
        /// O Usuário dono do login.
        /// </returns>
        public UsuarioSistema ConsultarUsuarioPorLoginOuCpf(string login)
        {
            var sessao = this.Sessao;

            long loginCPF;
            long.TryParse(login.Replace(".", string.Empty).Replace("-", string.Empty), out loginCPF);

            UsuarioSistema usu = null;
            PessoaFisica pfis = null;
            var query = sessao.QueryOver<UsuarioSistema>(() => usu)
                .Inner.JoinAlias(() => usu.PessoaFisica, () => pfis)
                .Where(() => (usu.Login.IsInsensitiveLike(login) || pfis.NumeroCPF == loginCPF)).List();

            var usuario = query.FirstOrDefault();

            return usuario;
        }

        /// <summary>
        /// Lista os status de contrato por Nome.
        /// </summary>
        /// <param name="nomeItem">Nome ou parte do nome do indicador.</param>        
        /// <returns>Lista com os status mediante filtro.</returns>
        public List<UsuarioSistema> ListarUsuarioPorNome(string nomeItem)
        {
            var sessao = this.Sessao;

            UsuarioSistema usu = null;
            PessoaFisica pfis = null;
            var query = sessao.QueryOver<UsuarioSistema>(() => usu)
                .Inner.JoinAlias(() => usu.PessoaFisica, () => pfis)
                .Where(() => pfis.NomePessoa.IsInsensitiveLike(nomeItem, MatchMode.Anywhere)).List();

            var lista = query.ToList();
            return lista;
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
            var sessao = this.Sessao;

            long loginCPF;
            long.TryParse(cpf.Replace(".", string.Empty).Replace("-", string.Empty), out loginCPF);

            UsuarioSistema usu = null;
            PessoaFisica pfis = null;
            var query = sessao.QueryOver<UsuarioSistema>(() => usu)
                .Inner.JoinAlias(() => usu.PessoaFisica, () => pfis)
                .Where(() => (pfis.NumeroCPF == loginCPF)).List();

            var usuario = query.FirstOrDefault();

            return usuario;
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
            var sessao = this.Sessao;
         
            UsuarioSistema usu = null;
            PessoaFisica pfis = null;
            var query = sessao.QueryOver<UsuarioSistema>(() => usu)
                .Inner.JoinAlias(() => usu.PessoaFisica, () => pfis)
                .Where(() => usu.Login.IsInsensitiveLike(login)).List();

            var usuario = query.FirstOrDefault();

            return usuario;
        }
    }
}

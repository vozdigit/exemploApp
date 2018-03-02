using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
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
    /// Classe responsável pela manipulação da entidade <see cref="RepositorioItem"/>.
    /// </summary>
    public class RepositorioItem : RepositorioId<Item>, IRepositorioItem
    {
        #region Construtores

        /// <summary>
        /// Cria uma instância de <see cref="RepositorioItem"/>.
        /// </summary>
        /// <param name="sessao">O objeto sessão.</param>
        /// <param name="usuario">O usuario.</param>
        public RepositorioItem(ISession sessao, IUsuarioLogado usuario)
            : base(sessao)
        {
            this.Usuario = usuario;
        }

        #endregion

        /// <summary>
        /// Consulta o item pelo controlador.
        /// </summary>
        /// <param name="controlador">Nome do controlador.</param>
        /// <returns>Dados do item.</returns>
        public Item ConsultarItemPorControlador(string controlador)
        {
            var sessao = this.Sessao;
            return sessao.QueryOver<Item>().Where(x => x.Controladoritem == controlador.Trim()).SingleOrDefault();
        }

        /// <summary>
        /// Lista os itens do Modulo disponíveis para o usuário logado.
        /// </summary>
        /// <param name="idModulo">O identificador do Módulo</param>
        /// <param name="usuarioSistema">O login do usuário.</param>
        /// <returns>Lista de itens do usuário no módulo</returns>      
        public List<Item> ListarItensDoUsuarioNoModulo(int idModulo, UsuarioSistema usuarioSistema)
        {
            List<int> listCoditensUsuario = new List<int>();
            var sessao = this.Sessao;
            var query = sessao.QueryOver<Item>().OrderBy(x => x.OrdemItem).Asc;

            query.JoinQueryOver(x => x.Menu)
                .JoinQueryOver(x => x.Modulo)
                .Where(x => x.Id == idModulo);

            foreach (var perfil in usuarioSistema.PerfisAssociadosAoUsuario.Select(x => x.Perfil))
            {
                listCoditensUsuario.AddRange(perfil.ItensAssociadosAoPerfil.Select(x => x.Item.Id));
            }

            var lista = query.Where(x => x.Id.IsIn(listCoditensUsuario)).List().OrderBy(x => x.Menu.OrdemMenu).ToList();

            ////var lista = query.List().OrderBy(x => x.Menu.OrdemMenu).ToList();

            return lista;
        }

        /// <summary>
        /// Lista os por Item.
        /// </summary>
        /// <param name="descricao">Nome ou parte do nome.</param>        
        /// <returns>Lista com os status mediante filtro.</returns>
        public List<Item> ListarItemPorNome(string descricao)
        {
            var sessao = this.Sessao;
            var query = sessao.QueryOver<Item>();

            if (!string.IsNullOrWhiteSpace(descricao))
            {
                query.WhereRestrictionOn(x => x.DescricaoItem).IsInsensitiveLike(descricao.Trim(), MatchMode.Anywhere);
            }

            var lista = query.List().ToList();
            return lista;
        }
    }
}

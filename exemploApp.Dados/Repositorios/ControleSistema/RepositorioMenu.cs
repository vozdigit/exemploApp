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
    /// Classe responsável pela manipulação da entidade <see cref="RepositorioMenu"/>.
    /// </summary>
    public class RepositorioMenu : RepositorioId<Menu>, IRepositorioMenu
    {
        #region Construtores

        /// <summary>
        /// Cria uma instância de <see cref="RepositorioMenu"/>.
        /// </summary>
        /// <param name="sessao">O objeto sessão.</param>
        /// <param name="usuario">O usuario.</param>
        public RepositorioMenu(ISession sessao, IUsuarioLogado usuario)
            : base(sessao)
        {
            this.Usuario = usuario;
        }

        #endregion
    }
}

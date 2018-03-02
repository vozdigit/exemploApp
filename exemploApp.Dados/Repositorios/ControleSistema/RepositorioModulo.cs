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
    /// Classe responsável pela manipulação da entidade <see cref="RepositorioModulo"/>.
    /// </summary>
    public class RepositorioModulo : RepositorioId<Modulo>, IRepositorioModulo
    {
        #region Construtores

        /// <summary>
        /// Cria uma instância de <see cref="RepositorioModulo"/>.
        /// </summary>
        /// <param name="sessao">O objeto sessão.</param>
        /// <param name="usuario">O usuario.</param>
        public RepositorioModulo(ISession sessao, IUsuarioLogado usuario)
            : base(sessao)
        {
            this.Usuario = usuario;
        }

        #endregion
    }
}

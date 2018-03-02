using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Entidades;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Repositorios.Padrao
{
    /// <summary>
    /// Classe responsável pela manipulação da entidade <see cref="RepositorioUnidadeFederacao"/>.
    /// </summary>
    public class RepositorioUnidadeFederacao : RepositorioId<UnidadeFederacao>, IRepositorioUnidadeFederacao
    {
        #region Construtores

        /// <summary>
        /// Cria uma instância de <see cref="RepositorioUnidadeFederacao"/>.
        /// </summary>
        /// <param name="sessao">O objeto sessão.</param>
        /// <param name="usuario">O usuario.</param>
        public RepositorioUnidadeFederacao(ISession sessao, IUsuarioLogado usuario)
            : base(sessao)
        {
            this.Usuario = usuario;
        }

        #endregion
    }
}

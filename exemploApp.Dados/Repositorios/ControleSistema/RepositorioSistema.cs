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
    /// Classe responsável pela manipulação da entidade <see cref="RepositorioSistema"/>.
    /// </summary>
    public class RepositorioSistema : RepositorioId<Sistema>, IRepositorioSistema
    {
        #region Construtores

        /// <summary>
        /// Cria uma instância de <see cref="RepositorioSistema"/>.
        /// </summary>
        /// <param name="sessao">O objeto sessão.</param>
        /// <param name="usuario">O usuario.</param>
        public RepositorioSistema(ISession sessao, IUsuarioLogado usuario)
            : base(sessao)
        {
            this.Usuario = usuario;
        }

        #endregion

        /// <summary>
        /// Consulta sistema por sigla.
        /// </summary>
        /// <param name="siglaSistema">A sigla do sistema.</param>
        /// <returns>Os dados do sistema.</returns>
        public Sistema ConsultarPorSigla(string siglaSistema)
        {
            var sessao = this.Sessao;
            return sessao.QueryOver<Sistema>().Where(x => x.SiglaSistema == siglaSistema).SingleOrDefault();
        }
    }
}

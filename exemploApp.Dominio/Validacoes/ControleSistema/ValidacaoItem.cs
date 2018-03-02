using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.ControleSistema
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoItem : ValidacaoEntidadeId<Item>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Item.
        /// </summary>
        private IRepositorioItem repositorioItem;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoItem"/> class.
        /// </summary>
        /// <param name="repositorioItem">The repositorio Item.</param>
        public ValidacaoItem(IRepositorioItem repositorioItem)
        {
            this.repositorioItem = repositorioItem;
        }

        #endregion
    }
}

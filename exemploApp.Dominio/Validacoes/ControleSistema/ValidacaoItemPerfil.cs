using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.ControleSistema
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoItemPerfil : ValidacaoEntidadeId<ItemPerfil>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de ItemPerfil.
        /// </summary>
        private IRepositorioItemPerfil repositorioItemPerfil;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoItemPerfil"/> class.
        /// </summary>
        /// <param name="repositorioItemPerfil">The repositorio ItemPerfil.</param>
        public ValidacaoItemPerfil(IRepositorioItemPerfil repositorioItemPerfil)
        {
            this.repositorioItemPerfil = repositorioItemPerfil;
        }

        #endregion
    }
}

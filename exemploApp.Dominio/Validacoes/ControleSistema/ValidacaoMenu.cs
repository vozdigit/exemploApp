using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.ControleSistema
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoMenu : ValidacaoEntidadeId<Menu>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Menu.
        /// </summary>
        private IRepositorioMenu repositorioMenu;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoMenu"/> class.
        /// </summary>
        /// <param name="repositorioMenu">The repositorio Menu.</param>
        public ValidacaoMenu(IRepositorioMenu repositorioMenu)
        {
            this.repositorioMenu = repositorioMenu;
        }

        #endregion
    }
}

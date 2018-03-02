using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.ControleSistema
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoModulo : ValidacaoEntidadeId<Modulo>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Modulo.
        /// </summary>
        private IRepositorioModulo repositorioModulo;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoModulo"/> class.
        /// </summary>
        /// <param name="repositorioModulo">The repositorio Modulo.</param>
        public ValidacaoModulo(IRepositorioModulo repositorioModulo)
        {
            this.repositorioModulo = repositorioModulo;
        }

        #endregion
    }
}

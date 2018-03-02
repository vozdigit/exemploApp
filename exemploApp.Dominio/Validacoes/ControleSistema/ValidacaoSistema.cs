using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.ControleSistema
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoSistema : ValidacaoEntidadeId<Sistema>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Sistema.
        /// </summary>
        private IRepositorioSistema repositorioSistema;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoSistema"/> class.
        /// </summary>
        /// <param name="repositorioSistema">The repositorio Sistema.</param>
        public ValidacaoSistema(IRepositorioSistema repositorioSistema)
        {
            this.repositorioSistema = repositorioSistema;
        }

        #endregion
    }
}

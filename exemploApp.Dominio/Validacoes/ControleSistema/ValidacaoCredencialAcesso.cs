using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.ControleSistema
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoCredencialAcesso : ValidacaoEntidadeId<CredencialAcesso>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Credencial Acesso.
        /// </summary>
        private IRepositorioCredencialAcesso repositorioCredencialAcesso;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoCredencialAcesso"/> class.
        /// </summary>
        /// <param name="repositorioCredencialAcesso">The repositorio CredencialAcesso.</param>
        public ValidacaoCredencialAcesso(IRepositorioCredencialAcesso repositorioCredencialAcesso)
        {
            this.repositorioCredencialAcesso = repositorioCredencialAcesso;
        }

        #endregion
    }
}

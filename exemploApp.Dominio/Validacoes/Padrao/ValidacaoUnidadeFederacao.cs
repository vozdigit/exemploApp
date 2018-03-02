using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoUnidadeFederacao : ValidacaoEntidadeId<UnidadeFederacao>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de UnidadeFederacao.
        /// </summary>
        private IRepositorioUnidadeFederacao repositorioUnidadeFederacao;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoUnidadeFederacao"/> class.
        /// </summary>
        /// <param name="repositorioUnidadeFederacao">The repositorio UnidadeFederacao.</param>
        public ValidacaoUnidadeFederacao(IRepositorioUnidadeFederacao repositorioUnidadeFederacao)
        {
            this.repositorioUnidadeFederacao = repositorioUnidadeFederacao;
        }

        #endregion
    }
}

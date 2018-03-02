using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoResponsavelPessoaFisica : ValidacaoEntidadeId<ResponsavelPessoaFisica>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de ResponsavelPessoaFisica.
        /// </summary>
        private IRepositorioResponsavelPessoaFisica repositorioResponsavelPessoaFisica;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoResponsavelPessoaFisica"/> class.
        /// </summary>
        /// <param name="repositorioResponsavelPessoaFisica">The repositorio ResponsavelPessoaFisica.</param>
        public ValidacaoResponsavelPessoaFisica(IRepositorioResponsavelPessoaFisica repositorioResponsavelPessoaFisica)
        {
            this.repositorioResponsavelPessoaFisica = repositorioResponsavelPessoaFisica;
        }

        #endregion
    }
}

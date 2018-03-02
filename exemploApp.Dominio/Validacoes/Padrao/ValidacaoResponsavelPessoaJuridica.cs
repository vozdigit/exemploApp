using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoResponsavelPessoaJuridica : ValidacaoEntidadeId<ResponsavelPessoaJuridica>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de ResponsavelPessoaJuridica.
        /// </summary>
        private IRepositorioResponsavelPessoaJuridica repositorioResponsavelPessoaJuridica;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoResponsavelPessoaJuridica"/> class.
        /// </summary>
        /// <param name="repositorioResponsavelPessoaJuridica">The repositorio ResponsavelPessoaJuridica.</param>
        public ValidacaoResponsavelPessoaJuridica(IRepositorioResponsavelPessoaJuridica repositorioResponsavelPessoaJuridica)
        {
            this.repositorioResponsavelPessoaJuridica = repositorioResponsavelPessoaJuridica;
        }

        #endregion
    }
}

using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoPessoaFisica : ValidacaoEntidadeId<PessoaFisica>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de PessoaFisica.
        /// </summary>
        private IRepositorioPessoaFisica repositorioPessoaFisica;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoPessoaFisica"/> class.
        /// </summary>
        /// <param name="repositorioPessoaFisica">The repositorio PessoaFisica.</param>
        public ValidacaoPessoaFisica(IRepositorioPessoaFisica repositorioPessoaFisica)
        {
            this.repositorioPessoaFisica = repositorioPessoaFisica;
        }

        #endregion
    }
}

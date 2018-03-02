using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoPessoaJuridica : ValidacaoEntidadeId<PessoaJuridica>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de PessoaJuridica.
        /// </summary>
        private IRepositorioPessoaJuridica repositorioPessoaJuridica;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoPessoaJuridica"/> class.
        /// </summary>
        /// <param name="repositorioPessoaJuridica">The repositorio PessoaJuridica.</param>
        public ValidacaoPessoaJuridica(IRepositorioPessoaJuridica repositorioPessoaJuridica)
        {
            this.repositorioPessoaJuridica = repositorioPessoaJuridica;
        }

        #endregion
    }
}

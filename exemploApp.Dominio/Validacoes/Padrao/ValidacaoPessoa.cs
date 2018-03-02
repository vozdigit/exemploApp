using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoPessoa : ValidacaoEntidadeId<Pessoa>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Pessoa.
        /// </summary>
        private IRepositorioPessoa repositorioPessoa;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoPessoa"/> class.
        /// </summary>
        /// <param name="repositorioPessoa">The repositorio Pessoa.</param>
        public ValidacaoPessoa(IRepositorioPessoa repositorioPessoa)
        {
            this.repositorioPessoa = repositorioPessoa;
        }

        #endregion
    }
}

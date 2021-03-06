using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoTelefone : ValidacaoEntidadeId<Telefone>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Telefone.
        /// </summary>
        private IRepositorioTelefone repositorioTelefone;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoTelefone"/> class.
        /// </summary>
        /// <param name="repositorioTelefone">The repositorio Telefone.</param>
        public ValidacaoTelefone(IRepositorioTelefone repositorioTelefone)
        {
            this.repositorioTelefone = repositorioTelefone;
        }

        #endregion
    }
}

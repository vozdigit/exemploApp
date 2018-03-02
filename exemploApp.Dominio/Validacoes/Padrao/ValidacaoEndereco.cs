using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoEndereco : ValidacaoEntidadeId<Endereco>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Endereco.
        /// </summary>
        private IRepositorioEndereco repositorioEndereco;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoEndereco"/> class.
        /// </summary>
        /// <param name="repositorioEndereco">The repositorio Endereco.</param>
        public ValidacaoEndereco(IRepositorioEndereco repositorioEndereco)
        {
            this.repositorioEndereco = repositorioEndereco;
        }

        #endregion
    }
}

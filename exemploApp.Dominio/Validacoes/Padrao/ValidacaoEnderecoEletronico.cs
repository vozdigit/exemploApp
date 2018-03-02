using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoEnderecoEletronico : ValidacaoEntidadeId<EnderecoEletronico>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de EnderecoEletronico.
        /// </summary>
        private IRepositorioEnderecoEletronico repositorioEnderecoEletronico;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoEnderecoEletronico"/> class.
        /// </summary>
        /// <param name="repositorioEnderecoEletronico">The repositorio EnderecoEletronico.</param>
        public ValidacaoEnderecoEletronico(IRepositorioEnderecoEletronico repositorioEnderecoEletronico)
        {
            this.repositorioEnderecoEletronico = repositorioEnderecoEletronico;
        }

        #endregion
    }
}

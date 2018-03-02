using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoMunicipio : ValidacaoEntidadeId<Municipio>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Municipio.
        /// </summary>
        private IRepositorioMunicipio repositorioMunicipio;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoMunicipio"/> class.
        /// </summary>
        /// <param name="repositorioMunicipio">The repositorio Municipio.</param>
        public ValidacaoMunicipio(IRepositorioMunicipio repositorioMunicipio)
        {
            this.repositorioMunicipio = repositorioMunicipio;
        }

        #endregion
    }
}

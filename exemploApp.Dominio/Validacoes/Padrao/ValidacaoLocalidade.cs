using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.Padrao
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoLocalidade : ValidacaoEntidadeId<Localidade>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Localidade.
        /// </summary>
        private IRepositorioLocalidade repositorioLocalidade;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoLocalidade"/> class.
        /// </summary>
        /// <param name="repositorioLocalidade">The repositorio Localidade.</param>
        public ValidacaoLocalidade(IRepositorioLocalidade repositorioLocalidade)
        {
            this.repositorioLocalidade = repositorioLocalidade;
        }

        #endregion
    }
}

using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.ControleSistema
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoPerfil : ValidacaoEntidadeId<Perfil>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de Perfil.
        /// </summary>
        private IRepositorioPerfil repositorioPerfil;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoPerfil"/> class.
        /// </summary>
        /// <param name="repositorioPerfil">The repositorio Perfil.</param>
        public ValidacaoPerfil(IRepositorioPerfil repositorioPerfil)
        {
            this.repositorioPerfil = repositorioPerfil;
        }

        #endregion
    }
}

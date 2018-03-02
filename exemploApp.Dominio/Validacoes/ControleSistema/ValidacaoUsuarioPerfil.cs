using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.ControleSistema
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoUsuarioPerfil : ValidacaoEntidadeId<UsuarioPerfil>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de UsuarioPerfil.
        /// </summary>
        private IRepositorioUsuarioPerfil repositorioUsuarioPerfil;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoUsuarioPerfil"/> class.
        /// </summary>
        /// <param name="repositorioUsuarioPerfil">The repositorio UsuarioPerfil.</param>
        public ValidacaoUsuarioPerfil(IRepositorioUsuarioPerfil repositorioUsuarioPerfil)
        {
            this.repositorioUsuarioPerfil = repositorioUsuarioPerfil;
        }

        #endregion
    }
}

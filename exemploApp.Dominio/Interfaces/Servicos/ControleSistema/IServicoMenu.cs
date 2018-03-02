using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.ControleSistema
{
    /// <summary>
    /// Interface de Serviço para Menu
    /// </summary>
    public interface IServicoMenu : IServico<Menu>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        Menu ConsultaPorId(int id);

        #endregion
    }
}

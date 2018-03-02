using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.ControleSistema
{
    /// <summary>
    /// Interface de Serviço para ItemPerfil
    /// </summary>
    public interface IServicoItemPerfil : IServico<ItemPerfil>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        ItemPerfil ConsultaPorId(int id);

        #endregion
    }
}

using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.ControleSistema
{
    /// <summary>
    /// Interface de Serviço para Modulo
    /// </summary>
    public interface IServicoModulo : IServico<Modulo>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        Modulo ConsultaPorId(int id);

        #endregion
    }
}

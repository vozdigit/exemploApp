using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.ControleSistema
{
    /// <summary>
    /// Interface de Serviço para Perfil
    /// </summary>
    public interface IServicoPerfil : IServico<Perfil>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        Perfil ConsultaPorId(int id);

        #endregion
    }
}

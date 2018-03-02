using exemploApp.Dominio.Entidades.EntidadesPadrao;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.Padrao
{
    /// <summary>
    /// Interface de Serviço para UnidadeFederacao
    /// </summary>
    public interface IServicoUnidadeFederacao : IServico<UnidadeFederacao>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        UnidadeFederacao ConsultaPorId(int id);

        #endregion
    }
}

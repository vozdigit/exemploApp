using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.ControleSistema
{
    /// <summary>
    /// Interface de Serviço para Sistema
    /// </summary>
    public interface IServicoSistema : IServico<Sistema>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        Sistema ConsultaPorId(int id);

        #endregion

        /// <summary>
        /// Obtem dados do sistema atual.
        /// </summary>
        /// <param name="siglaSistema">A Sigla do sistema.</param>
        /// <returns>O Sistema atual e suas informações.</returns>
        Sistema ConsultarPorSigla(string siglaSistema);
    }
}

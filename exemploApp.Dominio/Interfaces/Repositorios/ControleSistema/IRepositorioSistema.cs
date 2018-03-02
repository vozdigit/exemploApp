using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using Tykon.Base.Persistencia;

namespace exemploApp.Dominio.Interfaces.Repositorios.ControleSistema
{
    /// <summary>
    /// Interface de repositório de Sistema.
    /// </summary>
    public interface IRepositorioSistema : IRepositorioId<Sistema>
    {
        /// <summary>
        /// Obtem dados do sistema atual.
        /// </summary>
        /// <param name="siglaSistema">A Sigla do sistema.</param>
        /// <returns>O Sistema atual e suas informações.</returns>
        Sistema ConsultarPorSigla(string siglaSistema);
    }
}

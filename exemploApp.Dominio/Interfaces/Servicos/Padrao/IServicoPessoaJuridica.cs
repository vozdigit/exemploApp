using exemploApp.Dominio.Entidades.EntidadesPadrao;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.Padrao
{
    /// <summary>
    /// Interface de Serviço para PessoaJuridica
    /// </summary>
    public interface IServicoPessoaJuridica : IServico<PessoaJuridica>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        PessoaJuridica ConsultaPorId(int id);

        #endregion
    }
}

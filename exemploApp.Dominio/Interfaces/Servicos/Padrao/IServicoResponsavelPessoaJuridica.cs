using exemploApp.Dominio.Entidades.EntidadesPadrao;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.Padrao
{
    /// <summary>
    /// Interface de Serviço para ResponsavelPessoaJuridica
    /// </summary>
    public interface IServicoResponsavelPessoaJuridica : IServico<ResponsavelPessoaJuridica>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        ResponsavelPessoaJuridica ConsultaPorId(int id);

        #endregion
    }
}

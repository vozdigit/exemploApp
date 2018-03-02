using exemploApp.Dominio.Entidades.EntidadesPadrao;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.Padrao
{
    /// <summary>
    /// Interface de Serviço para ResponsavelPessoaFisica
    /// </summary>
    public interface IServicoResponsavelPessoaFisica : IServico<ResponsavelPessoaFisica>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        ResponsavelPessoaFisica ConsultaPorId(int id);

        #endregion
    }
}

using exemploApp.Dominio.Entidades.EntidadesPadrao;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.Padrao
{
    /// <summary>
    /// Interface de Serviço para EnderecoEletronico
    /// </summary>
    public interface IServicoEnderecoEletronico : IServico<EnderecoEletronico>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        EnderecoEletronico ConsultaPorId(int id);

        #endregion
    }
}

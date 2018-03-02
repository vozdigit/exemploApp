using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using System.Collections.Generic;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.ControleSistema
{
    /// <summary>
    /// Interface de Serviço para Item
    /// </summary>
    public interface IServicoItem : IServico<Item>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        Item ConsultaPorId(int id);

        #endregion

        /// <summary>
        /// Consulta o item pelo controlador.
        /// </summary>
        /// <param name="controlador">Nome do controlador.</param>
        /// <returns>Dados do item.</returns>
        Item ConsultarItemPorControlador(string controlador);

        /// <summary>
        /// Lista os itens do Modulo disponíveis para o usuário logado.
        /// </summary>
        /// <param name="idModulo">O identificador do Módulo</param>
        /// <param name="loginUsuario">O login do usuário.</param>
        /// <returns>Lista de itens do usuário no módulo</returns>
        List<Item> ListarItensDoUsuarioNoModulo(int idModulo, string loginUsuario);

        /// <summary>
        /// Lista os por Item.
        /// </summary>
        /// <param name="descricao">Nome ou parte do nome.</param>        
        /// <returns>Lista com os status mediante filtro.</returns>
        List<Item> ListarItemPorNome(string descricao);
    }
}

using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using System.Collections.Generic;
using Tykon.Base.Persistencia;

namespace exemploApp.Dominio.Interfaces.Repositorios.ControleSistema
{
    /// <summary>
    /// Interface de repositório de Item.
    /// </summary>
    public interface IRepositorioItem : IRepositorioId<Item>
    {
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
        /// <param name="usuarioSistema">O login do usuário.</param>
        /// <returns>Lista de itens do usuário no módulo</returns>
        List<Item> ListarItensDoUsuarioNoModulo(int idModulo, UsuarioSistema usuarioSistema);

        /// <summary>
        /// Lista os por Item.
        /// </summary>
        /// <param name="descricao">Nome ou parte do nome.</param>        
        /// <returns>Lista com os status mediante filtro.</returns>
        List<Item> ListarItemPorNome(string descricao);
    }
}

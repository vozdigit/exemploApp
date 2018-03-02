using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using System.Collections.Generic;
using Tykon.Base.Persistencia;

namespace exemploApp.Dominio.Interfaces.Repositorios.ControleSistema
{
    /// <summary>
    /// Interface de repositório de Usuario do Sistema.
    /// </summary>
    public interface IRepositorioUsuarioSistema : IRepositorioId<UsuarioSistema>
    {
        /// <summary>
        /// Consultars the usuario por login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>O Usuário dono do login.</returns>
        UsuarioSistema ConsultarUsuarioPorLoginOuCpf(string login);

        /// <summary>
        /// Lista os status de contrato por Nome.
        /// </summary>
        /// <param name="nomeItem">Nome ou parte do nome do indicador.</param>        
        /// <returns>Lista com os status mediante filtro.</returns>
        List<UsuarioSistema> ListarUsuarioPorNome(string nomeItem);

        /// <summary>
        /// Consultars the usuario por cpf.
        /// </summary>
        /// <param name="cpf">The login.</param>
        /// <returns>
        /// O Usuário dono do pessoa fisica.
        /// </returns>
        UsuarioSistema ConsultarUsuarioPorCpf(string cpf);

        /// <summary>
        /// Consultars the usuario por login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>
        /// O Usuário dono do login.
        /// </returns>
        UsuarioSistema ConsultarUsuarioPorLogin(string login);
    }
}

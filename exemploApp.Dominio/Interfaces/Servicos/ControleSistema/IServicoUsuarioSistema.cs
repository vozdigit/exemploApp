using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using System.Collections.Generic;
using Tykon.Base.Servicos;

namespace exemploApp.Dominio.Interfaces.Servicos.ControleSistema
{
    /// <summary>
    /// Interface de Serviço para UsuarioSistema
    /// </summary>
    public interface IServicoUsuarioSistema : IServico<UsuarioSistema>
    {
        #region Métodos da superclasse

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        UsuarioSistema ConsultaPorId(int id);

        #endregion

        /// <summary>
        /// Consultars the usuario por login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <param name="pontuacaoUsuarioLogado">A pontuacao do usuario logado.</param>
        /// <returns>
        /// O Usuário dono do login.
        /// </returns>
        UsuarioSistema ConsultarUsuarioPorLoginOuCpf(string login, int pontuacaoUsuarioLogado);

        /// <summary>
        /// Consultars the usuario por login.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>
        /// O Usuário dono do login.
        /// </returns>
        UsuarioSistema ConsultarUsuarioPorLoginOuCpf(string login);

        /////// <summary>
        /////// Lista os usuario por Nome.
        /////// </summary>
        /////// <param name="nomeItem">Nome ou parte do nome do indicador.</param>        
        /////// <returns>Lista com os status mediante filtro.</returns>
        ////List<UsuarioSistema> ListarUsuarioPorNome(string nomeItem);

        /// <summary>
        /// Lista os status de contrato por Nome.
        /// </summary>
        /// <param name="nomeItem">Nome ou parte do nome do indicador.</param>
        /// <param name="pontuacaoUsuarioLogado">A pontuacao do usuario logado.</param>
        /// <returns>Lista com os status mediante filtro.</returns>
        List<UsuarioSistema> ListarUsuarioPorNome(string nomeItem, int pontuacaoUsuarioLogado);

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

        /// <summary>
        /// Salvars the informacoes pessoais usuario.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        void SalvarInformacoesPessoaisUsuario(UsuarioSistema usuario);
    }
}

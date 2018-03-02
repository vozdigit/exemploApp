using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
using exemploApp.Dominio.Validacoes.ControleSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Helpers;
using Tykon.Base.Servicos;
using Tykon.Base.Validacoes;

namespace exemploApp.Servico.ControleSistema
{
    /// <summary>
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoItem"/>.
    /// </summary>
    public class ServicoItem : Servico<Item>, IServicoItem
    {
        /// <summary>
        /// O repositório de Item.
        /// </summary>
        private IRepositorioItem repositorioItem;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoItem"/>.
        /// </summary>
        /// <param name="repositorioItem">O repositório de Item.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoItem(IRepositorioItem repositorioItem, IFabrica fabrica)
            : base(repositorioItem, fabrica)
        {
            this.repositorioItem = repositorioItem;
        }

        /// <summary>
        /// Indica a validação para o Item.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Item> Validador
        {
            get
            {
                return new ValidacaoItem(this.repositorioItem);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Item ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioItem;
            return repositorio.Consultar(id);
        }

        /// <summary>
        /// Consulta o item pelo controlador.
        /// </summary>
        /// <param name="controlador">Nome do controlador.</param>
        /// <returns>Dados do item.</returns>
        public Item ConsultarItemPorControlador(string controlador)
        {
            var repositorio = this.Repositorio as IRepositorioItem;
            return repositorio.ConsultarItemPorControlador(controlador);
        }

        /// <summary>
        /// Lista os itens do Modulo disponíveis para o usuário logado.
        /// </summary>
        /// <param name="idModulo">O identificador do Módulo</param>
        /// <param name="loginUsuario">O login do usuário.</param>
        /// <returns>Lista de itens do usuário no módulo</returns>        
        public List<Item> ListarItensDoUsuarioNoModulo(int idModulo, string loginUsuario)
        {
            UsuarioSistema usuarioLogado = new UsuarioSistema();

            using (var svc = Fabrica.Resolva<IServicoUsuarioSistema>())
            {
                usuarioLogado = svc.ConsultarUsuarioPorLoginOuCpf(loginUsuario);
            }

            var repositorio = this.Repositorio as IRepositorioItem;
            return repositorio.ListarItensDoUsuarioNoModulo(idModulo, usuarioLogado);
        }

        /// <summary>
        /// Lista os por Item.
        /// </summary>
        /// <param name="descricao">Nome ou parte do nome.</param>        
        /// <returns>Lista com os status mediante filtro.</returns>
        public List<Item> ListarItemPorNome(string descricao)
        {
            var repositorio = this.Repositorio as IRepositorioItem;
            return repositorio.ListarItemPorNome(descricao);
        }
    }
}

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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoMenu"/>.
    /// </summary>
    public class ServicoMenu : Servico<Menu>, IServicoMenu
    {
        /// <summary>
        /// O repositório de Menu.
        /// </summary>
        private IRepositorioMenu repositorioMenu;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoMenu"/>.
        /// </summary>
        /// <param name="repositorioMenu">O repositório de Menu.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoMenu(IRepositorioMenu repositorioMenu, IFabrica fabrica)
            : base(repositorioMenu, fabrica)
        {
            this.repositorioMenu = repositorioMenu;
        }

        /// <summary>
        /// Indica a validação para o Menu.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Menu> Validador
        {
            get
            {
                return new ValidacaoMenu(this.repositorioMenu);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Menu ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioMenu;
            return repositorio.Consultar(id);
        }
    }
}

using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
using exemploApp.Dominio.Interfaces.Servicos.Padrao;
using exemploApp.Dominio.Validacoes.ControleSistema;
using exemploApp.Dominio.Validacoes.Padrao;
using System;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Helpers;
using Tykon.Base.Servicos;
using Tykon.Base.Validacoes;

namespace exemploApp.Servico.ControleSistema
{
    /// <summary>
    /// Camada de serviço para credencial acesso.
    /// </summary>
    public class ServicoCredencialAcesso : Servico<CredencialAcesso>, IServicoCredencialAcesso
    {
        /// <summary>
        /// O repositório de Menu.
        /// </summary>
        private IRepositorioCredencialAcesso repositorioMenu;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoMenu"/>.
        /// </summary>
        /// <param name="repositorioMenu">O repositório de Menu.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoCredencialAcesso(IRepositorioCredencialAcesso repositorioMenu, IFabrica fabrica)
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
        protected override IValidacao<CredencialAcesso> Validador
        {
            get
            {
                return new ValidacaoCredencialAcesso(this.repositorioMenu);
            }
        }
    }
}

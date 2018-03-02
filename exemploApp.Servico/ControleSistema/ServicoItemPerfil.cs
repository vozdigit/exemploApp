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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoItemPerfil"/>.
    /// </summary>
    public class ServicoItemPerfil : Servico<ItemPerfil>, IServicoItemPerfil
    {
        /// <summary>
        /// O repositório de ItemPerfil.
        /// </summary>
        private IRepositorioItemPerfil repositorioItemPerfil;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoItemPerfil"/>.
        /// </summary>
        /// <param name="repositorioItemPerfil">O repositório de ItemPerfil.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoItemPerfil(IRepositorioItemPerfil repositorioItemPerfil, IFabrica fabrica)
            : base(repositorioItemPerfil, fabrica)
        {
            this.repositorioItemPerfil = repositorioItemPerfil;
        }

        /// <summary>
        /// Indica a validação para o ItemPerfil.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<ItemPerfil> Validador
        {
            get
            {
                return new ValidacaoItemPerfil(this.repositorioItemPerfil);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public ItemPerfil ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioItemPerfil;
            return repositorio.Consultar(id);
        }
    }
}

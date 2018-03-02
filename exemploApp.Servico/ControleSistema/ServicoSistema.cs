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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoSistema"/>.
    /// </summary>
    public class ServicoSistema : Servico<Sistema>, IServicoSistema
    {
        /// <summary>
        /// O repositório de Sistema.
        /// </summary>
        private IRepositorioSistema repositorioSistema;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoSistema"/>.
        /// </summary>
        /// <param name="repositorioSistema">O repositório de Sistema.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoSistema(IRepositorioSistema repositorioSistema, IFabrica fabrica)
            : base(repositorioSistema, fabrica)
        {
            this.repositorioSistema = repositorioSistema;
        }

        /// <summary>
        /// Indica a validação para o Sistema.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Sistema> Validador
        {
            get
            {
                return new ValidacaoSistema(this.repositorioSistema);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Sistema ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioSistema;
            return repositorio.Consultar(id);
        }

        /// <summary>
        /// Consulta sistema por sigla.
        /// </summary>
        /// <param name="siglaSistema">A sigla do sistema.</param>
        /// <returns>Os dados do sistema.</returns>
        public Sistema ConsultarPorSigla(string siglaSistema)
        {
            var repositorio = this.Repositorio as IRepositorioSistema;
            return repositorio.ConsultarPorSigla(siglaSistema);
        }
    }
}

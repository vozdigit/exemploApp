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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoModulo"/>.
    /// </summary>
    public class ServicoModulo : Servico<Modulo>, IServicoModulo
    {
        /// <summary>
        /// O repositório de Modulo.
        /// </summary>
        private IRepositorioModulo repositorioModulo;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoModulo"/>.
        /// </summary>
        /// <param name="repositorioModulo">O repositório de Modulo.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoModulo(IRepositorioModulo repositorioModulo, IFabrica fabrica)
            : base(repositorioModulo, fabrica)
        {
            this.repositorioModulo = repositorioModulo;
        }

        /// <summary>
        /// Indica a validação para o Modulo.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Modulo> Validador
        {
            get
            {
                return new ValidacaoModulo(this.repositorioModulo);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Modulo ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioModulo;
            return repositorio.Consultar(id);
        }
    }
}

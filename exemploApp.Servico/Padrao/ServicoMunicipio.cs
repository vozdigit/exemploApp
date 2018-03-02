using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using exemploApp.Dominio.Interfaces.Servicos.Padrao;
using exemploApp.Dominio.Validacoes.Padrao;
using System;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Helpers;
using Tykon.Base.Servicos;
using Tykon.Base.Validacoes;

namespace exemploApp.Servico.Padrao
{
    /// <summary>
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoMunicipio"/>.
    /// </summary>
    public class ServicoMunicipio : Servico<Municipio>, IServicoMunicipio
    {
        /// <summary>
        /// O repositório de Municipio.
        /// </summary>
        private IRepositorioMunicipio repositorioMunicipio;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoMunicipio"/>.
        /// </summary>
        /// <param name="repositorioMunicipio">O repositório de Municipio.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoMunicipio(IRepositorioMunicipio repositorioMunicipio, IFabrica fabrica)
            : base(repositorioMunicipio, fabrica)
        {
            this.repositorioMunicipio = repositorioMunicipio;
        }

        /// <summary>
        /// Indica a validação para o Municipio.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Municipio> Validador
        {
            get
            {
                return new ValidacaoMunicipio(this.repositorioMunicipio);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Municipio ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioMunicipio;
            return repositorio.Consultar(id);
        }
    }
}

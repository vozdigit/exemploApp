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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoResponsavelPessoaFisica"/>.
    /// </summary>
    public class ServicoResponsavelPessoaFisica : Servico<ResponsavelPessoaFisica>, IServicoResponsavelPessoaFisica
    {
        /// <summary>
        /// O repositório de ResponsavelPessoaFisica.
        /// </summary>
        private IRepositorioResponsavelPessoaFisica repositorioResponsavelPessoaFisica;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoResponsavelPessoaFisica"/>.
        /// </summary>
        /// <param name="repositorioResponsavelPessoaFisica">O repositório de ResponsavelPessoaFisica.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoResponsavelPessoaFisica(IRepositorioResponsavelPessoaFisica repositorioResponsavelPessoaFisica, IFabrica fabrica)
            : base(repositorioResponsavelPessoaFisica, fabrica)
        {
            this.repositorioResponsavelPessoaFisica = repositorioResponsavelPessoaFisica;
        }

        /// <summary>
        /// Indica a validação para o ResponsavelPessoaFisica.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<ResponsavelPessoaFisica> Validador
        {
            get
            {
                return new ValidacaoResponsavelPessoaFisica(this.repositorioResponsavelPessoaFisica);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public ResponsavelPessoaFisica ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioResponsavelPessoaFisica;
            return repositorio.Consultar(id);
        }
    }
}

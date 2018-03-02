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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoResponsavelPessoaJuridica"/>.
    /// </summary>
    public class ServicoResponsavelPessoaJuridica : Servico<ResponsavelPessoaJuridica>, IServicoResponsavelPessoaJuridica
    {
        /// <summary>
        /// O repositório de ResponsavelPessoaJuridica.
        /// </summary>
        private IRepositorioResponsavelPessoaJuridica repositorioResponsavelPessoaJuridica;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoResponsavelPessoaJuridica"/>.
        /// </summary>
        /// <param name="repositorioResponsavelPessoaJuridica">O repositório de ResponsavelPessoaJuridica.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoResponsavelPessoaJuridica(IRepositorioResponsavelPessoaJuridica repositorioResponsavelPessoaJuridica, IFabrica fabrica)
            : base(repositorioResponsavelPessoaJuridica, fabrica)
        {
            this.repositorioResponsavelPessoaJuridica = repositorioResponsavelPessoaJuridica;
        }

        /// <summary>
        /// Indica a validação para o ResponsavelPessoaJuridica.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<ResponsavelPessoaJuridica> Validador
        {
            get
            {
                return new ValidacaoResponsavelPessoaJuridica(this.repositorioResponsavelPessoaJuridica);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public ResponsavelPessoaJuridica ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioResponsavelPessoaJuridica;
            return repositorio.Consultar(id);
        }
    }
}

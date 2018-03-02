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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoPessoaFisica"/>.
    /// </summary>
    public class ServicoPessoaFisica : Servico<PessoaFisica>, IServicoPessoaFisica
    {
        /// <summary>
        /// O repositório de PessoaFisica.
        /// </summary>
        private IRepositorioPessoaFisica repositorioPessoaFisica;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoPessoaFisica"/>.
        /// </summary>
        /// <param name="repositorioPessoaFisica">O repositório de PessoaFisica.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoPessoaFisica(IRepositorioPessoaFisica repositorioPessoaFisica, IFabrica fabrica)
            : base(repositorioPessoaFisica, fabrica)
        {
            this.repositorioPessoaFisica = repositorioPessoaFisica;
        }

        /// <summary>
        /// Indica a validação para o PessoaFisica.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<PessoaFisica> Validador
        {
            get
            {
                return new ValidacaoPessoaFisica(this.repositorioPessoaFisica);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public PessoaFisica ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioPessoaFisica;
            return repositorio.Consultar(id);
        }
    }
}

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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoPessoaJuridica"/>.
    /// </summary>
    public class ServicoPessoaJuridica : Servico<PessoaJuridica>, IServicoPessoaJuridica
    {
        /// <summary>
        /// O repositório de PessoaJuridica.
        /// </summary>
        private IRepositorioPessoaJuridica repositorioPessoaJuridica;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoPessoaJuridica"/>.
        /// </summary>
        /// <param name="repositorioPessoaJuridica">O repositório de PessoaJuridica.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoPessoaJuridica(IRepositorioPessoaJuridica repositorioPessoaJuridica, IFabrica fabrica)
            : base(repositorioPessoaJuridica, fabrica)
        {
            this.repositorioPessoaJuridica = repositorioPessoaJuridica;
        }

        /// <summary>
        /// Indica a validação para o PessoaJuridica.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<PessoaJuridica> Validador
        {
            get
            {
                return new ValidacaoPessoaJuridica(this.repositorioPessoaJuridica);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public PessoaJuridica ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioPessoaJuridica;
            return repositorio.Consultar(id);
        }
    }
}

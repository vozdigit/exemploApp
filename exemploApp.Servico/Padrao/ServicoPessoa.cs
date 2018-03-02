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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoPessoa"/>.
    /// </summary>
    public class ServicoPessoa : Servico<Pessoa>, IServicoPessoa
    {
        /// <summary>
        /// O repositório de Pessoa.
        /// </summary>
        private IRepositorioPessoa repositorioPessoa;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoPessoa"/>.
        /// </summary>
        /// <param name="repositorioPessoa">O repositório de Pessoa.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoPessoa(IRepositorioPessoa repositorioPessoa, IFabrica fabrica)
            : base(repositorioPessoa, fabrica)
        {
            this.repositorioPessoa = repositorioPessoa;
        }

        /// <summary>
        /// Indica a validação para o Pessoa.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Pessoa> Validador
        {
            get
            {
                return new ValidacaoPessoa(this.repositorioPessoa);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Pessoa ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioPessoa;
            return repositorio.Consultar(id);
        }
    }
}

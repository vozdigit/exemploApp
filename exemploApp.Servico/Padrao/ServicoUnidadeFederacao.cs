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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoUnidadeFederacao"/>.
    /// </summary>
    public class ServicoUnidadeFederacao : Servico<UnidadeFederacao>, IServicoUnidadeFederacao
    {
        /// <summary>
        /// O repositório de UnidadeFederacao.
        /// </summary>
        private IRepositorioUnidadeFederacao repositorioUnidadeFederacao;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoUnidadeFederacao"/>.
        /// </summary>
        /// <param name="repositorioUnidadeFederacao">O repositório de UnidadeFederacao.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoUnidadeFederacao(IRepositorioUnidadeFederacao repositorioUnidadeFederacao, IFabrica fabrica)
            : base(repositorioUnidadeFederacao, fabrica)
        {
            this.repositorioUnidadeFederacao = repositorioUnidadeFederacao;
        }

        /// <summary>
        /// Indica a validação para o UnidadeFederacao.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<UnidadeFederacao> Validador
        {
            get
            {
                return new ValidacaoUnidadeFederacao(this.repositorioUnidadeFederacao);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public UnidadeFederacao ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioUnidadeFederacao;
            return repositorio.Consultar(id);
        }
    }
}

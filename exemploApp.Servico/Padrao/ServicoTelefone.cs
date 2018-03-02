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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoTelefone"/>.
    /// </summary>
    public class ServicoTelefone : Servico<Telefone>, IServicoTelefone
    {
        /// <summary>
        /// O repositório de Telefone.
        /// </summary>
        private IRepositorioTelefone repositorioTelefone;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoTelefone"/>.
        /// </summary>
        /// <param name="repositorioTelefone">O repositório de Telefone.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoTelefone(IRepositorioTelefone repositorioTelefone, IFabrica fabrica)
            : base(repositorioTelefone, fabrica)
        {
            this.repositorioTelefone = repositorioTelefone;
        }

        /// <summary>
        /// Indica a validação para o Telefone.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Telefone> Validador
        {
            get
            {
                return new ValidacaoTelefone(this.repositorioTelefone);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Telefone ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioTelefone;
            return repositorio.Consultar(id);
        }
    }
}

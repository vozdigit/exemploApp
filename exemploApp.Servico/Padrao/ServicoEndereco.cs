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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoEndereco"/>.
    /// </summary>
    public class ServicoEndereco : Servico<Endereco>, IServicoEndereco
    {
        /// <summary>
        /// O repositório de Endereco.
        /// </summary>
        private IRepositorioEndereco repositorioEndereco;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoEndereco"/>.
        /// </summary>
        /// <param name="repositorioEndereco">O repositório de Endereco.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoEndereco(IRepositorioEndereco repositorioEndereco, IFabrica fabrica)
            : base(repositorioEndereco, fabrica)
        {
            this.repositorioEndereco = repositorioEndereco;
        }

        /// <summary>
        /// Indica a validação para o Endereco.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Endereco> Validador
        {
            get
            {
                return new ValidacaoEndereco(this.repositorioEndereco);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Endereco ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioEndereco;
            return repositorio.Consultar(id);
        }
    }
}

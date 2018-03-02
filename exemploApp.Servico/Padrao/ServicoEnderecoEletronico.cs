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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoEnderecoEletronico"/>.
    /// </summary>
    public class ServicoEnderecoEletronico : Servico<EnderecoEletronico>, IServicoEnderecoEletronico
    {
        /// <summary>
        /// O repositório de EnderecoEletronico.
        /// </summary>
        private IRepositorioEnderecoEletronico repositorioEnderecoEletronico;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoEnderecoEletronico"/>.
        /// </summary>
        /// <param name="repositorioEnderecoEletronico">O repositório de EnderecoEletronico.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoEnderecoEletronico(IRepositorioEnderecoEletronico repositorioEnderecoEletronico, IFabrica fabrica)
            : base(repositorioEnderecoEletronico, fabrica)
        {
            this.repositorioEnderecoEletronico = repositorioEnderecoEletronico;
        }

        /// <summary>
        /// Indica a validação para o EnderecoEletronico.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<EnderecoEletronico> Validador
        {
            get
            {
                return new ValidacaoEnderecoEletronico(this.repositorioEnderecoEletronico);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public EnderecoEletronico ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioEnderecoEletronico;
            return repositorio.Consultar(id);
        }
    }
}

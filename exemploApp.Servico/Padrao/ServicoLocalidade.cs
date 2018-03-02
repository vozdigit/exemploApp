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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoLocalidade"/>.
    /// </summary>
    public class ServicoLocalidade : Servico<Localidade>, IServicoLocalidade
    {
        /// <summary>
        /// O repositório de Localidade.
        /// </summary>
        private IRepositorioLocalidade repositorioLocalidade;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoLocalidade"/>.
        /// </summary>
        /// <param name="repositorioLocalidade">O repositório de Localidade.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoLocalidade(IRepositorioLocalidade repositorioLocalidade, IFabrica fabrica)
            : base(repositorioLocalidade, fabrica)
        {
            this.repositorioLocalidade = repositorioLocalidade;
        }

        /// <summary>
        /// Indica a validação para o Localidade.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Localidade> Validador
        {
            get
            {
                return new ValidacaoLocalidade(this.repositorioLocalidade);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Localidade ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioLocalidade;
            return repositorio.Consultar(id);
        }
    }
}

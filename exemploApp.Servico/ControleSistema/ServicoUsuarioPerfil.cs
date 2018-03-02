using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
using exemploApp.Dominio.Validacoes.ControleSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Helpers;
using Tykon.Base.Servicos;
using Tykon.Base.Validacoes;

namespace exemploApp.Servico.ControleSistema
{
    /// <summary>
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoUsuarioPerfil"/>.
    /// </summary>
    public class ServicoUsuarioPerfil : Servico<UsuarioPerfil>, IServicoUsuarioPerfil
    {
        /// <summary>
        /// O repositório de UsuarioPerfil.
        /// </summary>
        private IRepositorioUsuarioPerfil repositorioUsuarioPerfil;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoUsuarioPerfil"/>.
        /// </summary>
        /// <param name="repositorioUsuarioPerfil">O repositório de UsuarioPerfil.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoUsuarioPerfil(IRepositorioUsuarioPerfil repositorioUsuarioPerfil, IFabrica fabrica)
            : base(repositorioUsuarioPerfil, fabrica)
        {
            this.repositorioUsuarioPerfil = repositorioUsuarioPerfil;
        }

        /// <summary>
        /// Indica a validação para o UsuarioPerfil.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<UsuarioPerfil> Validador
        {
            get
            {
                return new ValidacaoUsuarioPerfil(this.repositorioUsuarioPerfil);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public UsuarioPerfil ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioUsuarioPerfil;
            return repositorio.Consultar(id);
        }
    }
}

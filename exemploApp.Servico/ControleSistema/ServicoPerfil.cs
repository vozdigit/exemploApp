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
    ///  Classe responsável pela manipulação da entidade <see cref="ServicoPerfil"/>.
    /// </summary>
    public class ServicoPerfil : Servico<Perfil>, IServicoPerfil
    {
        /// <summary>
        /// O repositório de Perfil.
        /// </summary>
        private IRepositorioPerfil repositorioPerfil;

        /// <summary>
        /// Cria uma instânica de <see cref="ServicoPerfil"/>.
        /// </summary>
        /// <param name="repositorioPerfil">O repositório de Perfil.</param>
        /// <param name="fabrica">A fabrica.</param>
        public ServicoPerfil(IRepositorioPerfil repositorioPerfil, IFabrica fabrica)
            : base(repositorioPerfil, fabrica)
        {
            this.repositorioPerfil = repositorioPerfil;
        }

        /// <summary>
        /// Indica a validação para o Perfil.
        /// </summary>
        /// <value>
        /// A validação.
        /// </value>
        protected override IValidacao<Perfil> Validador
        {
            get
            {
                return new ValidacaoPerfil(this.repositorioPerfil);
            }
        }

        /// <summary>
        /// Efetua uma consulta por id.
        /// </summary>
        /// <param name="id">Identificador do registro.</param>
        /// <returns>Retorna o registro encontrado.</returns>
        public Perfil ConsultaPorId(int id)
        {
            var repositorio = this.Repositorio as IRepositorioPerfil;
            return repositorio.Consultar(id);
        }
    }
}

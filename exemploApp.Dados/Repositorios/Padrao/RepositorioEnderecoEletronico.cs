using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Interfaces.Repositorios.Padrao;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Entidades;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Repositorios.Padrao
{
    /// <summary>
    /// Classe responsável pela manipulação da entidade <see cref="RepositorioEnderecoEletronico"/>.
    /// </summary>
    public class RepositorioEnderecoEletronico : RepositorioId<EnderecoEletronico>, IRepositorioEnderecoEletronico
    {
        #region Construtores

        /// <summary>
        /// Cria uma instância de <see cref="RepositorioEnderecoEletronico"/>.
        /// </summary>
        /// <param name="sessao">O objeto sessão.</param>
        /// <param name="usuario">O usuario.</param>
        public RepositorioEnderecoEletronico(ISession sessao, IUsuarioLogado usuario)
            : base(sessao)
        {
            this.Usuario = usuario;
        }

        #endregion
    }
}

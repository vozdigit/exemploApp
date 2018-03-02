using exemploApp.Dominio.Entidades.Enumeradores;
using System.Collections.Generic;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesControleSistema
{
    /// <summary>
    /// Classe que implementa os perfis do sistema.
    /// </summary>
    public class Perfil : EntidadeId
    {
        /// <summary>
        /// Cria a instancia de Perfil.
        /// </summary>
        public Perfil()
        {
            this.ItensAssociadosAoPerfil = new List<ItemPerfil>();
            this.UsuariosAssociadosAoPerfil = new List<UsuarioPerfil>();
        }

        /// <summary>
        /// Recupera ou define o sistema.
        /// </summary>
        public virtual Sistema Sistema { get; set; }

        /// <summary>
        /// Recupera ou define o nome do perfil.
        /// </summary>
        public virtual string NomePerfil { get; set; }

        /// <summary>
        /// Recupera ou define o status do perfil.
        /// </summary>
        public virtual EnumSituacao StatusPerfil { get; set; }

        /// <summary>
        /// Recupera ou define lista de itens associados ao perfil.
        /// </summary>
        public virtual IList<ItemPerfil> ItensAssociadosAoPerfil { get; set; }

        /// <summary>
        /// Recupera ou define lista de usuarios associados ao perfil.
        /// </summary>
        public virtual IList<UsuarioPerfil> UsuariosAssociadosAoPerfil { get; set; }

        /// <summary>
        /// Recupera ou define a pontuação do perfil baseado na hierarquia.
        /// </summary>
        public virtual int Pontuacao { get; set; }
    }
}

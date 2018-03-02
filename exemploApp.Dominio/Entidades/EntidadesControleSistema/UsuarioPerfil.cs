using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesControleSistema
{
    /// <summary>
    /// Classe que implementa a associação entre usuário e Perfil.
    /// </summary>
    public class UsuarioPerfil : EntidadeId
    {
        /// <summary>
        /// Recupera ou define o usuário do sistema.
        /// </summary>
        public virtual UsuarioSistema UsuarioSistema { get; set; }

        /// <summary>
        /// Recupera ou define o perfil.
        /// </summary>
        public virtual Perfil Perfil { get; set; }

        /// <summary>
        /// Variavel auxiliar não mapeada.
        /// </summary>
        public virtual bool Associado { get; set; }
    }
}

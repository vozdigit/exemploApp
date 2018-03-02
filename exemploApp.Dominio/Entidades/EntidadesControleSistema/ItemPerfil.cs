using exemploApp.Dominio.Entidades.Enumeradores;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesControleSistema
{
    /// <summary>
    /// Classe que implementa a associação entre item e perfil.
    /// </summary>
    public class ItemPerfil : EntidadeId
    {
        /// <summary>
        /// Recupera ou define o perfil.
        /// </summary>
        public virtual Perfil Perfil { get; set; }

        /// <summary>
        /// Recupera ou define o item.
        /// </summary>
        public virtual Item Item { get; set; }

        /// <summary>
        /// Propriedade auxiliar para ajudar na associação.
        /// </summary>
        public virtual bool Associado { get; set; }

        /// <summary>
        /// Recupera ou define a autorizaçao para leitura.
        /// </summary>
        public virtual bool SN_Leitura { get; set; }

        /// <summary>
        /// Recupera ou define a autorizaçao para inclusão.
        /// </summary>
        public virtual bool SN_Inclusao { get; set; }

        /// <summary>
        /// Recupera ou define a autorizaçao para alteração.
        /// </summary>
        public virtual bool SN_Alteracao { get; set; }

        /// <summary>
        /// Recupera ou define a autorizaçao para exclusão.
        /// </summary>
        public virtual bool SN_Exclusao { get; set; }
    }
}

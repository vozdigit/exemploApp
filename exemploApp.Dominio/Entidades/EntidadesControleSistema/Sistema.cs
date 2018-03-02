using exemploApp.Dominio.Entidades.Enumeradores;
using System.Collections.Generic;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesControleSistema
{
    /// <summary>
    /// Classe que implementa o objeto Sistema.
    /// </summary>
    public class Sistema : EntidadeId
    {
        /// <summary>
        /// Cria a instancia de Sistema.
        /// </summary>
        public Sistema()
        {
            this.Modulos = new List<Modulo>();
            this.Perfis = new List<Perfil>();
        }

        /// <summary>
        /// Recupera ou define o nome do sistema.
        /// </summary>
        public virtual string NomeSistema { get; set; }

        /// <summary>
        /// Recupera ou define a sigla do sistema.
        /// </summary>
        public virtual string SiglaSistema { get; set; }

        /// <summary>
        /// Recupera ou define a Logo(fontawesome) do sistema.
        /// </summary>
        public virtual string LogoSistema { get; set; }

        /// <summary>
        /// Recupera ou define o status do sistema.
        /// </summary>
        public virtual EnumSituacao StatusSistema { get; set; }

        /// <summary>
        /// Recupera ou define os modulos do sistema.
        /// </summary>
        public virtual IList<Modulo> Modulos { get; set; }

        /// <summary>
        /// Recupera ou define os perfis do sistema.
        /// </summary>
        public virtual IList<Perfil> Perfis { get; set; }
    }
}

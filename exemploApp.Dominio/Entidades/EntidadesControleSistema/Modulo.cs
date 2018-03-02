using exemploApp.Dominio.Entidades.Enumeradores;
using System.Collections.Generic;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesControleSistema
{
    /// <summary>
    /// Classe que implementa os modulos do sistema.
    /// </summary>
    public class Modulo : EntidadeId
    {
        /// <summary>
        /// Cria a instancia de Modulo.
        /// </summary>
        public Modulo()
        {
            this.Menus = new List<Menu>();
        }

        /// <summary>
        /// Recupera ou define o sistema.
        /// </summary>
        public virtual Sistema Sistema { get; set; }

        /// <summary>
        /// Recupera ou define o nome do modulo.
        /// </summary>
        public virtual string NomeModulo { get; set; }

        /// <summary>
        /// Recupera ou define a sigla do modulo.
        /// </summary>
        public virtual string SiglaModulo { get; set; }

        /// <summary>
        /// Recupera ou define a logo do modulo.
        /// </summary>
        public virtual string LogoModulo { get; set; }

        /// <summary>
        /// Recupera ou define o status do modulo.
        /// </summary>
        public virtual EnumSituacao StatusModulo { get; set; }

        /// <summary>
        /// Recupera ou define a ordem do módulo.
        /// </summary>
        public virtual int OrdemModulo { get; set; }

        /// <summary>
        /// Recupera ou define os menus do módulo.
        /// </summary>
        public virtual IList<Menu> Menus { get; set; }
    }
}

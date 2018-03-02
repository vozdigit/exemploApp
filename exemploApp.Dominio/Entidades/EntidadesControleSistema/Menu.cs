using exemploApp.Dominio.Entidades.Enumeradores;
using System.Collections.Generic;
using Tykon.Base.Entidades;
using Tykon.Base.Helpers;

namespace exemploApp.Dominio.Entidades.EntidadesControleSistema
{
    /// <summary>
    /// Classe que implementa os menus do sistema.
    /// </summary>
    public class Menu : EntidadeId
    {
        /// <summary>
        /// Cria a instancia de menu.
        /// </summary>
        public Menu()
        {
            this.Itens = new List<Item>();
        }

        /// <summary>
        /// Recupera ou define o modulo.
        /// </summary>
        public virtual Modulo Modulo { get; set; }

        /// <summary>
        /// Recupera ou define o nome do menu.
        /// </summary>
        public virtual string NomeMenu { get; set; }

        /// <summary>
        /// Recupera ou define a logo do menu.
        /// </summary>
        public virtual string LogoMenu { get; set; }

        /// <summary>
        /// Recupera ou define o status do menu.
        /// </summary>
        public virtual EnumSituacao StatusMenu { get; set; }

        /// <summary>
        /// Recupera ou define os itens do menu.
        /// </summary>
        public virtual IList<Item> Itens { get; set; }

        /// <summary>
        /// Recupera o nome do m�dulo.
        /// </summary>
        [PropriedadeDerivada("Modulo", ListaPropriedades = new string[] { "NomeModulo" })]
        public virtual string NomeModulo
        {
            get
            {
                if (this.Modulo != null)
                {
                    return this.Modulo.NomeModulo;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Recupera ou define o sistema.
        /// </summary>
        public virtual Sistema Sistema { get; set; }

        /// <summary>
        /// Recupera ou define a ordem do menu.
        /// </summary>
        public virtual int OrdemMenu { get; set; }
    }
}

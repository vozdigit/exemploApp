using exemploApp.Dominio.Entidades.Enumeradores;
using System.Collections.Generic;
using Tykon.Base.Entidades;
using Tykon.Base.Helpers;

namespace exemploApp.Dominio.Entidades.EntidadesControleSistema
{
    /// <summary>
    /// Classe que implementa os itens de menu do sistema.
    /// </summary>
    public class Item : EntidadeId
    {
        /// <summary>
        /// Cria a instancia de item.
        /// </summary>
        public Item()
        {
            this.PerfisAssociadosAoItem = new List<ItemPerfil>();
        }

        /// <summary>
        /// Recupera ou define o menu.
        /// </summary>
        public virtual Menu Menu { get; set; }

        /// <summary>
        /// Recupera ou define a descricao do item.
        /// </summary>
        public virtual string DescricaoItem { get; set; }

        /// <summary>
        /// Recupera ou define o controlador do item.
        /// </summary>
        public virtual string Controladoritem { get; set; }

        /// <summary>
        /// Recupera ou define a logo do item.
        /// </summary>
        public virtual string LogoItem { get; set; }

        /// <summary>
        /// Recupera ou define o status do item.
        /// </summary>
        public virtual EnumSituacao StatusItem { get; set; }

        /// <summary>
        /// Recupera ou define lista de itens perfis associados.
        /// </summary>
        public virtual IList<ItemPerfil> PerfisAssociadosAoItem { get; set; }

        /// <summary>
        /// Propriedade aux nao mapeada.
        /// </summary>
        public virtual Sistema Sistema { get; set; }

        /// <summary>
        /// Recupera o nome do menu.
        /// </summary>
        [PropriedadeDerivada("Menu", ListaPropriedades = new string[] { "NomeMenu" })]
        public virtual string NomeMenu
        {
            get
            {
                if (this.Menu != null)
                {
                    return this.Menu.NomeMenu;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Recupera o nome do modulo.
        /// </summary>
        [PropriedadeDerivada("Menu", ListaPropriedades = new string[] { "NomeModulo" })]
        public virtual string NomeModulo
        {
            get
            {
                if (this.Menu != null)
                {
                    return this.Menu.NomeModulo;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Recupera ou define a ordem do item.
        /// </summary>
        public virtual int OrdemItem { get; set; }
    }
}

using System.Collections.Generic;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa as unidades da federação.
    /// </summary>
    public class UnidadeFederacao : EntidadeId
    {
        /// <summary>
        /// Cria a instancia de UF.
        /// </summary>
        public UnidadeFederacao()
        {
            this.Municipios = new List<Municipio>();
        }

        /// <summary>
        /// Recupera ou define a sigla da unidade da federação.
        /// </summary>
        public virtual string SiglaUF { get; set; }

        /// <summary>
        /// Recupera ou define o nome da unidade da federação.
        /// </summary>
        public virtual string NomeUF { get; set; }

        /// <summary>
        /// Recupera ou define os municipios da unidade da federação.
        /// </summary>
        public virtual IList<Municipio> Municipios { get; set; }
    }
}

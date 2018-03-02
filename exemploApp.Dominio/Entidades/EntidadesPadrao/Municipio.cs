using Tykon.Base.Entidades;
using Tykon.Base.Helpers;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa o Municipio.
    /// </summary>
    public class Municipio : EntidadeId
    {
        /// <summary>
        /// Recupera ou define a unidade da federação.
        /// </summary>
        public virtual UnidadeFederacao UF { get; set; }

        /// <summary>
        /// Recupera ou define o nome do municipio.
        /// </summary>
        public virtual string NomeMunicipio { get; set; }

        /// <summary>
        /// Recupera a sigla da Unidade da federacao.
        /// </summary>
        [PropriedadeDerivada("UF", ListaPropriedades = new string[] { "SiglaUF" })]
        public virtual string SiglaUF
        {
            get
            {
                if (this.UF != null)
                {
                    return this.UF.SiglaUF;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}

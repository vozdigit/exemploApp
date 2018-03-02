using exemploApp.Dominio.Entidades.Enumeradores;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa o Telefone.
    /// </summary>
    public class Telefone : EntidadeId
    {
        /// <summary>
        /// Recupera ou define o tipo do telefone.
        /// </summary>
        public virtual EnumTipoTelefone TipoTelefone { get; set; }

        /// <summary>
        /// Recupera ou define o DDD do telefone.
        /// </summary>
        public virtual int DDD { get; set; }

        /// <summary>
        /// Recupera ou define o Numero do Telefone.
        /// </summary>
        public virtual long NumeroTelefone { get; set; }

        /// <summary>
        /// Recupera ou define o numero completo do telefone para edi��o nas aplica��es.
        /// </summary>
        public virtual string NmroTelefoneCompleto
        {
            get
            {
                if (this.NumeroTelefone != 0)
                {
                    return this.DDD + this.NumeroTelefone.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                if (value != null)
                {
                    this.DDD = int.Parse(value.Substring(1, 2));
                    this.NumeroTelefone = long.Parse(value.Remove(0, 5).Replace("-", string.Empty));
                }
            }
        }

        /// <summary>
        /// Recupera ou define a Pessoa do Telefone.
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }

        /// <summary>
        /// Recupera ou define a Localidade do Telefone.
        /// </summary>
        public virtual Localidade Localidade { get; set; }
    }
}

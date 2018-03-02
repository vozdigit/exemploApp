using exemploApp.Dominio.Entidades.Enumeradores;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa o Endereco.
    /// </summary>
    public class Endereco : EntidadeId
    {
        /// <summary>
        /// Recupera ou define o tipo do endereço.
        /// </summary>
        public virtual EnumTipoEndereco TipoEndereco { get; set; }

        /// <summary>
        /// Recupera ou define a Pessoa do Endereço.
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }

        /// <summary>
        /// Recupera ou define a Localidade do Endereço.
        /// </summary>
        public virtual Localidade Localidade { get; set; }

        /// <summary>
        /// Recupera ou define o Logradouro.
        /// </summary>
        public virtual string Logradouro { get; set; }

        /// <summary>
        /// Recupera ou define o numero.
        /// </summary>
        public virtual string Numero { get; set; }

        /// <summary>
        /// Recupera ou define o complemento.
        /// </summary>
        public virtual string Complemento { get; set; }

        /// <summary>
        /// Recupera ou define o Nome do Bairro.
        /// </summary>
        public virtual string NomeBairro { get; set; }

        /// <summary>
        /// Recupera ou define o Municipio.
        /// </summary>
        public virtual Municipio Municipio { get; set; }

        /// <summary>
        /// Recupera ou define o CEP.
        /// </summary>
        public virtual long NumeroCEP { get; set; }

        /// <summary>
        /// Recupera ou define o CEP literal para edição nas aplicações.
        /// </summary>
        public virtual string CEPLiteral
        {
            get
            {
                if (this.NumeroCEP != 0)
                {
                    return this.NumeroCEP.ToString("00000000");
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
                    this.NumeroCEP = long.Parse(value.Replace("-", string.Empty));
                }
            }
        }
    }
}

using exemploApp.Dominio.Entidades.Enumeradores;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa o Endereço eletronico.
    /// </summary>
    public class EnderecoEletronico : EntidadeId
    {
        /// <summary>
        /// Recupera ou define o tipo do endereço eletronico.
        /// </summary>
        public virtual EnumTipoEnderecoEletronico TipoEnderecoEletronico { get; set; }

        /// <summary>
        /// Recupera ou define o endereço em si.
        /// </summary>
        public virtual string Endereco { get; set; }

        /// <summary>
        /// Recupera ou define a Pessoa.
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }

        /// <summary>
        /// Recupera ou define a Localidade.
        /// </summary>
        public virtual Localidade Localidade { get; set; }
    }
}

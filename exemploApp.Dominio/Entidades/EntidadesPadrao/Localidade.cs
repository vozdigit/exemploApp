using exemploApp.Dominio.Entidades.Enumeradores;
using System.Collections.Generic;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa a Localidade.
    /// </summary>
    public class Localidade : EntidadeId
    {
        /// <summary>
        /// Cria uma instancia de pessoa.
        /// </summary>
        public Localidade()
        {
            this.Telefones = new List<Telefone>();
            this.EnderecosFisicos = new List<Endereco>();
            this.EnderecosEletronicos = new List<EnderecoEletronico>();
        }

        /// <summary>
        /// Recupera ou define o tipo da localidade.
        /// </summary>
        public virtual EnumTipoLocalidade TipoLocalidade { get; set; }

        /// <summary>
        /// Recupera ou define os telefones da localidade.
        /// </summary>
        public virtual IList<Telefone> Telefones { get; set; }

        /// <summary>
        /// Recupera ou define os enderecos fisicos da localidade.
        /// </summary>
        public virtual IList<Endereco> EnderecosFisicos { get; set; }

        /// <summary>
        /// Recupera ou define os enderecos eletronicos da localidade.
        /// </summary>
        public virtual IList<EnderecoEletronico> EnderecosEletronicos { get; set; }
    }
}

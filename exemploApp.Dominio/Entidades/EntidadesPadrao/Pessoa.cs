using exemploApp.Dominio.Entidades.Enumeradores;
using System.Collections.Generic;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa a pessoa.
    /// </summary>
    public class Pessoa : EntidadeId
    {
        /// <summary>
        /// Cria uma instancia de pessoa.
        /// </summary>
        public Pessoa()
        {
            this.Telefones = new List<Telefone>();
            this.EnderecosFisicos = new List<Endereco>();
            this.EnderecosEletronicos = new List<EnderecoEletronico>();
        }

        /// <summary>
        /// Recupera ou define o tipo da pessoa.
        /// </summary>
        public virtual EnumTipoPessoa TipoPessoa { get; set; }

        /// <summary>
        /// Recupera ou define os telefones da pessoa.
        /// </summary>
        public virtual IList<Telefone> Telefones { get; set; }

        /// <summary>
        /// Recupera ou define os enderecos fisicos da pessoa.
        /// </summary>
        public virtual IList<Endereco> EnderecosFisicos { get; set; }

        /// <summary>
        /// Recupera ou define os enderecos eletronicos da pessoa.
        /// </summary>
        public virtual IList<EnderecoEletronico> EnderecosEletronicos { get; set; }
    }
}

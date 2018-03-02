using exemploApp.Dominio.Entidades.Enumeradores;
using System;
using System.Collections.Generic;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa a Pessoa Juridica.
    /// </summary>
    public class PessoaJuridica : EntidadeId
    {
        /// <summary>
        /// Cria uma instancia de pessoa juridica.
        /// </summary>
        public PessoaJuridica()
        {
            this.Responsaveis = new List<ResponsavelPessoaJuridica>();
        }

        /// <summary>
        /// Recupera ou define a Pessoa (Superclasse)
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }

        /// <summary>
        /// Recupera ou define a Razao Social.
        /// </summary>
        public virtual string RazaoSocial { get; set; }

        /// <summary>
        /// Recupera ou define o Nome Fantasia.
        /// </summary>
        public virtual string NomeFantasia { get; set; }

        /// <summary>
        /// Recupera ou define o Numero do CNPJ.
        /// </summary>
        public virtual long NumeroCNPJ { get; set; }

        /// <summary>
        /// Recupera ou define a inscrição estadual.
        /// </summary>
        public virtual string InscricaoEstadual { get; set; }

        /// <summary>
        /// Recupera ou define a inscricao municipal.
        /// </summary>
        public virtual string InscricaoMunicipal { get; set; }

        /// <summary>
        /// Recupera ou define a Matriz.
        /// </summary>
        public virtual PessoaJuridica Matriz { get; set; }

        /// <summary>
        /// Recupera ou define os responsaveis pela pessoa juridica.
        /// </summary>
        public virtual IList<ResponsavelPessoaJuridica> Responsaveis { get; set; }

        /// <summary>
        /// Recupera ou define o CNPJ literal para edição nas aplicações.
        /// </summary>
        public virtual string CNPJLiteral
        {
            get
            {
                if (this.NumeroCNPJ != 0)
                {
                    return this.NumeroCNPJ.ToString("00000000000000");
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
                    this.NumeroCNPJ = long.Parse(value.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty));
                }
            }
        }
    }
}

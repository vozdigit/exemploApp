using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using System;
using System.Collections.Generic;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa a Pessoa Física.
    /// </summary>
    public class PessoaFisica : EntidadeId
    {
        /// <summary>
        /// Cria uma instancia de pessoa fisica.
        /// </summary>
        public PessoaFisica()
        {
            this.Responsaveis = new List<ResponsavelPessoaFisica>();
        }

        /// <summary>
        /// Recupera ou define a Pessoa (SuperClasse)
        /// </summary>
        public virtual Pessoa Pessoa { get; set; }

        /// <summary>
        /// Recupera ou define o nome da Pessoa Física.
        /// </summary>
        public virtual string NomePessoa { get; set; }

        /// <summary>
        /// Recupera ou define a data de nascimento da Pessoa Física.
        /// </summary>
        public virtual DateTime? DtNascimento { get; set; }

        /// <summary>
        /// Recupera ou define o sexo da pessoa fisica.
        /// </summary>
        public virtual EnumSexo Sexo { get; set; }

        /// <summary>
        /// Recupera ou define o estado civil da pessoa fisica.
        /// </summary>
        public virtual EnumEstadoCivil EstadoCivil { get; set; }

        /// <summary>
        /// Recupera ou define o numero do cpf da pessoa fisica.
        /// </summary>
        public virtual long NumeroCPF { get; set; }

        /// <summary>
        /// Recupera ou define o numero do RG da pessoa fisica.
        /// </summary>
        public virtual long NumeroRG { get; set; }

        /// <summary>
        /// Recupera ou define a nacionalidade da pessoa fisica.
        /// </summary>
        public virtual string Nacionalidade { get; set; }

        /// <summary>
        /// Recupera ou define a naturalidade da pessoa fisica.
        /// </summary>
        public virtual string Naturalidade { get; set; }

        /// <summary>
        /// Recupera ou define os responsaveis pela pessoa fisica.
        /// </summary>
        public virtual IList<ResponsavelPessoaFisica> Responsaveis { get; set; }

        /// <summary>
        /// Recupera ou define o CPF literal para edição nas aplicações.
        /// </summary>
        public virtual string CPFLiteral
        {
            get
            {
                if (this.NumeroCPF != 0)
                {
                    return this.NumeroCPF.ToString("00000000000");
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
                    this.NumeroCPF = long.Parse(value.Replace(".", string.Empty).Replace("-", string.Empty));
                }
            }
        }
    }
}

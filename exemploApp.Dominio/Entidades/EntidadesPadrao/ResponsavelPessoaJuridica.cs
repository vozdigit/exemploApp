using exemploApp.Dominio.Entidades.Enumeradores;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa o responsavel pela pessoa juridica.
    /// </summary>
    public class ResponsavelPessoaJuridica : EntidadeId
    {
        /// <summary>
        /// Recupera ou define a pessoa juridica.
        /// </summary>
        public virtual PessoaJuridica PessoaJuridica { get; set; }

        /// <summary>
        /// Recupera ou define o nome do responsavel da pessoa juridica.
        /// </summary>
        public virtual string NomeResponsavel { get; set; }

        /// <summary>
        /// Recupera ou define o tipo do responsavel da pessoa juridica.
        /// </summary>
        public virtual EnumTipoResponsavelPessoaJuridica TipoResponsavelPessoaJuridica { get; set; }
    }
}

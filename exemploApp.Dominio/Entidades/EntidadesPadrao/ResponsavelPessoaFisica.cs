using exemploApp.Dominio.Entidades.Enumeradores;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesPadrao
{
    /// <summary>
    /// Classe que implementa o responsável pela pessoa fisica.
    /// </summary>
    public class ResponsavelPessoaFisica : EntidadeId
    {
        /// <summary>
        /// Recupera ou define a pessoa fisica.
        /// </summary>
        public virtual PessoaFisica PessoaFisica { get; set; }

        /// <summary>
        /// Recupera ou define o nome do responsavel.
        /// </summary>
        public virtual string NomeResponsavel { get; set; }

        /// <summary>
        /// Recupera ou define o tipo do responsavel de pessoa fisica.
        /// </summary>
        public virtual EnumTipoResponsavelPessoaFisica TipoResponsavelPessoaFisica { get; set; }
    }
}

using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoPessoaJuridica : ClassMap<PessoaJuridica>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoPessoaJuridica()
        {
            this.Schema("COSMOSS");
            this.Table("PESSOA_JURIDICA");

            Id(x => x.Id).Column("ID_PESSOA_JURIDICA").GeneratedBy.Identity();
            References(x => x.Pessoa).Column("ID_PESSOA").Cascade.All();
            Map(x => x.RazaoSocial).Column("RAZAO_SOCIAL");
            Map(x => x.NomeFantasia).Column("NOME_FANTASIA");
            Map(x => x.NumeroCNPJ).Column("NUMR_CNPJ");
            Map(x => x.InscricaoEstadual).Column("NUMR_INSCRICAO_ESTADUAL");
            Map(x => x.InscricaoMunicipal).Column("NUMR_INSCRICAO_MUNICIPAL");
            References(x => x.Matriz).Column("ID_MATRIZ").Cascade.All();
            HasMany(x => x.Responsaveis).KeyColumn("ID_PESSOA_JURIDICA").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

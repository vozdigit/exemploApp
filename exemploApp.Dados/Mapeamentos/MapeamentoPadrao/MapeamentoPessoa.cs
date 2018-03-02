using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoPessoa : ClassMap<Pessoa>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoPessoa()
        {
            this.Schema("COSMOSS");
            this.Table("PESSOA");

            Id(x => x.Id).Column("ID_PESSOA").GeneratedBy.Identity();
            Map(x => x.TipoPessoa).Column("TIPO_PESSOA").CustomType<CustomTypeEnum<EnumTipoPessoa>>();
            HasMany(x => x.Telefones).KeyColumn("ID_PESSOA").AsBag().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.EnderecosFisicos).KeyColumn("ID_PESSOA").AsBag().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.EnderecosEletronicos).KeyColumn("ID_PESSOA").AsBag().Cascade.AllDeleteOrphan().Inverse();
            ////HasOne(x => x.PessoaFisica).Constrained();
            ////HasOne(x => x.PessoaJuridica).Constrained();
        }
    }
}

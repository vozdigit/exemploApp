using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoLocalidade : ClassMap<Localidade>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoLocalidade()
        {
            this.Schema("COSMOSS");
            this.Table("LOCALIDADE");

            Id(x => x.Id).Column("ID_LOCALIDADE").GeneratedBy.Identity();
            Map(x => x.TipoLocalidade).Column("TIPO_LOCALIDADE").CustomType<CustomTypeEnum<EnumTipoLocalidade>>();
            HasMany(x => x.Telefones).KeyColumn("ID_LOCALIDADE").AsBag().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.EnderecosFisicos).KeyColumn("ID_LOCALIDADE").AsBag().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.EnderecosEletronicos).KeyColumn("ID_LOCALIDADE").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

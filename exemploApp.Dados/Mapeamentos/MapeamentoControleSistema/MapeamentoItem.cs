using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoControleSistema
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoItem : ClassMap<Item>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoItem()
        {
            this.Schema("COSMOSS");
            this.Table("ITEM");

            Id(x => x.Id).Column("ID_ITEM").GeneratedBy.Identity();
            References(x => x.Menu).Column("ID_MENU").Cascade.None();
            Map(x => x.DescricaoItem).Column("DESC_ITEM");
            Map(x => x.Controladoritem).Column("DESC_CONTROLADOR");
            Map(x => x.LogoItem).Column("LOGO_ITEM");
            Map(x => x.OrdemItem).Column("ORDEM_ITEM");
            Map(x => x.StatusItem).Column("STAT_ITEM").CustomType<CustomTypeEnum<EnumSituacao>>();
            HasMany(x => x.PerfisAssociadosAoItem).KeyColumn("ID_ITEM").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

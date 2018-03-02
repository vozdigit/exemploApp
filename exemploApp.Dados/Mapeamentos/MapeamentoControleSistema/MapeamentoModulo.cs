using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoControleSistema
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoModulo : ClassMap<Modulo>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoModulo()
        {
            this.Schema("COSMOSS");
            this.Table("MODULO");

            Id(x => x.Id).Column("ID_MODULO").GeneratedBy.Identity();
            References(x => x.Sistema).Column("ID_SISTEMA").Cascade.None();
            Map(x => x.NomeModulo).Column("NOME_MODULO");
            Map(x => x.SiglaModulo).Column("SIGL_MODULO");
            Map(x => x.LogoModulo).Column("LOGO_MODULO");
            Map(x => x.StatusModulo).Column("STAT_MODULO").CustomType<CustomTypeEnum<EnumSituacao>>();
            Map(x => x.OrdemModulo).Column("ORDEM_MODULO");
            HasMany(x => x.Menus).KeyColumn("ID_MODULO").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

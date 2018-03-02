using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoControleSistema
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoSistema : ClassMap<Sistema>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoSistema()
        {
            this.Schema("COSMOSS");
            this.Table("SISTEMA");

            Id(x => x.Id).Column("ID_SISTEMA").GeneratedBy.Identity();
            Map(x => x.NomeSistema).Column("NOME_SISTEMA");
            Map(x => x.SiglaSistema).Column("SIGL_SISTEMA");
            Map(x => x.LogoSistema).Column("LOGO_SISTEMA");
            Map(x => x.StatusSistema).Column("STAT_SISTEMA").CustomType<CustomTypeEnum<EnumSituacao>>();
            HasMany(x => x.Modulos).KeyColumn("ID_SISTEMA").AsBag().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.Perfis).KeyColumn("ID_SISTEMA").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

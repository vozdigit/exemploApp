using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoControleSistema
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoMenu : ClassMap<Menu>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoMenu()
        {
            this.Schema("COSMOSS");
            this.Table("MENU");

            Id(x => x.Id).Column("ID_MENU").GeneratedBy.Identity();
            References(x => x.Modulo).Column("ID_MODULO").Cascade.None();
            Map(x => x.NomeMenu).Column("NOME_MENU");
            Map(x => x.LogoMenu).Column("LOGO_MENU");
            Map(x => x.StatusMenu).Column("STAT_MENU").CustomType<CustomTypeEnum<EnumSituacao>>();
            Map(x => x.OrdemMenu).Column("ORDEM_MENU");
            HasMany(x => x.Itens).KeyColumn("ID_MENU").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoControleSistema
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoItemPerfil : ClassMap<ItemPerfil>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoItemPerfil()
        {
            this.Schema("COSMOSS");
            this.Table("ITEM_PERFIL");

            Id(x => x.Id).Column("ID_ITEM_PERFIL").GeneratedBy.Identity();
            References(x => x.Perfil).Column("ID_PERFIL").Cascade.None();
            References(x => x.Item).Column("ID_ITEM").Cascade.None();
            Map(x => x.SN_Leitura).Column("SN_LEITURA").CustomType<CustomTypeEnumBooleanoBanco>();
            Map(x => x.SN_Inclusao).Column("SN_INCLUSAO").CustomType<CustomTypeEnumBooleanoBanco>();
            Map(x => x.SN_Alteracao).Column("SN_ALTERACAO").CustomType<CustomTypeEnumBooleanoBanco>();
            Map(x => x.SN_Exclusao).Column("SN_EXCLUSAO").CustomType<CustomTypeEnumBooleanoBanco>();
        }
    }
}

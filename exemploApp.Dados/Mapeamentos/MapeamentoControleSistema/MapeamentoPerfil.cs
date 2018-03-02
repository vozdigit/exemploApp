using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoControleSistema
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoPerfil : ClassMap<Perfil>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoPerfil()
        {
            this.Schema("COSMOSS");
            this.Table("PERFIL");

            Id(x => x.Id).Column("ID_PERFIL").GeneratedBy.Identity();
            References(x => x.Sistema).Column("ID_SISTEMA").Cascade.None();
            Map(x => x.NomePerfil).Column("NOME_PERFIL");
            Map(x => x.StatusPerfil).Column("STAT_PERFIL").CustomType<CustomTypeEnum<EnumSituacao>>();
            Map(x => x.Pontuacao).Column("PONTUACAO");
            HasMany(x => x.ItensAssociadosAoPerfil).KeyColumn("ID_PERFIL").AsBag().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.UsuariosAssociadosAoPerfil).KeyColumn("ID_PERFIL").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoControleSistema
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoUsuarioSistema : ClassMap<UsuarioSistema>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoUsuarioSistema()
        {
            this.Schema("COSMOSS");
            this.Table("USUARIO");

            Id(x => x.Id).Column("ID_USUARIO").GeneratedBy.Identity();
            References(x => x.PessoaFisica).Column("ID_PESSOA_FISICA").Cascade.All();
            Map(x => x.Login).Column("LOGIN_USUARIO");
            Map(x => x.StatusUsuario).Column("STAT_USUARIO").CustomType<CustomTypeEnum<EnumSituacao>>();
            HasMany(x => x.Credenciais).KeyColumn("ID_USUARIO").AsBag().Cascade.AllDeleteOrphan().Inverse();
            HasMany(x => x.PerfisAssociadosAoUsuario).KeyColumn("ID_USUARIO").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

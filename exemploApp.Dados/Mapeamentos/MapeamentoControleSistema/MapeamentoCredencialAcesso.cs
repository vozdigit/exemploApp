using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoControleSistema
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoCredencialAcesso : ClassMap<CredencialAcesso>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoCredencialAcesso()
        {
            this.Schema("COSMOSS");
            this.Table("CREDENCIAL_ACESSO");

            Id(x => x.Id).Column("ID_CREDENCIAL").GeneratedBy.Identity();
            References(x => x.UsuarioSistema).Column("ID_USUARIO").Cascade.None();
            Map(x => x.Senha).Column("DESC_SENHA");
            Map(x => x.LembreteSenha).Column("DESC_LEMBRETE_SENHA");
            Map(x => x.DtStatusCredencial).Column("DT_STAT_CREDENCIAL");
            Map(x => x.StatusCredencial).Column("STAT_CREDENCIAL").CustomType<CustomTypeEnum<EnumSituacao>>();
        }
    }
}

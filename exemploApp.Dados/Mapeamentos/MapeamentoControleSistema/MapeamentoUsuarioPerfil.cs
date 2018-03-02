using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoControleSistema
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoUsuarioPerfil : ClassMap<UsuarioPerfil>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoUsuarioPerfil()
        {
            this.Schema("COSMOSS");
            this.Table("USUARIO_PERFIL");

            Id(x => x.Id).Column("ID_USUARIO_PERFIL").GeneratedBy.Identity();
            References(x => x.UsuarioSistema).Column("ID_USUARIO").Cascade.None();
            References(x => x.Perfil).Column("ID_PERFIL").Cascade.None();
        }
    }
}

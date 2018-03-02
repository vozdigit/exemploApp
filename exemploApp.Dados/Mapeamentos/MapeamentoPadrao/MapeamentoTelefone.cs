using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoTelefone : ClassMap<Telefone>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoTelefone()
        {
            this.Schema("COSMOSS");
            this.Table("TELEFONE");

            Id(x => x.Id).Column("ID_TELEFONE").GeneratedBy.Identity();
            Map(x => x.TipoTelefone).Column("TIPO_TELEFONE").CustomType<CustomTypeEnum<EnumTipoTelefone>>();
            Map(x => x.DDD).Column("NUMR_DDD");
            Map(x => x.NumeroTelefone).Column("NUMR_TELEFONE");
            References(x => x.Pessoa).Column("ID_PESSOA").Cascade.None();
            References(x => x.Localidade).Column("ID_LOCALIDADE").Cascade.None();
        }
    }
}

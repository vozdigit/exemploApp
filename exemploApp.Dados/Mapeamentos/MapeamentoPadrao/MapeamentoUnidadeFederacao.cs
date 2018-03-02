using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoUnidadeFederacao : ClassMap<UnidadeFederacao>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoUnidadeFederacao()
        {
            this.Schema("GLOBAL");
            this.Table("UF");

            Id(x => x.Id).Column("ID_UF").GeneratedBy.Identity();
            Map(x => x.SiglaUF).Column("SIGL_UF");
            Map(x => x.NomeUF).Column("NOME_UF");
            HasMany(x => x.Municipios).KeyColumn("ID_UF").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

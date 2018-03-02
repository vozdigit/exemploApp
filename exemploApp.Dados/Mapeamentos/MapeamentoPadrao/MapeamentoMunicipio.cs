using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoMunicipio : ClassMap<Municipio>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoMunicipio()
        {
            this.Schema("GLOBAL");
            this.Table("MUNICIPIO");

            Id(x => x.Id).Column("ID_MUNICIPIO").GeneratedBy.Identity();
            References(x => x.UF).Column("ID_UF").Cascade.None();
            Map(x => x.NomeMunicipio).Column("NOME_MUNICIPIO");
        }
    }
}

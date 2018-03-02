using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoEndereco : ClassMap<Endereco>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoEndereco()
        {
            this.Schema("COSMOSS");
            this.Table("ENDERECO");

            Id(x => x.Id).Column("ID_ENDERECO").GeneratedBy.Identity();
            Map(x => x.TipoEndereco).Column("TIPO_ENDERECO").CustomType<CustomTypeEnum<EnumTipoEndereco>>();
            References(x => x.Pessoa).Column("ID_PESSOA").Cascade.None();
            References(x => x.Localidade).Column("ID_LOCALIDADE").Cascade.None();
            Map(x => x.Logradouro).Column("DESC_LOGRADOURO");
            Map(x => x.Numero).Column("NUMR_ENDERECO");
            Map(x => x.Complemento).Column("DESC_COMPLEMENTO");
            Map(x => x.NomeBairro).Column("NOME_BAIRRO");
            Map(x => x.NumeroCEP).Column("NUMR_CEP");
            References(x => x.Municipio).Column("ID_MUNICIPIO").Cascade.None();
        }
    }
}

using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoEnderecoEletronico : ClassMap<EnderecoEletronico>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoEnderecoEletronico()
        {
            this.Schema("COSMOSS");
            this.Table("ENDERECO_ELETRONICO");

            Id(x => x.Id).Column("ID_ENDERECO_ELETRONICO").GeneratedBy.Identity();
            Map(x => x.TipoEnderecoEletronico).Column("TIPO_ENDERECO_ELETRONICO").CustomType<CustomTypeEnum<EnumTipoEnderecoEletronico>>();
            Map(x => x.Endereco).Column("DESC_ENDERECO_ELETRONICO");
            References(x => x.Pessoa).Column("ID_PESSOA").Cascade.None();
            References(x => x.Localidade).Column("ID_LOCALIDADE").Cascade.None();
        }
    }
}

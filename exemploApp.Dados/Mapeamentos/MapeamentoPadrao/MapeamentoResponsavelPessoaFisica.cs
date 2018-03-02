using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoResponsavelPessoaFisica : ClassMap<ResponsavelPessoaFisica>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoResponsavelPessoaFisica()
        {
            this.Schema("COSMOSS");
            this.Table("RESPONSAVEL_PESSOA_FISICA");

            Id(x => x.Id).Column("ID_RESPONSAVEL_PF").GeneratedBy.Identity();
            References(x => x.PessoaFisica).Column("ID_PESSOA_FISICA").Cascade.None();
            Map(x => x.NomeResponsavel).Column("NOME_RESPONSAVEL_PF");
            Map(x => x.TipoResponsavelPessoaFisica).Column("TIPO_RESPONSAVEL_PF").CustomType<CustomTypeEnum<EnumTipoResponsavelPessoaFisica>>();
        }
    }
}

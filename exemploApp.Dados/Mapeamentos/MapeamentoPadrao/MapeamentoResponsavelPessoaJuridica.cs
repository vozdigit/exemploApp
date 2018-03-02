using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoResponsavelPessoaJuridica : ClassMap<ResponsavelPessoaJuridica>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoResponsavelPessoaJuridica()
        {
            this.Schema("COSMOSS");
            this.Table("RESPONSAVEL_PESSOA_JURIDICA");

            Id(x => x.Id).Column("ID_RESPONSAVEL_PJ").GeneratedBy.Identity();
            References(x => x.PessoaJuridica).Column("ID_PESSOA_JURIDICA").Cascade.None();
            Map(x => x.NomeResponsavel).Column("NOME_RESPONSAVEL_PJ");
            Map(x => x.TipoResponsavelPessoaJuridica).Column("TIPO_RESPONSAVEL_PJ").CustomType<CustomTypeEnum<EnumTipoResponsavelPessoaJuridica>>();
        }
    }
}

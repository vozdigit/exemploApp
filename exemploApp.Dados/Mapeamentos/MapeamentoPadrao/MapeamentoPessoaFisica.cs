using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using FluentNHibernate.Mapping;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos.MapeamentoPadrao
{
    /// <summary>
    /// Classe para mapeamento entre entidade de negócio e a tabela no banco de dados.
    /// </summary>
    public class MapeamentoPessoaFisica : ClassMap<PessoaFisica>
    {
        /// <summary>
        /// Cria uma instância do mapeamento.
        /// </summary>
        public MapeamentoPessoaFisica()
        {
            this.Schema("COSMOSS");
            this.Table("PESSOA_FISICA");

            Id(x => x.Id).Column("ID_PESSOA_FISICA").GeneratedBy.Identity();
            References(x => x.Pessoa).Column("ID_PESSOA").Cascade.All();
            Map(x => x.NomePessoa).Column("NOME_PESSOA");
            Map(x => x.Sexo).Column("INFO_SEXO").CustomType<CustomTypeEnum<EnumSexo>>();
            Map(x => x.EstadoCivil).Column("INFO_ESTADO_CIVIL").CustomType<CustomTypeEnum<EnumEstadoCivil>>();
            Map(x => x.NumeroCPF).Column("NUMR_CPF");
            Map(x => x.DtNascimento).Column("DATA_NASCIMENTO");
            Map(x => x.NumeroRG).Column("NUMR_RG");
            Map(x => x.Nacionalidade).Column("INFO_NACIONALIDADE");
            Map(x => x.Naturalidade).Column("INFO_NATURALIDADE");
            HasMany(x => x.Responsaveis).KeyColumn("ID_PESSOA_FISICA").AsBag().Cascade.AllDeleteOrphan().Inverse();
        }
    }
}

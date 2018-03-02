namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa os tipos de entidades administradas por OS.
    /// </summary>
    public enum EnumTipoEntidadeAdministrada
    {
        /// <summary>
        /// Retorna o valor enquanto a entidade for uma empresa.
        /// </summary>
        EMPRESA_FORMALIZADA = 'E',

        /// <summary>
        /// Retorna o valor enquanto a entidade for uma instituição sem cnpj, ONG ou localidade.
        /// </summary>
        INSTITUICAO = 'I'
    }
}

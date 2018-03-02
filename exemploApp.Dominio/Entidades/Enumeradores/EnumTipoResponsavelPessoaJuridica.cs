namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa os tipos de responsáveis de pessoas jurídicas.
    /// </summary>
    public enum EnumTipoResponsavelPessoaJuridica
    {
        /// <summary>
        /// Retorna ou define quando o responsável pela pessoa jurídica é um diretor.
        /// </summary>
        DIRETOR = 'D',

        /// <summary>
        /// Retorna ou define quando o responsável pela pessoa jurídica é um gerente.
        /// </summary>
        GERENTE = 'G',

        /// <summary>
        /// Retorna ou define quando o responsável pela pessoa jurídica é um presidente.
        /// </summary>
        PRESIDENTE = 'P',

        /// <summary>
        /// Retorna ou define quando o responsável pela pessoa jurídica é um sócio.
        /// </summary>
        SOCIO = 'S'
    }
}

namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa os tipos de telefone.
    /// </summary>
    public enum EnumTipoTelefone
    {
        /// <summary>
        /// Retorna ou define quando um telefone for do tipo comercial.
        /// </summary>
        COMERCIAL = 'C',

        /// <summary>
        /// Retorna ou define quando um telefone for do tipo fax.
        /// </summary>
        FAX = 'F',

        /// <summary>
        /// Retorna ou define quando um telefone for de um localidade.
        /// </summary>
        LOCALIDADE = 'L',

        /// <summary>
        /// Retorna ou define quando um telefone for do tipo celular.
        /// </summary>
        MOVEL_CELULAR = 'M',

        /// <summary>
        /// Retorna ou define quando um telefone for do tipo residencial.
        /// </summary>
        RESIDENCIAL = 'R'
    }
}

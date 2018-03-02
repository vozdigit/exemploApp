namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa os tipos de endereços fisicos existentes.
    /// </summary>
    public enum EnumTipoEndereco
    {
        /// <summary>
        /// Retorna o valor enquanto endereço de cobrança.
        /// </summary>
        COBRANCA = 'F',

        /// <summary>
        /// Retorna o valor enquanto endereço comercial.
        /// </summary>
        COMERCIAL = 'C',

        /// <summary>
        /// Retorna o valor enquanto endereço para entrega.
        /// </summary>
        ENTREGA = 'E',

        /// <summary>
        /// Retorna o valor enquanto endereço residencial.
        /// </summary>
        RESIDENCIAL = 'R'
    }
}

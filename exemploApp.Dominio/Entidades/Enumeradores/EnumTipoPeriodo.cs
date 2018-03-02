namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa os tipos de período para lançamento e aferição.
    /// </summary>
    public enum EnumTipoPeriodo
    {
        /// <summary>
        /// Recupera o tipo periodo enquanto diário.
        /// </summary>
        DIARIO = 'D',

        /// <summary>
        /// Recupera o tipo periodo enquanto semanal.
        /// </summary>
        SEMANAL = 'W',

        /// <summary>
        /// Recupera o tipo periodo enquanto quinzenal.
        /// </summary>
        QUINZENAL = 'Q',

        /// <summary>
        /// Recupera o tipo periodo enquanto mensal.
        /// </summary>
        MENSAL = 'M',

        /// <summary>
        /// Recupera o tipo periodo enquanto trimestral.
        /// </summary>
        TRIMESTRAL = 'T',

        /// <summary>
        /// Recupera o tipo periodo enquanto semestral.
        /// </summary>
        SEMESTRAL = 'S',

        /// <summary>
        /// Recupera o tipo periodo enquanto anual.
        /// </summary>
        ANUAL = 'A',
    }
}

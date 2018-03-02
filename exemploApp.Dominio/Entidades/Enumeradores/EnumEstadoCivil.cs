namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa os Estados Civís da legislação brasileira.
    /// </summary>
    public enum EnumEstadoCivil
    {
        /// <summary>
        /// Recupera o estado cívil enquanto solteiro(a).
        /// </summary>
        SOLTEIRO_SOLTEIRA = 'S',

        /// <summary>
        /// Recupera o estado cívil enquanto casado(a).
        /// </summary>
        CASADO_CASADA = 'C',

        /// <summary>
        /// Recupera o estado cívil enquanto separado(a).
        /// </summary>
        SEPARADO_SEPARADA = 'L',

        /// <summary>
        /// Recupera o estado cívil enquanto divorciado(a).
        /// </summary>
        DIVORCIADO_DIVORCIADA = 'D',

        /// <summary>
        /// Recupera o estado cívil enquanto viúvo(a).
        /// </summary>
        VIUVO_VIUVA = 'V'
    }
}

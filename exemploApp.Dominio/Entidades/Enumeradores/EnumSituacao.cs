namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa situações padrões do dia a dia.
    /// </summary>
    public enum EnumSituacao
    {
        /// <summary>
        /// Retorna ou define quando a situação estiver ativa.
        /// </summary>
        ATIVO = 'A',

        /// <summary>
        /// Retorna ou define quando a situação estiver inativa.
        /// </summary>
        INATIVO = 'I',

        /// <summary>
        /// Retorna ou define quando a situação estiver suspensa.
        /// </summary>
        SUSPENSO = 'S',

        /// <summary>
        /// Retorna ou define quando a situação estiver bloqueada.
        /// </summary>
        BLOQUEADO = 'B',

        /// <summary>
        /// Retorna ou define quando a situação estiver em espera.
        /// </summary>
        EM_ESPERA = 'E',

        /// <summary>
        /// Retorna ou define quando a situação estiver pendente.
        /// </summary>
        PENDENTE = 'P',

        /// <summary>
        /// Retorna ou define quando a situação estiver concluída.
        /// </summary>
        CONCLUIDO = 'C',

        /// <summary>
        /// Retorna ou define quando a situação estiver fechada.
        /// </summary>
        FECHADO = 'F',

        /// <summary>
        /// Retorna ou define quando a situação estiver fechada.
        /// </summary>
        REABERTO = 'R'
    }
}

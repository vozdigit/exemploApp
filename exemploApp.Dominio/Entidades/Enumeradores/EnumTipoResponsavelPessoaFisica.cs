namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa os tipos de responsáveis por uma pessoa física.
    /// </summary>
    public enum EnumTipoResponsavelPessoaFisica
    {
        /// <summary>
        /// Retorna ou define enquanto o responsavel é um avô ou avó.
        /// </summary>
        AVO = 'A',

        /// <summary>
        /// Retorna ou define enquanto o responsavel é um irmão ou irmã.
        /// </summary>
        IRMAO_IRMA = 'I',

        /// <summary>
        /// Retorna ou define enquanto o responsavel é uma mãe.
        /// </summary>
        MAE = 'M',

        /// <summary>
        /// Retorna ou define enquanto o responsavel é um pai.
        /// </summary>
        PAI = 'P',

        /// <summary>
        /// Retorna ou define enquanto o responsavel é um tio ou tia.
        /// </summary>
        TIO_TIA = 'T',

        /// <summary>
        /// Retorna ou define enquanto o responsavel é de outro tipo não especificado.
        /// </summary>
        OUTRO = 'O'
    }
}

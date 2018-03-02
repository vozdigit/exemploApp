namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador responsável por definir a abrangência de análise de um indicador.
    /// </summary>
    public enum EnumTipoAbrangenciaIndicador
    {
        /// <summary>
        /// Retorna o valor enquanto a abrangêncida do indicador for apenas setorial.
        /// </summary>
        SETORIAL = 'S',

        /// <summary>
        /// Retorna o valor enquanto a abrangência do indicador for da empresa em geral.
        /// </summary>
        EMPRESA = 'E'
    }
}

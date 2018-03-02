using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que controla o tipo da ocorrencia.
    /// </summary>
    public enum EnumTipoOcorrencia
    {
        /// <summary>
        /// Retorna o tipo enquanto ativo.
        /// </summary>
        PRIMARIA = 'P',

        /// <summary>
        /// Retorna o tipo enquanto receptivo.
        /// </summary>
        REINCIDENTE = 'R',

        /// <summary>
        /// Retorna o tipo nao aplica.
        /// </summary>
        NAO_APLICA = 'N'
    }
}

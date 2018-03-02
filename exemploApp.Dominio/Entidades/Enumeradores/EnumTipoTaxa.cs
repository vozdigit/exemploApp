using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa os tipos de taxa.
    /// </summary>
    public enum EnumTipoTaxa
    {
        /// <summary>
        /// Retorna ou define quando PERCENTUAL.
        /// </summary>
        PERCENTUAL = 'P',

        /// <summary>
        /// Retorna ou define quando INTEIRO.
        /// </summary>
        INTEIRO = 'I',
    }
}

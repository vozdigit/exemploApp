using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador responsavel por determinar a origem do manifesto.
    /// </summary>
    public enum EnumIniciativaManifesto
    {
        /// <summary>
        /// Retorna o tipo enquanto ativo.
        /// </summary>
        ATIVO = 'A',

        /// <summary>
        /// Retorna o tipo enquanto receptivo.
        /// </summary>
        RECEPTIVO = 'R'
    }
}

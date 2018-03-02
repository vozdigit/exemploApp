using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que controla os tipos de manifestantes.
    /// </summary>
    public enum EnumTipoManifestante
    {
        /// <summary>
        /// Retorna o tipo enquanto acompanhante.
        /// </summary>
        ACOMPANHANTE = 'A',

        /// <summary>
        /// Retorna o tipo enquanto paciente.
        /// </summary>
        PACIENTE = 'P'
    }
}

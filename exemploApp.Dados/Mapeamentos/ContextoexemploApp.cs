using FluentNHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tykon.Base.Persistencia;

namespace exemploApp.Dados.Mapeamentos
{
    /// <summary>
    /// Representa um contexto de dados relacionado ao NHibernate.
    /// </summary>
    public class ContextoexemploApp : Contexto
    {
        /// <summary>
        /// Configuração utilizada ara a persistência dos dados.
        /// </summary>
        /// <value>
        /// Retorna a configuração.
        /// </value>
        protected override ConfiguracaoPersistencia Configuracao
        {
            get
            {
                return new ConfiguracaoPersistencia("exemploApp.Dados");
            }
        }
    }
}

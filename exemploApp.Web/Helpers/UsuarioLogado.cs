using System.Configuration;
using System.Web;
using Tykon.Base.Entidades;

namespace exemploApp.Web.Helpers
{
    /// <summary>
    /// Helper para o usuário logado.
    /// </summary>
    public class UsuarioLogado : IUsuarioLogado
    {
        /// <summary>
        /// O nome do usuário logado.
        /// </summary>
        /// <value>
        /// O valor do nome do usuário logado.
        /// </value>
        public string Nome
        {
            get
            {
                var usuarioHistorico = ConfigurationManager.AppSettings["UsuarioHistorico"];
                if (usuarioHistorico == null)
                {
                    return (HttpContext.Current == null || HttpContext.Current.User == null) ? string.Empty : HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    return usuarioHistorico;
                }
            }
        }
    }
}

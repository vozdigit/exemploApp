using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Servicos;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
using exemploApp.Web.Models;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using Tykon.Web.Helpers;
using Tykon.Web.Models;

namespace exemploApp.Web.Controllers
{
    /// <summary>
    /// Sobrescrevendo comportamento padrão do login controller.
    /// </summary>
    public class LoginController : Tykon.Web.Controllers.LoginController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        public LoginController()
            : base(MvcApplication.Fabrica)
        {
        }

        /// <summary>
        /// Tratar o usuário via intranet.
        /// </summary>
        /// <returns>Tela do usuário padrão.</returns>
        [Route("exemploApp/control")]
        public ActionResult TratarUsuario()
        {
            return this.TratarUsuarioPadrao();
        }

        /// <summary>
        /// Validar o usuário.
        /// </summary>
        /// <param name="usuariomodel">O usuário para validação.</param>
        /// <returns>True caso seja válido, falso caso contrário.</returns>
        protected override bool ValidarUsuario(Usuario usuariomodel)
        {
            UsuarioSistema usuariosistema = this.ConsultaLoginInformado(usuariomodel);

            if (usuariosistema != null)
            {
                return usuariosistema.SenhaAtiva.Trim() == usuariomodel.Senha.Trim();
            }

            return false;
        }

        /// <summary>
        /// Preparas the usuario sessao.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        protected override void PreparaUsuarioSessao(Usuario usuario)
        {
            UsuarioexemploApp UsuarioexemploApp = new UsuarioexemploApp();
            UsuarioexemploApp.PreencherInformacoesBasicas(usuario);

            this.Session[FWConstantes.ChaveSessaoUsuario] = UsuarioexemploApp;

            FormsAuthentication.SetAuthCookie(usuario.Login, false);
        }

        /// <summary>
        /// Consulta o login digitado.
        /// </summary>
        /// <param name="usuariomodel">o usuário digitado no login.</param>
        /// <returns>O usuário encontrado ou nulo.</returns>
        private UsuarioSistema ConsultaLoginInformado(Usuario usuariomodel)
        {
            using (var svc = MvcApplication.Fabrica.Resolva<IServicoUsuarioSistema>())
            {
                return svc.ConsultarUsuarioPorLoginOuCpf(usuariomodel.Login);
            }
        }
    }
}

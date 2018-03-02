using exemploApp.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tykon.Base.Helpers;
using Tykon.Web;

namespace exemploApp.Web
{
    /// <summary>
    /// Handle para quando a aplicação startar.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Instância de fabrica.
        /// </summary>
        private static IFabrica fabrica;

        /// <summary>
        /// Objeto que irá possuir a isntância de fabrica.
        /// </summary>
        /// <value>
        /// O objeto de fábrica.
        /// </value>
        public static IFabrica Fabrica
        {
            get
            {
                return fabrica;
            }

            private set
            {
                fabrica = value;
            }
        }

        /// <summary>
        /// Comportamento padrão para quand a aplicação starta.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.DefaultNamespaces.Add("exemploApp.Web.Controllers");
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
            Fabrica = new Fabrica();
        }

        /// <summary>
        /// As ações para quando a aplicações for finalizada.
        /// </summary>
        protected void Application_End()
        {
            Fabrica.Dispose();
        }
    }
}

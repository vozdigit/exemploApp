using System.Configuration;

namespace exemploApp.Web.Helpers
{
    /// <summary>
    /// Helper com as chaves das configurações do sistema.
    /// </summary>
    public static class HelperConfiguracao
    {
        /// <summary>
        /// Obtém a chave do sistema para montagem do menu.
        /// </summary>
        /// <value>
        /// A chave do sistema para configuração do menu.
        /// </value>
        public static string ChaveIntranet
        {
            get
            {
                return ConfigurationManager.AppSettings["ChaveIntranet"];
            }
        }

        /// <summary>
        /// Obtém a url dos serviços para configuração do menu.
        /// </summary>
        /// <value>
        /// A url para a api de serviços do menu.
        /// </value>
        public static string UrlMenu
        {
            get
            {
                return ConfigurationManager.AppSettings["UrlMenu"];
            }
        }

        /// <summary>
        /// Obtém a sigla do sistema.
        /// </summary>
        /// <value>
        /// A sigla do sistema cadastrada.
        /// </value>
        public static string SiglaSistema
        {
            get
            {
                return ConfigurationManager.AppSettings["SiglaSistema"];
            }
        }
    }
}

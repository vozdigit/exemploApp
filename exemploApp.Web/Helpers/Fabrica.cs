using exemploApp.Dados.Mapeamentos;
using Tykon.Base.Helpers;
using Tykon.Fabricas;

namespace exemploApp.Web.Helpers
{
    /// <summary>
    /// Implementação para a fábrica.
    /// </summary>
    public class Fabrica : FWFabricaBase, IFabrica
    {
        /// <summary>
        /// Cria uma nova instância da classe <see cref="Fabrica"/>.
        /// </summary>
        public Fabrica()
            : base("exemploApp.Dados", "exemploApp.Servico", new ContextoexemploApp(), () => new UsuarioLogado())
        {
        }
    }
}

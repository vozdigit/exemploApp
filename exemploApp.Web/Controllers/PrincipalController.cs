using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
using exemploApp.Web.Helpers;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Entidades;
using Tykon.Web;
using Tykon.Web.Helpers;
using Tykon.Web.Models;

namespace exemploApp.Web.Controllers
{
    /// <summary>
    /// Controller da tela principal.
    /// </summary>
    [AjaxAuthorize]
    public class PrincipalController : Tykon.Web.Controllers.PrincipalController
    {
        /// <summary>
        /// Carregar o menu de acordo com o perfil.
        /// </summary>
        /// <param name="codigoModulo">O código do modulo.</param>
        /// <returns>Configuração do menu.</returns>
        protected override Tykon.Web.Models.ConfiguracaoMenu CarregarMenu(int? codigoModulo)
        {
            var configuracaoMenu = new ConfiguracaoMenu();
            List<Modulo> modulosUsuario;
            Modulo modulo;
            UsuarioSistema usuarioLogado = this.RecuperaUsuarioLogado();
            modulosUsuario = this.RetornaModulosAssociadosAoUsuario(usuarioLogado);
            var itensAutorizadosUsuario = this.RetornaTodosItensDoUsuario(usuarioLogado);

            if (codigoModulo.HasValue)
            {
                using (var svc = MvcApplication.Fabrica.Resolva<IServicoModulo>())
                {
                    modulo = svc.ConsultaPorId(codigoModulo.Value);

                    this.CarregaArvoreModulo(modulo, configuracaoMenu, itensAutorizadosUsuario);
                }
            }
            else
            {
                modulo = modulosUsuario.OrderBy(x => x.OrdemModulo).FirstOrDefault();

                this.CarregaArvoreModulo(modulo, configuracaoMenu, itensAutorizadosUsuario);
            }

            configuracaoMenu.Modulos = this.PreparaListaDeModulosUsuario(modulosUsuario);

            this.Session["NomeUsuarioLogado"] = usuarioLogado.PessoaFisica.NomePessoa.ToUpper();
            this.Session["LoginUsuario"] = usuarioLogado.Login;
            this.Session["CodigoModulo"] = configuracaoMenu.CodigoPerfil;

            return configuracaoMenu;
        }

        /// <summary>
        /// Retorna o modulos que o usuário tem acesso.
        /// </summary>
        /// <param name="usuarioLogado">O usuario do sistema.</param>
        /// <returns>O modulo a ser acessado.</returns>
        private List<Modulo> RetornaModulosAssociadosAoUsuario(UsuarioSistema usuarioLogado)
        {
            List<Modulo> listagemModulos = new List<Modulo>();

            foreach (var perfil in usuarioLogado.PerfisAssociadosAoUsuario)
            {
                foreach (var itemAssociado in perfil.Perfil.ItensAssociadosAoPerfil)
                {
                    if (listagemModulos.Where(x => x.Id == itemAssociado.Item.Menu.Modulo.Id).Count() == 0)
                    {
                        listagemModulos.Add(itemAssociado.Item.Menu.Modulo);
                    }
                }
            }

            return listagemModulos;
        }

        /// <summary>
        /// Retorna a lista de itens do usuário.
        /// </summary>
        /// <param name="usuarioLogado">o Usuário autenticado.</param>
        /// <returns>Lista de itens do usuário.</returns>
        private List<Item> RetornaTodosItensDoUsuario(UsuarioSistema usuarioLogado)
        {
            List<Item> listagemItens = new List<Item>();

            foreach (var itemPerfil in usuarioLogado.PerfisAssociadosAoUsuario)
            {
                foreach (var item in itemPerfil.Perfil.ItensAssociadosAoPerfil)
                {
                    if (listagemItens.Where(x => x.Id == item.Item.Id).Count() == 0)
                    {
                        listagemItens.Add(item.Item);
                    }
                }
            }

            return listagemItens;
        }

        /// <summary>
        /// Carrega a arvore do modulo com menus e itens.
        /// </summary>
        /// <param name="modulo">O módulo a ser carregado.</param>
        /// <param name="configuracaoMenu">A configuração de menu a ser preenchida.</param>
        /// <param name="itensAutorizadosUsuario">A lista de itens autorizadas para o usuário.</param>
        private void CarregaArvoreModulo(Modulo modulo, ConfiguracaoMenu configuracaoMenu, List<Item> itensAutorizadosUsuario)
        {
            var configuracaoGrupoMenu = new ConfiguracaoGrupoMenu();
            var configuracaoItemMenu = new ConfiguracaoItemMenu();
            int contadorGrupoMenu = 0;

            if (modulo != null)
            {
                if (modulo.Menus.Any())
                {
                    foreach (var menu in modulo.Menus.OrderBy(x => x.OrdemMenu))
                    {
                        contadorGrupoMenu++;
                        configuracaoGrupoMenu = new ConfiguracaoGrupoMenu();
                        configuracaoGrupoMenu.NomeGrupo = menu.NomeMenu;
                        configuracaoGrupoMenu.Icone = menu.LogoMenu;
                        configuracaoGrupoMenu.CodigoGrupo = contadorGrupoMenu.ToString();

                        foreach (var item in menu.Itens)
                        {
                            if (itensAutorizadosUsuario.Where(x => x.Id == item.Id).OrderBy(x => x.OrdemItem).Count() > 0)
                            {
                                configuracaoItemMenu = new ConfiguracaoItemMenu();
                                configuracaoItemMenu.CodigoItem = item.Id.ToString();
                                configuracaoItemMenu.NomeItem = item.DescricaoItem;
                                configuracaoItemMenu.DescricaoItem = item.DescricaoItem;
                                configuracaoItemMenu.Controladora = item.Controladoritem;
                                configuracaoItemMenu.LogoItem = item.LogoItem;
                                configuracaoItemMenu.Acessos = "IACE";

                                configuracaoGrupoMenu.Items.Add(configuracaoItemMenu);
                            }
                        }

                        configuracaoMenu.Grupos.Add(configuracaoGrupoMenu);
                    }

                    configuracaoMenu.CodigoPerfil = modulo.Id.ToString();
                }
            }
        }

        /// <summary>
        /// Preparação da lista de módulos disponíveis para o usuário.
        /// </summary>
        /// <param name="listaModuloSistema">Lista de modulo do sistema.</param>
        /// <returns>Lista de modulos do usuário.</returns>
        private List<ConfiguracaoModulos> PreparaListaDeModulosUsuario(List<Modulo> listaModuloSistema)
        {
            List<ConfiguracaoModulos> listaModulosModel = new List<ConfiguracaoModulos>();

            foreach (var moduloSistema in listaModuloSistema)
            {
                listaModulosModel.Add(new ConfiguracaoModulos { CodigoModulo = moduloSistema.Id, NomeModulo = moduloSistema.NomeModulo, IconeModulo = moduloSistema.LogoModulo, PosicaoModulo = moduloSistema.OrdemModulo });
            }

            return listaModulosModel;
        }

        /// <summary>
        /// Obtem dados do sistema atual.
        /// </summary>
        /// <param name="siglaSistema">A Sigla do sistema.</param>
        /// <returns>O Sistema atual e suas informações.</returns>
        private Sistema ObtemDadosSistema(string siglaSistema)
        {
            using (var svc = MvcApplication.Fabrica.Resolva<IServicoSistema>())
            {
                return svc.ConsultaPorId(1);
            }
        }

        /// <summary>
        /// Recuperas the usuario logado.
        /// </summary>
        /// <returns>O usuário do sistema que está logado.</returns>
        private UsuarioSistema RecuperaUsuarioLogado()
        {
            var usuariomodel = Session[Tykon.Web.Helpers.FWConstantes.ChaveSessaoUsuario] as Tykon.Web.Models.Usuario;
            UsuarioSistema usuarioLogado = new UsuarioSistema();

            using (var svc = MvcApplication.Fabrica.Resolva<IServicoUsuarioSistema>())
            {
                usuarioLogado = svc.ConsultarUsuarioPorLoginOuCpf(usuariomodel.Login);
            }

            return usuarioLogado;
        }
    }
}

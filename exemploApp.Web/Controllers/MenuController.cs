using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
using exemploApp.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Tykon.Base.Helpers;
using Tykon.Web;
using Tykon.Web.Models;

namespace exemploApp.Web.Controllers
{
    /// <summary>
    /// Controlador que gerencia os menus do sistema.
    /// </summary>
    public class MenuController : ControladorBaseexemploApp<IServicoMenu, Menu>
    {
        /// <summary>
        /// Nome da Funcionalidade.
        /// </summary>
        protected override string NomeFuncionalidade
        {
            get
            {
                return "Menus";
            }
        }

        /// <summary>
        /// Filtra os menus existentes.
        /// </summary>
        /// <param name="nomeMenu">O nome do menu.</param>
        /// <returns>Lista Menus mediante filtro.</returns>
        public ActionResult FiltrarMenus(string nomeMenu)
        {
            var listaMaterializada = new List<Menu>();

            using (var servico = this.Servico())
            {
                var listagem = servico.Listar();
                var propriedades = this.ConfiguracaoGridProvider().Select(x => x.Propriedade).ToList();

                listaMaterializada = listagem.ClonaListaPropriedadesEspecificas(propriedades).ToList();
            }

            var retorno = new ConfiguracaoGrid() { Itens = listaMaterializada, };

            return this.SerializaJson(retorno);
        }

        /// <summary>
        /// Prepara tela de novo.
        /// </summary>
        protected override void PreparaTelaNovo()
        {
            this.ListarModulos();
            base.PreparaTelaNovo();
        }

        /// <summary>
        /// Prepara tela de edição.
        /// </summary>
        protected override void PreparaTelaEdicao()
        {
            this.ListarModulos();
            base.PreparaTelaEdicao();
        }

        /// <summary>
        /// Obtem o objeto persistido.
        /// </summary>
        /// <param name="objetoGridConvertido">O objeto Menu</param>
        /// <returns>Objeto da grid atualizado.</returns>
        protected override Menu ObterObjetoEdicaoPersistido(Menu objetoGridConvertido)
        {
            using (var servico = this.Servico())
            {
                var menu = servico.ConsultaPorId(objetoGridConvertido.Id);
                menu.Sistema = this.ObterSistemaAtual();

                return menu;
            }
        }

        /// <summary>
        /// Injeta particularidades que o objeto Menu novo já deve carregar consigo.
        /// </summary>
        /// <returns>Objeto novo preparado.</returns>
        protected override Menu ObjetoNovo()
        {
            var menu = new Menu();
            menu.Sistema = this.ObterSistemaAtual();
            menu.StatusMenu = EnumSituacao.ATIVO;

            return menu;
        }

        /// <summary>
        /// Prepara o objeto para inclusão.
        /// </summary>
        /// <param name="objeto">O objeto Perfil</param>
        /// <returns>Objeto alterado antes da inclusão.</returns>
        protected override Menu PreparaObjetoAdicao(Menu objeto)
        {
            objeto.StatusMenu = EnumSituacao.ATIVO;
            return base.PreparaObjetoAdicao(objeto);
        }

        /// <summary>
        /// Configurações para a grid de listagem.
        /// </summary>
        /// <returns>Retorna as configurações para a grid.</returns>
        protected override IList<ConfiguracaoColunas> ConfiguracaoGridProvider()
        {
            var configuracao = new List<ConfiguracaoColunas>();
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Id", Propriedade = "Id", Oculta = true });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Nome do Módulo", Propriedade = "NomeModulo" });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Descrição Menu", Propriedade = "NomeMenu" });

            return configuracao;
        }
    }
}

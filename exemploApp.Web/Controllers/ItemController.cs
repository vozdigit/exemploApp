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
    /// Controlador que gerencia os itens de menu.
    /// </summary>
    public class ItemController : ControladorBaseexemploApp<IServicoItem, Item>
    {
        /// <summary>
        /// Nome da Funcionalidade.
        /// </summary>
        protected override string NomeFuncionalidade
        {
            get
            {
                return "Itens";
            }
        }

        /// <summary>
        /// Filtra os itens de menu existentes.
        /// </summary>
        /// <param name="nomeItem">O nome do item.</param>
        /// <returns>Lista itens de menu mediante filtro.</returns>
        public ActionResult FiltrarItens(string nomeItem)
        {
            var listaMaterializada = new List<Item>();

            using (var servico = this.Servico())
            {
                var listagem = servico.ListarItemPorNome(nomeItem);
                var propriedades = this.ConfiguracaoGridProvider().Select(x => x.Propriedade).ToList();

                listaMaterializada = listagem.ClonaListaPropriedadesEspecificas(propriedades).ToList();
            }

            var retorno = new ConfiguracaoGrid() { Itens = listaMaterializada, };

            return this.SerializaJson(retorno);
        }

        /// <summary>
        /// Carrega Menus.
        /// </summary>
        /// <param name="idModulo">O  identificador do Módulo</param>
        /// <param name="idItem">O  identificador do item</param>
        /// <returns>Menus Carregados</returns>
        public ActionResult CarregarMenus(int? idModulo, int? idItem)
        {
            using (var modulo = this.Fabrica.Resolva<IServicoModulo>())
            {
                if (idModulo.HasValue)
                {
                    ViewBag.Menus = modulo.ConsultaPorId(idModulo.Value).Menus;
                }
                else
                {
                    ViewBag.Menus = new List<Menu>();
                }
            }

            if (idItem == 0)
            {
                return this.PartialView("_Menus");
            }
            else
            {
                using (var svc = this.Servico())
                {
                    var item = svc.ConsultaPorId(idItem.Value);

                    return this.PartialView("_Menus", item);
                }
            }
        }

        /// <summary>
        /// Obtem o objeto persistido.
        /// </summary>
        /// <param name="objetoGridConvertido">O objeto item</param>
        /// <returns>Objeto da grid atualizado.</returns>
        protected override Item ObterObjetoEdicaoPersistido(Item objetoGridConvertido)
        {
            using (var servico = this.Servico())
            {
                var item = servico.ConsultaPorId(objetoGridConvertido.Id);
                item.Sistema = this.ObterSistemaAtual();

                return item;
            }
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
        /// Injeta particularidades que o objeto Item novo já deve carregar consigo.
        /// </summary>
        /// <returns>Objeto novo preparado.</returns>
        protected override Item ObjetoNovo()
        {
            var item = new Item();
            item.Sistema = this.ObterSistemaAtual();
            item.StatusItem = EnumSituacao.ATIVO;

            return item;
        }

        /// <summary>
        /// Configurações para a grid de listagem.
        /// </summary>
        /// <returns>Retorna as configurações para a grid.</returns>
        protected override IList<ConfiguracaoColunas> ConfiguracaoGridProvider()
        {
            var configuracao = new List<ConfiguracaoColunas>();
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Id", Propriedade = "Id", Oculta = true });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Módulo", Propriedade = "NomeModulo" });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Menu", Propriedade = "NomeMenu" });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Item", Propriedade = "DescricaoItem" });

            return configuracao;
        }
    }
}

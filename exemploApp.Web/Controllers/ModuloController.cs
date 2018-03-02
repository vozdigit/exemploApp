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
    /// Controlador responsável por gerenciar os módulos de sistema.
    /// </summary>
    public class ModuloController : ControladorBaseexemploApp<IServicoModulo, Modulo>
    {
        /// <summary>
        /// Nome da Funcionalidade.
        /// </summary>
        protected override string NomeFuncionalidade
        {
            get
            {
                return "Módulo";
            }
        }

        /// <summary>
        /// Filtra os módulos existentes.
        /// </summary>
        /// <param name="nomeModulo">O nome do módulo.</param>
        /// <returns>Lista Módulos mediante filtro.</returns>
        public ActionResult FiltrarModulos(string nomeModulo)
        {
            var listaMaterializada = new List<Modulo>();

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
        /// Obtem o objeto persistido.
        /// </summary>
        /// <param name="objetoGridConvertido">O objeto modulo</param>
        /// <returns>Objeto da grid atualizado.</returns>
        protected override Modulo ObterObjetoEdicaoPersistido(Modulo objetoGridConvertido)
        {
            using (var servico = this.Servico())
            {
                var modulo = servico.ConsultaPorId(objetoGridConvertido.Id);
                modulo.Sistema = this.ObterSistemaAtual();

                return modulo;
            }
        }

        /// <summary>
        /// Injeta particularidades que o objeto Modulo novo já deve carregar consigo.
        /// </summary>
        /// <returns>Objeto novo preparado.</returns>
        protected override Modulo ObjetoNovo()
        {
            var modulo = new Modulo();
            modulo.Sistema = this.ObterSistemaAtual();
            modulo.StatusModulo = EnumSituacao.ATIVO;

            return modulo;
        }

        /// <summary>
        /// Prepara o objeto para inclusão.
        /// </summary>
        /// <param name="objeto">O objeto modulo</param>
        /// <returns>Objeto alterado antes da inclusão.</returns>
        protected override Modulo PreparaObjetoAdicao(Modulo objeto)
        {
            objeto.StatusModulo = EnumSituacao.ATIVO;
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
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Sigla do Módulo", Propriedade = "SiglaModulo" });

            return configuracao;
        }
    }
}

using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
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
    /// Controlador que gerencia o sistema.
    /// </summary>
    public class SistemaController : ControladorBaseexemploApp<IServicoSistema, Sistema>
    {
        /// <summary>
        /// Nome da Funcionalidade.
        /// </summary>
        protected override string NomeFuncionalidade
        {
            get
            {
                return "Sistema";
            }
        }

        /// <summary>
        /// Filtra o sistemas existentes.
        /// </summary>
        /// <param name="nome">Nome do sistema.</param>
        /// <returns>Lista de sistemas mediante filtro.</returns>
        public ActionResult FiltrarSistemas(string nome)
        {
            var listaMaterializada = new List<Sistema>();

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
        /// Prepara o objeto para inclusão.
        /// </summary>
        /// <param name="objeto">O objeto Sistema</param>
        /// <returns>Objeto alterado antes da inclusão.</returns>
        protected override Sistema PreparaObjetoAdicao(Sistema objeto)
        {
            objeto.StatusSistema = EnumSituacao.ATIVO;
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
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Nome do Sistema", Propriedade = "NomeSistema" });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Sigla do Sistema", Propriedade = "SiglaSistema" });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Logo do Sistema", Propriedade = "LogoSistema" });

            return configuracao;
        }
    }
}

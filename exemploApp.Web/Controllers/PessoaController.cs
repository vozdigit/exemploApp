using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
using exemploApp.Dominio.Interfaces.Servicos.Padrao;
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
    /// Controlador responsável por pessoa.
    /// </summary>
    public class PessoaController : ControladorBaseexemploApp<IServicoPessoa, Pessoa>
    {
        /// <summary>
        /// Nome da Funcionalidade.
        /// </summary>
        protected override string NomeFuncionalidade
        {
            get
            {
                return "Pessoas";
            }
        }

        /// <summary>
        /// Filtra os itens de menu existentes.
        /// </summary>
        /// <param name="nomeItem">O nome do item.</param>
        /// <returns>Lista itens de menu mediante filtro.</returns>
        public ActionResult FiltrarItens(string nomeItem)
        {
            var listaMaterializada = new List<Pessoa>();

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
        /// Prepara objeto adição.
        /// </summary>
        /// <param name="objeto">O objeto</param>
        /// <returns>retorna o retorno que retornar.</returns>
        protected override Pessoa PreparaObjetoAdicao(Pessoa objeto)
        {
            objeto.Telefones[0].Pessoa = objeto;
            return base.PreparaObjetoAdicao(objeto);
        }

        /// <summary>
        /// Injeta particularidades que o objeto Modulo novo já deve carregar consigo.
        /// </summary>
        /// <returns>Objeto novo preparado.</returns>
        protected override Pessoa ObjetoNovo()
        {
            var pessoa = new Pessoa();
            pessoa.TipoPessoa = EnumTipoPessoa.PESSOA_FISICA;
            pessoa.Telefones.Add(new Telefone { DDD = 62, NumeroTelefone = 15665466, TipoTelefone = EnumTipoTelefone.RESIDENCIAL });

            return pessoa;
        }
    }
}

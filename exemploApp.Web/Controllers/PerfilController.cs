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
    /// Controlador responsável por gerenciar os perfis de sistema.
    /// </summary>
    public class PerfilController : ControladorBaseexemploApp<IServicoPerfil, Perfil>
    {
        /// <summary>
        /// Nome da Funcionalidade.
        /// </summary>
        protected override string NomeFuncionalidade
        {
            get
            {
                return "Perfil";
            }
        }

        /// <summary>
        /// Filtra os perfiss existentes.
        /// </summary>
        /// <param name="descPerfil">A descrição do perfil.</param>
        /// <returns>Lista Perfis mediante filtro.</returns>
        public ActionResult FiltrarPerfis(string descPerfil)
        {
            var listaMaterializada = new List<Perfil>();

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
        /// <param name="objetoGridConvertido">O objeto perfil</param>
        /// <returns>Objeto da grid atualizado.</returns>
        protected override Perfil ObterObjetoEdicaoPersistido(Perfil objetoGridConvertido)
        {
            using (var servico = this.Servico())
            {
                var perfil = servico.ConsultaPorId(objetoGridConvertido.Id);
                perfil.ItensAssociadosAoPerfil = this.PreparaListaItensPerfil(perfil);

                return perfil;
            }
        }

        /// <summary>
        /// Injeta particularidades que o objeto Perfil novo já deve carregar consigo.
        /// </summary>
        /// <returns>Objeto novo preparado.</returns>
        protected override Perfil ObjetoNovo()
        {
            var perfil = new Perfil();
            perfil.Sistema = this.ObterSistemaAtual();
            perfil.StatusPerfil = EnumSituacao.ATIVO;

            return perfil;
        }

        /// <summary>
        /// Prepara o objeto para inclusão.
        /// </summary>
        /// <param name="perfil">O objeto Perfil</param>
        /// <returns>Objeto alterado antes da inclusão.</returns>
        protected override Perfil PreparaObjetoAdicao(Perfil perfil)
        {
            perfil.StatusPerfil = EnumSituacao.ATIVO;

            foreach (var item in perfil.ItensAssociadosAoPerfil)
            {
                item.Perfil = perfil;
            }

            this.MantemApenasItensAssociados(perfil);

            return perfil;
        }

        /// <summary>
        /// Prepara o objeto para alteração.
        /// </summary>
        /// <param name="perfil">O objeto perfil.</param>
        /// <returns>Objeto antes da atualização.</returns>
        protected override Perfil PreparaObjetoAtualizacao(Perfil perfil)
        {
            perfil.StatusPerfil = EnumSituacao.ATIVO;

            foreach (var item in perfil.ItensAssociadosAoPerfil)
            {
                item.Perfil = perfil;
            }

            this.MantemApenasItensAssociados(perfil);

            return perfil;
        }

        /// <summary>
        /// Prepara objeto para exclusão.
        /// </summary>
        /// <param name="perfil">O objeto perfil.</param>
        /// <returns>Perfil deletado</returns>
        protected override Perfil PreparaObjetoExclusao(Perfil perfil)
        {
            using (var servico = this.Servico())
            {
                var perfilADeletar = servico.ConsultaPorId(perfil.Id);

                return perfilADeletar;
            }
        }

        /// <summary>
        /// Configurações para a grid de listagem.
        /// </summary>
        /// <returns>Retorna as configurações para a grid.</returns>
        protected override IList<ConfiguracaoColunas> ConfiguracaoGridProvider()
        {
            var configuracao = new List<ConfiguracaoColunas>();
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Id", Propriedade = "Id", Oculta = true });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Nome do Perfil", Propriedade = "NomePerfil" });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Pontuação do Perfil", Propriedade = "Pontuacao" });

            return configuracao;
        }

        /// <summary>
        /// Prepara lista de itens associados ou não ao perfil.
        /// </summary>
        /// <param name="perfil">o perfil do sistema.</param>
        /// <returns>Retorna lista de itens do perfil.</returns>
        private List<ItemPerfil> PreparaListaItensPerfil(Perfil perfil)
        {
            List<ItemPerfil> listaItemPerfil = new List<ItemPerfil>();
            ItemPerfil itemPerfilAux;
            bool associado, visualizacao, insercao, alteracao, exclusao;
            int idAssociacao;

            using (var svc = this.Fabrica.Resolva<IServicoItem>())
            {
                foreach (var item in svc.Listar())
                {
                    if (perfil.ItensAssociadosAoPerfil.Where(x => x.Item == item).Count() != 0)
                    {
                        associado = true;
                        itemPerfilAux = perfil.ItensAssociadosAoPerfil.Where(x => x.Item == item).SingleOrDefault();

                        idAssociacao = itemPerfilAux.Id;
                        visualizacao = itemPerfilAux.SN_Leitura;
                        insercao = itemPerfilAux.SN_Inclusao;
                        alteracao = itemPerfilAux.SN_Alteracao;
                        exclusao = itemPerfilAux.SN_Exclusao;
                    }
                    else
                    {
                        associado = false;
                        idAssociacao = 0;
                        visualizacao = false;
                        insercao = false;
                        alteracao = false;
                        exclusao = false;
                    }

                    listaItemPerfil.Add(new ItemPerfil { Id = idAssociacao, Perfil = perfil, Item = item, Associado = associado, SN_Leitura = visualizacao, SN_Inclusao = insercao, SN_Alteracao = alteracao, SN_Exclusao = exclusao });
                }
            }

            return listaItemPerfil;
        }

        /// <summary>
        /// Método auxiliar para manter vinculado ao perfil apenas os itens associados.
        /// </summary>
        /// <param name="perfil">o perfil do sistema.</param>
        private void MantemApenasItensAssociados(Perfil perfil)
        {
            for (int i = 0; i < perfil.ItensAssociadosAoPerfil.Count(); i++)
            {
                if (!perfil.ItensAssociadosAoPerfil[i].Associado)
                {
                    if (perfil.ItensAssociadosAoPerfil[i].Id != 0)
                    {
                        using (var svc = this.Fabrica.Resolva<IServicoItemPerfil>())
                        {
                            svc.Remover(perfil.ItensAssociadosAoPerfil[i]);
                        }
                    }

                    perfil.ItensAssociadosAoPerfil.Remove(perfil.ItensAssociadosAoPerfil[i]);
                    i--;
                }
            }
        }
    }
}

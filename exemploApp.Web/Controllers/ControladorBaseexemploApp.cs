using exemploApp.Dominio.Entidades;
using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Entidades.Enumeradores;
using exemploApp.Dominio.Interfaces.Servicos;
using exemploApp.Dominio.Interfaces.Servicos.ControleSistema;
using exemploApp.Web.Helpers;
using exemploApp.Web.Models;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Entidades;
using Tykon.Base.Servicos;
using Tykon.Web;
using Tykon.Web.Controllers;
using Tykon.Web.Helpers;

namespace exemploApp.Web.Controllers
{
    /// <summary>
    /// Controladora base do projeto apenas para centralizar a parametrização da fábrica.
    /// </summary>
    /// <typeparam name="TServico">O tipo de serviço da entidade de cadastro.</typeparam>
    /// <typeparam name="TEntidade">O tipo da entidade de cadastro.</typeparam>
    [AjaxAuthorize]
    public class ControladorBaseexemploApp<TServico, TEntidade> : ControladorBase<TServico, TEntidade>
        where TServico : IServico<TEntidade>
        where TEntidade : Entidade
    {
        /// <summary>
        /// Cria uma nova instância da classe <see cref="ControladorBaseexemploApp{TServico, TEntidade}"/>.
        /// </summary>
        public ControladorBaseexemploApp()
            : base(MvcApplication.Fabrica)
        {
        }

        /// <summary>
        /// Recupera o icone da funcionalidade.
        /// </summary>
        protected override string IconeFuncionalidade
        {
            get
            {
                string controlador = this.ControllerContext.RouteData.Values["controller"].ToString();

                using (var svc = this.Fabrica.Resolva<IServicoItem>())
                {
                    return svc.ConsultarItemPorControlador(controlador).LogoItem;
                }
            }
        }

        /// <summary>
        /// Sigla do Sistema.
        /// </summary>
        private string SiglaSistema
        {
            get
            {
                return HelperConfiguracao.SiglaSistema;
            }
        }

        /// <summary>
        /// Método Somentes numeros.
        /// </summary>
        /// <param name="texto">O texto para verificação.</param>
        /// <returns>Retorna somente os números.</returns>
        public string SomenteNumero(string texto)
        {
            string textoAuxiliar = string.Empty;
            if (!string.IsNullOrEmpty(texto))
            {
                foreach (char caracter in texto)
                {
                    if (char.IsDigit(caracter))
                    {
                        textoAuxiliar += caracter;
                    }
                }
            }

            return textoAuxiliar;
        }

        /// <summary>
        /// Consulta o login digitado.
        /// </summary>
        /// <returns>O usuário encontrado ou nulo.</returns>
        protected UsuarioSistema ConsultaUsuarioLogado()
        {
            using (var svc = MvcApplication.Fabrica.Resolva<IServicoUsuarioSistema>())
            {
                return svc.ConsultarUsuarioPorLoginOuCpf(this.Usuario.Login);
            }
        }

        /// <summary>
        /// Listar os meses.
        /// </summary>
        protected void ListarMeses()
        {
            var lista = new[]
            {
                new { NumMes = 1, Mes = "Janeiro" },
                new { NumMes = 2, Mes = "Fevereiro" },
                new { NumMes = 3, Mes = "Março" },
                new { NumMes = 4, Mes = "Abril" },
                new { NumMes = 5, Mes = "Maio" },
                new { NumMes = 6, Mes = "Junho" },
                new { NumMes = 7, Mes = "Julho" },
                new { NumMes = 8, Mes = "Agosto" },
                new { NumMes = 9, Mes = "Setembro" },
                new { NumMes = 10, Mes = "Outubro" },
                new { NumMes = 11, Mes = "Novembro" },
                new { NumMes = 12, Mes = "Dezembro" },
            }.ToList();

            ViewBag.Meses = lista;
        }

        /// <summary>
        /// Listar os nomes de meses.
        /// </summary>
        /// <param name="mes">Recebendo Numero do Mes</param>
        /// <returns>Nome do Mes.</returns>
        protected string ListarNomeMeses(int mes)
        {
            switch (mes)
            {
                case 1:
                    return "Janeiro";                    
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    return "Número do Mês Inexistente";
            }
        }

        /// <summary>
        /// Obtem o sistema Atual.
        /// </summary>
        /// <returns>Retorna as informações do sistema atual.</returns>
        protected Sistema ObterSistemaAtual()
        {
            using (var svc = this.Fabrica.Resolva<IServicoSistema>())
            {
                return svc.Listar().Where(x => x.SiglaSistema == this.SiglaSistema).SingleOrDefault();
            }
        }

        /// <summary>
        /// Lista os Módulos do Sistema.
        /// </summary>
        protected void ListarModulos()
        {
            using (var svc = this.Fabrica.Resolva<IServicoModulo>())
            {
                ViewBag.Modulos = svc.Listar().Where(x => x.Sistema.SiglaSistema == this.SiglaSistema).OrderBy(x => x.NomeModulo);
            }
        }

        /// <summary>
        /// Lista os tipos de Estado Civil do Sistema.
        /// </summary>
        protected void ListarEstadoCivil()
        {
            var lista = new[]
            {
                new { Chave = EnumEstadoCivil.SOLTEIRO_SOLTEIRA, Nome = "Solteiro(a)" },
                new { Chave = EnumEstadoCivil.CASADO_CASADA, Nome = "Casado(a)" },
                new { Chave = EnumEstadoCivil.SEPARADO_SEPARADA, Nome = "Separado(a)" },
                new { Chave = EnumEstadoCivil.DIVORCIADO_DIVORCIADA, Nome = "Divorciado(a)" },
                new { Chave = EnumEstadoCivil.VIUVO_VIUVA, Nome = "Viúvo(a)" }
            }.ToList();

            ViewBag.EstadoCivil = lista;
        }

        /// <summary>
        /// Lista sexo.
        /// </summary>
        protected void ListarSexo()
        {
            var lista = new[]
            {
                new { Chave = EnumSexo.MASCULINO, Nome = "Masculino" },
                new { Chave = EnumSexo.FEMININO, Nome = "Feminino" },
            }.ToList();

            ViewBag.Sexo = lista;
        }
    }
}

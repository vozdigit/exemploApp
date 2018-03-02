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
    /// Controlador responsavel por gerenciar o usuário do sistema.
    /// </summary>
    public class UsuarioSistemaController : ControladorBaseexemploApp<IServicoUsuarioSistema, UsuarioSistema>
    {
        /// <summary>
        /// Nome da Funcionalidade.
        /// </summary>
        protected override string NomeFuncionalidade
        {
            get
            {
                return "Usúarios do Sistema";
            }
        }

        /// <summary>
        /// Filtra os usuarios.
        /// </summary>
        /// <param name="loginOuCPF">O login ou cpf do usuário.</param>
        /// <param name="nomeOuParte">O nome do usuario.</param>
        /// <returns>Lista itens de menu mediante filtro.</returns>
        public ActionResult FiltrarUsuarios(string loginOuCPF, string nomeOuParte)
        {
            var listaMaterializada = new List<UsuarioSistema>();
            var listagem = new List<UsuarioSistema>();
            UsuarioSistema usuarioLogado = this.ConsultaUsuarioLogado();
            var perfisDoUsuario = usuarioLogado.PerfisAssociadosAoUsuario.Select(x => x.Perfil);
            int maximaPontuacaoUsuario = perfisDoUsuario.Max(x => x.Pontuacao);

            using (var servico = this.Servico())
            {
                if (!string.IsNullOrEmpty(loginOuCPF))
                {
                    var usuarioEncontrado = servico.ConsultarUsuarioPorLoginOuCpf(loginOuCPF, maximaPontuacaoUsuario);

                    if (usuarioEncontrado != null)
                    {
                        listagem.Add(usuarioEncontrado);
                    }
                }

                if (!listagem.Any() && string.IsNullOrEmpty(loginOuCPF))
                {
                    listagem = servico.ListarUsuarioPorNome(nomeOuParte, maximaPontuacaoUsuario);
                }

                var propriedades = this.ConfiguracaoGridProvider().Select(x => x.Propriedade).ToList();

                listaMaterializada = listagem.ClonaListaPropriedadesEspecificas(propriedades).ToList();
            }

            var retorno = new ConfiguracaoGrid() { Itens = listaMaterializada, };

            return this.SerializaJson(retorno);
        }

        /// <summary>
        /// Prepara a grid de municipios do componente de pesquisa.
        /// </summary>
        /// <returns>
        /// Retorna a lista de municípios.
        /// </returns>
        public ActionResult PreparaGridMunicipios()
        {
            var config = new ConfiguracaoGrid();
            var configuracao = new List<ConfiguracaoColunas>();
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Codigo", Propriedade = "Id", Oculta = true });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Município", Propriedade = "NomeMunicipio" });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "UF", Propriedade = "SiglaUF", Tamanho = 50 });
            config.Colunas = configuracao;
            config.Itens = new List<Municipio>();

            return this.SerializaJson(config);
        }

        /// <summary>
        /// Responsável em filtrar os Municipios.
        /// </summary>
        /// <param name="nomeMunicipio">The nome municipio.</param>
        /// <returns>
        /// Retorna o json para os municipios.
        /// </returns>
        public ActionResult FiltrarMunicipios(string nomeMunicipio)
        {
            var listaMaterializada = new List<Municipio>();

            using (var servico = this.Fabrica.Resolva<IServicoMunicipio>())
            {
                IList<Municipio> listagem = servico.Listar().Where(x => x.NomeMunicipio.ToUpper().Contains(nomeMunicipio.ToUpper())).ToList();

                var propriedades = new List<string>();
                propriedades.Add("Id");
                propriedades.Add("NomeMunicipio");
                propriedades.Add("SiglaUF");
                listaMaterializada = listagem.ClonaListaPropriedadesEspecificas(propriedades).ToList();
            }

            var retorno = new ConfiguracaoGrid() { Itens = listaMaterializada, };

            return this.SerializaJson(retorno);
        }

        /// <summary>
        /// Metodo inicial.
        /// </summary>
        /// <returns>View inicial carregada.</returns>
        protected override ActionResult InicioProvider()
        {
            return this.PartialView("Listagem", new List<UsuarioSistema>());
        }

        /// <summary>
        /// Preparação para novos cadastro.
        /// </summary>
        protected override void PreparaTelaNovo()
        {
            this.ListarEstadoCivil();
            this.ListarSexo();
            base.PreparaTelaNovo();
        }

        /// <summary>
        /// Preparação para Edição de cadastro.
        /// </summary>
        protected override void PreparaTelaEdicao()
        {
            this.ListarEstadoCivil();
            this.ListarSexo();
            base.PreparaTelaEdicao();
        }

        /// <summary>
        /// Obtem o objeto persistido.
        /// </summary>
        /// <param name="objetoGridConvertido">O objeto item</param>
        /// <returns>Objeto da grid atualizado.</returns>
        protected override UsuarioSistema ObterObjetoEdicaoPersistido(UsuarioSistema objetoGridConvertido)
        {
            using (var servico = this.Servico())
            {
                var usuario = servico.ConsultaPorId(objetoGridConvertido.Id);
                usuario.PerfisAssociadosAoUsuario = this.PreparaListaPerfisUsuario(usuario);

                return usuario;
            }
        }

        /// <summary>
        /// Injeta particularidades que o objeto Usuario novo já deve carregar consigo.
        /// </summary>
        /// <returns>Objeto novo preparado.</returns>
        protected override UsuarioSistema ObjetoNovo()
        {
            var novoUsuario = new UsuarioSistema();
            novoUsuario.PessoaFisica = new PessoaFisica();
            novoUsuario.PessoaFisica.Pessoa = new Pessoa();
            novoUsuario.PessoaFisica.Pessoa.TipoPessoa = EnumTipoPessoa.PESSOA_FISICA;
            novoUsuario.PessoaFisica.Pessoa.Telefones = this.PreparaListaTelefonesParaCadastro(novoUsuario);
            novoUsuario.PessoaFisica.Pessoa.EnderecosFisicos = this.PreparaListaEnderecosFisicosParaCadastro(novoUsuario);
            novoUsuario.PessoaFisica.Pessoa.EnderecosEletronicos = this.PreparaListaEnderecosEletronicosParaCadastro(novoUsuario);        
            ////novoUsuario.PessoaFisica.EstadoCivil = EnumEstadoCivil.SOLTEIRO_SOLTEIRA;  
            novoUsuario.Login = string.Empty;
            novoUsuario.Credenciais.Add(this.CredencialDoNovoUsuario(novoUsuario));
            novoUsuario.StatusUsuario = EnumSituacao.ATIVO;
            novoUsuario.PerfisAssociadosAoUsuario = this.PreparaListaPerfisUsuario(novoUsuario);

            return novoUsuario;
        }

        /// <summary>
        /// Prepara objeto para inclusão.
        /// </summary>
        /// <param name="usuarioSistema">o objeto usuário do sistema.</param>
        /// <returns>Objeto preparado.</returns>
        protected override UsuarioSistema PreparaObjetoAdicao(UsuarioSistema usuarioSistema)
        {
            this.MontaObjetoParaPersistir(usuarioSistema);
            usuarioSistema.PessoaFisica.Pessoa.TipoPessoa = EnumTipoPessoa.PESSOA_FISICA;
            usuarioSistema.StatusUsuario = EnumSituacao.ATIVO;

            return usuarioSistema;
        }

        /// <summary>
        /// Prepara objeto para atualização.
        /// </summary>
        /// <param name="usuarioSistema">O usuário a ser atualizado.</param>
        /// <returns>O usuário atualizado.</returns>
        protected override UsuarioSistema PreparaObjetoAtualizacao(UsuarioSistema usuarioSistema)
        {
            this.MontaObjetoParaPersistir(usuarioSistema);
            usuarioSistema.PessoaFisica.Pessoa.TipoPessoa = EnumTipoPessoa.PESSOA_FISICA;
            usuarioSistema.StatusUsuario = EnumSituacao.ATIVO;
            return usuarioSistema;
        }

        /// <summary>
        /// Prepara Objeto para Exclusao.
        /// </summary>
        /// <param name="usuarioSistema">O usuário do sistema.</param>
        /// <returns>O objeto excluído.</returns>
        protected override UsuarioSistema PreparaObjetoExclusao(UsuarioSistema usuarioSistema)
        {
            using (var servico = this.Servico())
            {
                var usuarioADeletar = servico.ConsultaPorId(usuarioSistema.Id);

                return usuarioADeletar;
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
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Nome do Usuario", Propriedade = "NomeUsuarioSistema" });
            configuracao.Add(new ConfiguracaoColunas() { NomeColuna = "Login", Propriedade = "Login" });

            return configuracao;
        }

        /// <summary>
        /// Carrega lista inicial de telefones do usuario do sistema.
        /// </summary>
        /// <param name="novoUsuario">o usuario a ser cadastrado.</param>
        /// <returns>Lista de telefones preparada pra uso.</returns>
        private List<Telefone> PreparaListaTelefonesParaCadastro(UsuarioSistema novoUsuario)
        {
            List<Telefone> listaDeTelefones = new List<Telefone>();

            listaDeTelefones.Add(new Telefone { Pessoa = novoUsuario.PessoaFisica.Pessoa, TipoTelefone = EnumTipoTelefone.RESIDENCIAL });
            listaDeTelefones.Add(new Telefone { Pessoa = novoUsuario.PessoaFisica.Pessoa, TipoTelefone = EnumTipoTelefone.MOVEL_CELULAR });
            listaDeTelefones.Add(new Telefone { Pessoa = novoUsuario.PessoaFisica.Pessoa, TipoTelefone = EnumTipoTelefone.MOVEL_CELULAR });

            return listaDeTelefones;
        }

        /// <summary>
        /// Carrega lista inicial de endereços físicos do usuario do sistema.
        /// </summary>
        /// <param name="novoUsuario">o usuario a ser cadastrado.</param>
        /// <returns>Lista de endereços fisicos preparada pra uso.</returns>
        private List<Endereco> PreparaListaEnderecosFisicosParaCadastro(UsuarioSistema novoUsuario)
        {
            List<Endereco> listaDeEnderecos = new List<Endereco>();

            listaDeEnderecos.Add(new Endereco
            {
                Pessoa = novoUsuario.PessoaFisica.Pessoa,
                ////Logradouro = "Avenida Circular Qd.51 Lt.06",
                ////Complemento = "Ao lado video locadora",
                ////NomeBairro = "Balneário Meia Ponte",
                Municipio = new Municipio(),
                ////NumeroCEP = 74590150,
                TipoEndereco = EnumTipoEndereco.RESIDENCIAL
            });

            return listaDeEnderecos;
        }

        /// <summary>
        /// Carrega lista inicial de endereços eletronicos do usuario do sistema.
        /// </summary>
        /// <param name="novoUsuario">o usuario a ser cadastrado.</param>
        /// <returns>Lista de enderecos eletronicos preparada pra uso.</returns>
        private List<EnderecoEletronico> PreparaListaEnderecosEletronicosParaCadastro(UsuarioSistema novoUsuario)
        {
            List<EnderecoEletronico> listaDeEnderecosEletronicos = new List<EnderecoEletronico>();

            listaDeEnderecosEletronicos.Add(new EnderecoEletronico { Pessoa = novoUsuario.PessoaFisica.Pessoa, TipoEnderecoEletronico = EnumTipoEnderecoEletronico.EMAIL });

            return listaDeEnderecosEletronicos;
        }

        /// <summary>
        /// Cria uma credencial para o usuário..
        /// </summary>
        /// <param name="novoUsuario">o usuario a ser cadastrado.</param>
        /// <returns>Credencial pronta para uso.</returns>
        private CredencialAcesso CredencialDoNovoUsuario(UsuarioSistema novoUsuario)
        {
            CredencialAcesso credencial = new CredencialAcesso();

            credencial.UsuarioSistema = novoUsuario;
            credencial.DtStatusCredencial = DateTime.Now;

            return credencial;
        }

        /// <summary>
        /// Montagem do objeto para Adição ou Atualização.
        /// </summary>
        /// <param name="usuarioSistema">O usuário a ser persistido.</param>
        private void MontaObjetoParaPersistir(UsuarioSistema usuarioSistema)
        {
            foreach (var cred in usuarioSistema.Credenciais)
            {
                cred.UsuarioSistema = usuarioSistema;
                cred.StatusCredencial = EnumSituacao.ATIVO;
            }

            foreach (var item in usuarioSistema.PessoaFisica.Pessoa.Telefones)
            {
                item.Pessoa = usuarioSistema.PessoaFisica.Pessoa;
            }

            foreach (var item in usuarioSistema.PessoaFisica.Pessoa.EnderecosFisicos)
            {
                item.Pessoa = usuarioSistema.PessoaFisica.Pessoa;
                item.TipoEndereco = EnumTipoEndereco.RESIDENCIAL;
            }

            foreach (var item in usuarioSistema.PessoaFisica.Pessoa.EnderecosEletronicos)
            {
                item.Pessoa = usuarioSistema.PessoaFisica.Pessoa;
            }

            foreach (var item in usuarioSistema.PerfisAssociadosAoUsuario)
            {
                item.UsuarioSistema = usuarioSistema;
            }

            this.MantemApenasPerfisAssociados(usuarioSistema);
        }

        /// <summary>
        /// Prepara lista de perfis associados ou não.
        /// </summary>
        /// <param name="usuarioSistema">o usuario do sistema.</param>
        /// <returns>Retorna lista de perfis do usuário.</returns>
        private List<UsuarioPerfil> PreparaListaPerfisUsuario(UsuarioSistema usuarioSistema)
        {
            List<UsuarioPerfil> listaUsuarioPerfil = new List<UsuarioPerfil>();
            UsuarioSistema usuarioLogado = this.ConsultaUsuarioLogado();
            var perfisDoUsuario = usuarioLogado.PerfisAssociadosAoUsuario.Select(x => x.Perfil);
            int maximaPontuacaoUsuario = perfisDoUsuario.Max(x => x.Pontuacao);

            bool associado;
            int idAssociacao;

            using (var svc = this.Fabrica.Resolva<IServicoPerfil>())
            {
                foreach (var perfil in svc.Listar().Where(x => x.Pontuacao <= maximaPontuacaoUsuario))
                {
                    if (usuarioSistema.PerfisAssociadosAoUsuario.Where(x => x.Perfil == perfil).Count() != 0)
                    {
                        associado = true;
                        idAssociacao = usuarioSistema.PerfisAssociadosAoUsuario.Where(x => x.Perfil == perfil).SingleOrDefault().Id;
                    }
                    else
                    {
                        associado = false;
                        idAssociacao = 0;
                    }

                    listaUsuarioPerfil.Add(new UsuarioPerfil { Id = idAssociacao, Perfil = perfil, UsuarioSistema = usuarioSistema, Associado = associado });
                }
            }

            return listaUsuarioPerfil;
        }

        /// <summary>
        /// Método auxiliar para manter vinculado ao usuário apenas os perfis associados.
        /// </summary>
        /// <param name="usuarioSistema">o usuário do sistema.</param>
        private void MantemApenasPerfisAssociados(UsuarioSistema usuarioSistema)
        {
            for (int i = 0; i < usuarioSistema.PerfisAssociadosAoUsuario.Count(); i++)
            {
                if (!usuarioSistema.PerfisAssociadosAoUsuario[i].Associado)
                {
                    if (usuarioSistema.PerfisAssociadosAoUsuario[i].Id != 0)
                    {
                        using (var svc = this.Fabrica.Resolva<IServicoUsuarioPerfil>())
                        {
                            svc.Remover(usuarioSistema.PerfisAssociadosAoUsuario[i]);
                        }
                    }

                    usuarioSistema.PerfisAssociadosAoUsuario.Remove(usuarioSistema.PerfisAssociadosAoUsuario[i]);
                    i--;
                }
            }
        }
    }
}

using exemploApp.Dominio.Entidades.EntidadesPadrao;
using exemploApp.Dominio.Entidades.Enumeradores;
using System.Collections.Generic;
using System.Linq;
using Tykon.Base.Entidades;
using Tykon.Base.Helpers;

namespace exemploApp.Dominio.Entidades.EntidadesControleSistema
{
    /// <summary>
    /// Classe que implementa o usuario do sistema.
    /// </summary>
    public class UsuarioSistema : EntidadeId
    {
        /// <summary>
        /// Cria a instancia de Usuario do Sistema.
        /// </summary>
        public UsuarioSistema()
        {
            this.Credenciais = new List<CredencialAcesso>();
            this.PerfisAssociadosAoUsuario = new List<UsuarioPerfil>();
        }

        /// <summary>
        /// Recupera ou define a pessoa fisica.
        /// </summary>
        public virtual PessoaFisica PessoaFisica { get; set; }

        /// <summary>
        /// Recupera ou define o login.
        /// </summary>
        public virtual string Login { get; set; }

        /// <summary>
        /// Retorna a senha ativa do usuário.
        /// </summary>
        public virtual string SenhaAtiva
        {
            get
            {
                string senha = string.Empty;

                if (this.Credenciais.Count > 0)
                {
                    foreach (var credencial in this.Credenciais)
                    {
                        if (credencial.StatusCredencial == EnumSituacao.ATIVO)
                        {
                            senha = credencial.Senha;
                            break;
                        }
                    }
                }
                else
                {
                    senha = string.Empty;
                }

                return senha;
            }
        }

        /// <summary>
        /// Recuepra ou define o Status do usuario.
        /// </summary>
        public virtual EnumSituacao StatusUsuario { get; set; }

        /// <summary>
        /// Recupra ou define lista de credenciais do usuario.
        /// </summary>
        public virtual IList<CredencialAcesso> Credenciais { get; set; }

        /// <summary>
        /// Recupera ou define os perfis associados ao usuário.
        /// </summary>
        public virtual IList<UsuarioPerfil> PerfisAssociadosAoUsuario { get; set; }

        /// <summary>
        /// Recupera o nome do usuario de sistema.
        /// </summary>
        [PropriedadeDerivada("PessoaFisica", ListaPropriedades = new string[] { "NomePessoa" })]
        public virtual string NomeUsuarioSistema
        {
            get
            {
                if (this.PessoaFisica != null)
                {
                    return this.PessoaFisica.NomePessoa;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Prop auxiliar utilizada na atribuição de perfis e consulta de usuarios.
        /// </summary>
        public virtual int Pontuacao { get; set; }

        /// <summary>
        /// Retorna o email ativo da pessoa.
        /// </summary>
        public virtual string ExibicaoComEmailAtivo
        {
            get
            {
                if (this.PessoaFisica != null)
                {
                    if (this.PessoaFisica.Pessoa != null)
                    {
                        if (this.PessoaFisica.Pessoa.EnderecosEletronicos.Where(x => x.TipoEnderecoEletronico == EnumTipoEnderecoEletronico.EMAIL).Any())
                        {
                            return string.Format("{0} ({1})", this.PessoaFisica.NomePessoa, this.PessoaFisica.Pessoa.EnderecosEletronicos.Where(x => x.TipoEnderecoEletronico == EnumTipoEnderecoEletronico.EMAIL).FirstOrDefault().Endereco);
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Propriedade auxiliar utilizada na alteração de senha do usuário 1.
        /// </summary>
        public virtual string SenhaAtualInformada { get; set; }

        /// <summary>
        /// Propriedade auxiliar utilizada na alteração de senha do usuário 2.
        /// </summary>
        public virtual string NovaSenha { get; set; }

        /// <summary>
        /// Propriedade auxiliar utilizada na alteração de senha do usuário 3.
        /// </summary>
        public virtual string ConfirmacaoNovaSenha { get; set; }
    }
}

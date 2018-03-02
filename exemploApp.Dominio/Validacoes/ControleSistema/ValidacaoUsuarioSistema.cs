using exemploApp.Dominio.Entidades.EntidadesControleSistema;
using exemploApp.Dominio.Interfaces.Repositorios.ControleSistema;
using FluentValidation;
using System.Linq;
using Tykon.Base.Validacoes;

namespace exemploApp.Dominio.Validacoes.ControleSistema
{
    /// <summary>
    /// Classe responsável pelas validações de regras de negócio.
    /// </summary>
    public class ValidacaoUsuarioSistema : ValidacaoEntidadeId<UsuarioSistema>
    {
        #region Variáveis

        /// <summary>
        /// O repositório de UsuarioSistema.
        /// </summary>
        private IRepositorioUsuarioSistema repositorioUsuarioSistema;

        #endregion

        #region Construtores

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidacaoUsuarioSistema"/> class.
        /// </summary>
        /// <param name="repositorioUsuarioSistema">The repositorio UsuarioSistema.</param>
        public ValidacaoUsuarioSistema(IRepositorioUsuarioSistema repositorioUsuarioSistema)
        {
            this.repositorioUsuarioSistema = repositorioUsuarioSistema;
        }

        /// <summary>
        /// Validadors the adicao.
        /// </summary>
        /// <returns>Retorna o objeto validação específico.</returns>
        public override IValidacao<UsuarioSistema> ValidadorAdicao()
        {
            this.AssinarRegraCPFExiste();       
            this.AssinarRegrLoginExiste();
            this.AssinarRegraPerfisVazio();
            return this;
        }

        /// <summary>
        /// Validador the atualizacao.
        /// </summary>
        /// <returns>Retorna o objetov validaçao atualizacao.</returns>
        public override IValidacao<UsuarioSistema> ValidadorAtualizacao()
        {
            this.AssinarRegraPerfisVazio();
            return this;
        }

        /// <summary>
        /// Validadors the alteracao dados pessoais usuario.
        /// </summary>
        /// <returns>Validação ao fazeer a alteração de senha</returns>
        public IValidacao<UsuarioSistema> ValidadorAlteracaoDadosPessoaisUsuario()
        {
            this.AssinarRegraSenhaAtualValida();
            this.AssinarRegraNovaSenhaEConfirmacaoConferem();
            this.AssinarRegraComprimentoDeSenha();
            return this;
        }

        /// <summary>
        /// Assinars the regra cpf usuario existe.
        /// </summary>
        public void AssinarRegraCPFExiste()
        {
            this.RuleFor(x => x)
                  .Must(this.VerificarExisteUsuarioExatamenteIgual)
                  .WithMessage("Já existe um Usuário com esse CPF.")
                  .When(x => x != null)
                  .WithName("CPFLiteral");
        }

        /// <summary>
        /// Assinar a regra de perfis vazios.
        /// </summary>
        public void AssinarRegraPerfisVazio()
        {
            this.RuleFor(x => x)
                  .Must(this.VerificarRegraUsuarioSemPerfil)
                  .WithMessage("Associe pelo menos um perfil ao usuário")
                  .When(x => x != null)
                  .WithName("Verifique guia Perfis Associados");
        }

        /// <summary>
        /// Assinars the regra cpf usuario existe.
        /// </summary>
        public void AssinarRegrLoginExiste()
        {
            this.RuleFor(x => x)
                  .Must(this.VerificarExisteUsuarioLoginExatamenteIgual)
                  .WithMessage("Já existe um Usuário com esse Login.")
                  .When(x => x != null)
                  .WithName("Login");
        }

        /// <summary>
        /// Assinars the regra senha atual valida.
        /// </summary>
        public void AssinarRegraSenhaAtualValida()
        {
            this.RuleFor(x => x)
                  .Must(this.VerificarSenhaAtualValida)
                  .WithMessage("Senha atual não confere.")
                  .When(x => x != null)
                  .WithName("Atenção!!");
        }

        /// <summary>
        /// Assinars the regra nova senha e confirmacao conferem.
        /// </summary>
        public void AssinarRegraNovaSenhaEConfirmacaoConferem()
        {
            this.RuleFor(x => x)
                  .Must(this.VerificarNovaSenhaEConfirmacaoConferem)
                  .WithMessage("Nova Senha e Confirmação não conferem.")
                  .When(x => x != null)
                  .WithName("Atenção!!");
        }

        /// <summary>
        /// Assinars the regra comprimento de senha.
        /// </summary>
        public void AssinarRegraComprimentoDeSenha()
        {
            this.RuleFor(x => x)
                  .Must(this.VerificarComprimentoDeSenha)
                  .WithMessage("A senha do usuário deve possuir entre 6 e 10 caracteres.")
                  .When(x => x != null)
                  .WithName("Atenção!!");
        }

        /// <summary>
        /// Verificars the senha atual valida.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns>Verdadeiro ou falso.</returns>
        private bool VerificarSenhaAtualValida(UsuarioSistema usuario)
        {
            if (!string.IsNullOrEmpty(usuario.SenhaAtualInformada))
            {
                return usuario.SenhaAtiva.Trim() == usuario.SenhaAtualInformada.Trim();
            }

            return true;
        }

        /// <summary>
        /// Verificars the nova senha e confirmacao conferem.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns>Verdadeiro ou falso.</returns>
        private bool VerificarNovaSenhaEConfirmacaoConferem(UsuarioSistema usuario)
        {
            return usuario.NovaSenha == usuario.ConfirmacaoNovaSenha;
        }

        /// <summary>
        /// Verificar se existe usuario.
        /// </summary>
        /// <param name="usuarioSistema">A UsuarioSistema.</param>
        /// <returns>Resultado logico da comparação</returns>
        private bool VerificarExisteUsuarioExatamenteIgual(UsuarioSistema usuarioSistema)
        {
            var usuario = this.repositorioUsuarioSistema.ConsultarUsuarioPorCpf(usuarioSistema.PessoaFisica.CPFLiteral);

            if (usuario != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verificar se existe usuario.
        /// </summary>
        /// <param name="usuarioSistema">A UsuarioSistema.</param>
        /// <returns>Resultado logico da comparação</returns>
        private bool VerificarRegraUsuarioSemPerfil(UsuarioSistema usuarioSistema)
        {
            if (!usuarioSistema.PerfisAssociadosAoUsuario.Any())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Verificars the comprimento de senha.
        /// </summary>
        /// <param name="usuario">The usuario.</param>
        /// <returns>Verdadeiro ou falso.</returns>
        private bool VerificarComprimentoDeSenha(UsuarioSistema usuario)
        {
            if (!string.IsNullOrEmpty(usuario.NovaSenha))
            {
                var tamanhoSenha = usuario.NovaSenha.Trim().Length;

                if (tamanhoSenha >= 6 && tamanhoSenha <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Verificar se existe usuario.
        /// </summary>
        /// <param name="usuarioSistema">A UsuarioSistema.</param>
        /// <returns>Resultado logico da comparação</returns>
        private bool VerificarExisteUsuarioLoginExatamenteIgual(UsuarioSistema usuarioSistema)
        {
            var usuario = this.repositorioUsuarioSistema.ConsultarUsuarioPorLogin(usuarioSistema.Login);

            if (usuario != null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}

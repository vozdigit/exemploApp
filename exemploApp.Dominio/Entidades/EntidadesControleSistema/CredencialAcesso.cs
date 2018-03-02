using exemploApp.Dominio.Entidades.Enumeradores;
using System;
using Tykon.Base.Entidades;

namespace exemploApp.Dominio.Entidades.EntidadesControleSistema
{
    /// <summary>
    /// Classe que implementa a Credencial de Acesso.
    /// </summary>
    public class CredencialAcesso : EntidadeId
    {
        /// <summary>
        /// Recupera ou define o usuario do sistema.
        /// </summary>
        public virtual UsuarioSistema UsuarioSistema { get; set; }

        /// <summary>
        /// Recupera ou define a senha.
        /// </summary>
        public virtual string Senha { get; set; }

        /// <summary>
        /// Recupera ou define o lembrete da senha.
        /// </summary>
        public virtual string LembreteSenha { get; set; }

        /// <summary>
        /// Recupera ou define a data do status da credencial.
        /// </summary>
        public virtual DateTime DtStatusCredencial { get; set; }

        /// <summary>
        /// Recupera ou define o status da credencial.
        /// </summary>
        public virtual EnumSituacao StatusCredencial { get; set; }
    }
}

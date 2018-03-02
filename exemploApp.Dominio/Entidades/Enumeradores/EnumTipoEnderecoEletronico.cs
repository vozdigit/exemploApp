namespace exemploApp.Dominio.Entidades.Enumeradores
{
    /// <summary>
    /// Enumerador que implementa os mais diversos tipos de endereços eletronico que uma pessoa fisica ou juridica pode ter.
    /// </summary>
    public enum EnumTipoEnderecoEletronico
    {
        /// <summary>
        /// Retorna ou define quando o tipo do endereço eletrônico é um email.
        /// </summary>
        EMAIL = 'E',

        /// <summary>
        /// Retorna ou define quando o tipo do endereço eletrônico é um website.
        /// </summary>
        WEBSITE = 'W',

        /// <summary>
        /// Retorna ou define quando o tipo do endereço eletrônico é um usuario do skype.
        /// </summary>
        SKYPE = 'K',

        /// <summary>
        /// Retorna ou define quando o tipo do endereço eletrônico é um perfil ou fan page do facebook.
        /// </summary>
        FACEBOOK = 'F',

        /// <summary>
        /// Retorna ou define quando o tipo do endereço eletrônico é um nome de usuário do twitter.
        /// </summary>
        TWITTER = 'T',

        /// <summary>
        /// Retorna ou define quando o tipo do endereço eletrônico é um perfil do google+.
        /// </summary>
        GOOGLE_MAIS = 'G',

        /// <summary>
        /// Retorna ou define quando o tipo do endereço eletrônico é um perfil do linkedin.
        /// </summary>
        LINKEDIN = 'L',

        /// <summary>
        /// Retorna ou define quando o tipo do endereço eletrônico é um perfil ou usuário do instagram.
        /// </summary>
        INSTAGRAM = 'I',

        /// <summary>
        /// Retorna ou define quando o tipo do endereço eletrônico é um perfil ou usuário do snapchat.
        /// </summary>
        SNAPCHAT = 'S' 
    }
}

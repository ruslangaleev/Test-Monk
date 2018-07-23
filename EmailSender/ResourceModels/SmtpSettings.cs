namespace EmailSender.ResourceModels
{
    public class SmtpSettings
    {
        /// <summary>
        /// Адрес SMTP сервера.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Порт.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Использовать SSL шифрование?
        /// </summary>
        public bool UseSsl { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
    }
}

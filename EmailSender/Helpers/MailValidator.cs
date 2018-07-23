using System;
using System.Net.Mail;

namespace EmailSender.Helpers
{
    /// <summary>
    /// Класс для валидации электронной почты.
    /// </summary>
    public static class MailValidator
    {
        /// <summary>
        /// Валидирует электронную почту.
        /// </summary>
        public static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}

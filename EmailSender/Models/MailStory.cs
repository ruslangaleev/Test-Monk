using System;

namespace EmailSender.Models
{
    /// <summary>
    /// Информация об отправленном письме.
    /// </summary>
    public class MailStory
    {
        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public string MailStoryId { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string[] Recipients { get; set; }

        public string MailFrom { get; set; }

        /// <summary>
        /// Дата отправки.
        /// </summary>
        public DateTime SendAt { get; set; }

        /// <summary>
        /// Результат отправки сообщения.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Текст ошибки.
        /// </summary>
        public string FailedMessage { get; set; }
    }
}

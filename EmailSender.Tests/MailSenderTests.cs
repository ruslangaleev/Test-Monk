using EmailSender.ResourceModels;
using EmailSender.Services.Logic;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace EmailSender.Tests
{
    [TestFixture]
    public class MailSenderTests
    {
        [TestCase("", new string[] { "" }, "", "")]
        [TestCase("testtest.ru", new string[] { "test@test.ru" }, "text", "text")]
        [TestCase("test@test.ru", new string[] { }, "text", "text")]
        [TestCase("test@test.ru", null, "text", "text")]
        [TestCase("test@test.ru", new string[] { "test@test@.ru" }, "text", "text")]
        [TestCase("test@test.ru", new string[] { "test@test@.ru" }, "", null)]
        [TestCase("test@test.ru", new string[] { "test@test@.ru" }, "text", null)]
        public async Task Method(string mailFrom, string[] recipients, string body, string subject)
        {
            // Подготовка
            var mock = new Mock<IOptions<SmtpSettings>>();
            mock.Setup(t => t.Value).Returns(new SmtpSettings()
            {
                Host = "smtp.ya.ru",
                Password = "password",
                UserName = "username"
            });
            var mailSender = new MailSender(mock.Object);

            // Дейтсвие и проверка
            Assert.ThrowsAsync<ArgumentNullException>(() => mailSender.SendAsync(mailFrom, recipients, body, subject));
        }
    }
}

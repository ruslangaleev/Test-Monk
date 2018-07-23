using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailSender.Data.Infrastructure;
using EmailSender.Data.Repositories.Interfaces;
using EmailSender.Models;
using EmailSender.ResourceModels;
using EmailSender.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers
{
    [Route("api/mails")]
    public class MailController : Controller
    {
        /// <summary>
        /// Сервис отправки писем на электронную почту.
        /// </summary>
        private readonly IMailSender _mailSender;

        /// <summary>
        /// Единица работы с БД.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Репозиторий для работы с историей сообщений.
        /// </summary>
        private readonly IMailStoryRepository _mailStoryRepository;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MailController(IMailSender mailSender, IUnitOfWork unitOfWork, IMailStoryRepository mailStoryRepository)
        {
            _mailSender = mailSender ?? throw new ArgumentNullException(nameof(IMailSender));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
            _mailStoryRepository = mailStoryRepository ?? throw new ArgumentNullException(nameof(IMailStoryRepository));
        }

        /// <summary>
        /// Вернет историю сообщений.
        /// </summary>
        /// <response code="200">Успешно вернет историю сообщений.</response>
        [HttpGet]
        public async Task<IEnumerable<MailStory>> Get()
        {
            return await _mailStoryRepository.GetAsync();
        }

        /// <summary>
        /// Выполнит рассылку указанным адресатам.
        /// </summary>
        /// <response code="200">Успешно разошлет письма всем адресатам.</response>
        /// <response code="400">Не удалось доставить письмо адресатам.</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewMailModel model)
        {
            try
            {
                await _mailSender.SendAsync(model.MailFrom, model.Recipients, model.Body, model.Subject);

                await _mailStoryRepository.AddAsync(new MailStory
                {
                    Body = model.Body,
                    SendAt = DateTime.Now,
                    MailFrom = model.MailFrom,
                    Recipients = model.Recipients,
                    Result = "OK",
                    Subject = model.Subject
                });
                await _unitOfWork.SaveChangesAsync();

                return Ok("Сообщение успешно отправлено");
            }
            catch(ArgumentNullException e)
            {
                return BadRequest($"Ошибка отправки сообщения: {e.Message}");
            }
            catch(Exception e)
            {
                await _mailStoryRepository.AddAsync(new MailStory
                {
                    Body = model.Body,
                    SendAt = DateTime.Now,
                    MailFrom = model.MailFrom,
                    Recipients = model.Recipients,
                    Result = "Failed",
                    Subject = model.Subject,
                    FailedMessage = e.Message,
                });
                await _unitOfWork.SaveChangesAsync();

                return BadRequest($"Ошибка отправки сообщения: {e.Message}");
            }
        }
    }
}

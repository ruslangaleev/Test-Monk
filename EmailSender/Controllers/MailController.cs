using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMailSender _mailSender;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailStoryRepository _mailStoryRepository;

        public MailController(IMailSender mailSender, IUnitOfWork unitOfWork, IMailStoryRepository mailStoryRepository)
        {
            _mailSender = mailSender ?? throw new ArgumentNullException(nameof(IMailSender));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
            _mailStoryRepository = mailStoryRepository ?? throw new ArgumentNullException(nameof(IMailStoryRepository));
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewMailModel model)
        {
            try
            {
                await _mailSender.SendAsync(model.MailFrom, model.Recipients, model.Body, model.Subject);

                await _mailStoryRepository.Add(new MailStory
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
                await _mailStoryRepository.Add(new MailStory
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

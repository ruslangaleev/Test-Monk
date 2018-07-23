using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailSender.ResourceModels;
using EmailSender.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers
{
    [Route("api/mails")]
    public class MailController : Controller
    {
        private readonly IMailSender _mailSender;

        public MailController(IMailSender mailSender)
        {
            _mailSender = mailSender ?? throw new ArgumentNullException(nameof(IMailSender));
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
                return Ok("Сообщение успешно отправлено");
            }
            catch(Exception e)
            {
                return BadRequest($"Ошибка отправки сообщения: {e.Message}");
            }
        }
    }
}

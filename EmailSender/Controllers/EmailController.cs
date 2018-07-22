using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailSender.ResourceModels;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers
{
    [Route("api/mails")]
    public class EmailController : Controller
    {
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
        public void Post([FromBody]NewMailModel model)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        [HttpGet]
        [Route("sendmail")]
        public IActionResult SendEmail()
        {

            SmtpClient client = new SmtpClient("mail.shezartech.in");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("XXXXXX", "XXXXXX");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("adityagoyal252999@gmail.com");
            mailMessage.To.Add("aditya@shezartech.in");
            mailMessage.Body = "body";
            mailMessage.Subject = "subject";
            client.Send(mailMessage);

            return Ok();
        }

    }
}
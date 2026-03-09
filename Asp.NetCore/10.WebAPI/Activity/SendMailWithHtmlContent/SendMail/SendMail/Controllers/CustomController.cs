using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendMail.Helper;
using SendMail.Service;

namespace SendMail.Controllers
{
    [Route("api/Custom")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private readonly IEmailService emailService;
        public CustomController(IEmailService emailService) 
        {
            this.emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail()
        {
            try
            {
                MailRequest mailrequest = new MailRequest();
                mailrequest.ToEmail = "afra.afi.74@gmail.com";
                mailrequest.Subject = "Welcome";
                mailrequest.Body = GetHtmlContent();
                await emailService.SendEmailAsync(mailrequest);
                return Ok();

            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        private string GetHtmlContent()
        {
            string response = "<div style=background-color:lightblue;color:white>";
            response += "<h1>Hi there! 😊 Hope you're having a great day! If there's anything you need, just let me know!</h1>";
            response += "<h3>AFRA V</h3>";
            response += "<h3>Asp.NetCore-Angular Full Stack Developer </h3>";
            response += "<a href=\"www.aitrich.com\">www.aitrich.com</a>";
            response += "</div>";
            return response;
        }
    }
}

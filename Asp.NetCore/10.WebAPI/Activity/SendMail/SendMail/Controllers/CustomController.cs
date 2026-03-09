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
                mailrequest.Body = "Thank you";
                await emailService.SendEmailAsync(mailrequest);
                return Ok();

            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}

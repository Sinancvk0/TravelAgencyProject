using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;
using TraversalCoreProject.Models;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressfrom = new MailboxAddress("Admin", "scivak201 @gmail.com");

            mimeMessage.From.Add(mailboxAddressfrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);

            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequest.Subject;

            //Body bölümü içim Textpart olarak tanımlamam gerekiyor
            var bodyBuilder = new BodyBuilder
            {
                TextBody = mailRequest.Body
            };
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("scivak201@gmail.com","hjycpsqlipiszgvo");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}

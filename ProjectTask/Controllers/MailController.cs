using Hangfire;
using Microsoft.AspNetCore.Mvc;
using ProjectTask.Services.Interface;
using System.ComponentModel.DataAnnotations;

namespace ProjectTask.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailRepo _mailRepo;

        public MailController(IMailRepo mailRepo)
        {
            _mailRepo = mailRepo;
        }

        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail([EmailAddress] string mailTo, string message, DateTime time)
        {

            try
            {

                TimeSpan delay = time - DateTime.Now;

                BackgroundJob.Schedule(() => _mailRepo.SendingMail(mailTo, message, null), delay);

                ViewBag.Message = "Mail scheduled successfully.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error scheduling mail: " + ex.Message;
            }

            return View();
        }
    }
}

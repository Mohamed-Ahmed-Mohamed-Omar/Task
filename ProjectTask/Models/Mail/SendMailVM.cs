using System.ComponentModel.DataAnnotations;

namespace ProjectTask.Models.Mail
{
    public class SendMailVM
    {
        [EmailAddress]
        public string mailTo { get; set; }

        public string message { get; set; }

        public DateTime Time { get; set; }
    }
}

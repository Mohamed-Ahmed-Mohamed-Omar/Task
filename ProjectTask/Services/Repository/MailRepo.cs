﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using ProjectTask.Models.Mail;
using ProjectTask.Services.Interface;

namespace ProjectTask.Services.Repository
{
    public class MailRepo : IMailRepo
    {
        private readonly MailSetting _setting;

        public MailRepo(IOptions<MailSetting> setting)
        {
            _setting = setting.Value;
        }

        public async Task<string> SendingMail(string mailTo, string Message, string? reason)
        {
            using (var smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync(_setting.Host, _setting.Port, true);
                await smtpClient.AuthenticateAsync(_setting.Email, _setting.Password);
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"{Message}",
                    TextBody = "Wellcome"
                };
                var mailMessage = new MimeMessage()
                {
                    Body = bodyBuilder.ToMessageBody()
                };
                mailMessage.From.Add(new MailboxAddress(_setting.DisplayName, _setting.Email));
                mailMessage.To.Add(new MailboxAddress("Test", mailTo));
                mailMessage.Subject = reason == null ? "Welcome" : reason;
                await smtpClient.SendAsync(mailMessage);
                smtpClient.Disconnect(true);
            }
            return "Success";
        }
    }
}

﻿using System;
using AlMarket.MVC.Data;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace AlMarket.MVC.Services
{
    public class GmailManager : IMailService
    {
        private readonly MailSetting _mailSettings;

        public GmailManager(IOptions<MailSetting> mailSetting)
        {
            _mailSettings = mailSetting.Value;
        }

        public async Task SendEmailAsync(RequestEmail mailRequest)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(_mailSettings.Mail)
                };
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder
                {
                    HtmlBody = mailRequest.Body
                };
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Passsword);

                await smtp.SendAsync(email);

                smtp.Disconnect(true);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


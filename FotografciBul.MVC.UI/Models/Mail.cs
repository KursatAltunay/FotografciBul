using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace FotografciBul.MVC.UI.Models
{
    public class Mail
    {
        public static void MailSender(string body, Contact contact)
        {

            var fromAddress = new MailAddress("artphoto201@gmail.com");//gönderici mail adresi
            var toAddress = new MailAddress("artphoto201@gmail.com");
            string subject = contact.Subject.ToString();
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "photoart201")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);

                }
            }
        }
    }
}
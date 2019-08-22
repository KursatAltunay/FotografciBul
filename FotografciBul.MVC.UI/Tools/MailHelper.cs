using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace FotografciBul.MVC.UI.Tools
{
    public class MailHelper
    {
        public static bool SendConfirmationMail(string username, string password, string email, int id)
        {
            bool result = false;
            MailMessage msg = new MailMessage();
            msg.To.Add(email);
            msg.Subject = "Hoşgeldiniz ...";
            msg.Body = "Sitemize hoşgeldiniz.";
            //içeriği değiştirilebilir.
            msg.From = new MailAddress("tugbakac45@gmail.com");
            //mail adresi açılacak
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("tugbakac45@gmail.com", "fotobul45");
            smtpClient.Credentials = credential;
            try
            {
                smtpClient.Send(msg);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;    
            }
            return result;
        }
    }
}
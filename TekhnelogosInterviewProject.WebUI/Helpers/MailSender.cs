using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TekhnelogosInterviewProject.WebUI.Helpers
{
    public static class MailSender
    {
        public static void Sender(string email,string data)
        {

            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("akmustafa2511@gmail.com", "mustafa11mustafa");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("eposta@gmail.com", "InGame");
            mail.To.Add(email);
            mail.Subject = "Yeni E-Posta Şifre Talebi";
            mail.IsBodyHtml = true;
            mail.Body = $"Yeni Şifreniz : {data}";
            sc.Send(mail);
        }
    }
}

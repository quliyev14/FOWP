using System;
using System.Net;
using System.Net.Mail;

namespace ForOfficialWorkProject.MS
{
    public static class Service
    {
        public static void MailIsSend(string adress, int port, string subject,string body)
        {
            var mail = new MailMessage();
            var smtp = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(adress);
            mail.To.Add(adress);
            mail.Subject = subject;
            smtp.Port = port;
            mail.Body = body;
            smtp.Credentials = new NetworkCredential(adress, "lnwc woat lnin oqvj");

            smtp.EnableSsl = true;
            smtp.Send(mail);
            Console.WriteLine("📨 Mail sent successfully");
        }
    }
}

//"bxud vzpz ayod xene"
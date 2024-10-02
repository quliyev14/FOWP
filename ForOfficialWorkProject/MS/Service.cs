namespace ForOfficialWorkProject.MS
{
    public static class Service
    {
        public static void MailIsSend(string adress, string subject, string body)
        {
            var mail = new MailMessage();
            var smtp = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(adress);
            mail.To.Add(adress);
            mail.Subject = subject;
            smtp.Port = 587;
            mail.Body = body;
            smtp.Credentials = new NetworkCredential(adress, "lnwc woat lnin oqvj");

            smtp.EnableSsl = true;
            smtp.Send(mail);
            Console.WriteLine("📨 Mail sent successfully");
        }
    }
}
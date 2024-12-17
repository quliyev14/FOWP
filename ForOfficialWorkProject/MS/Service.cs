namespace ForOfficialWorkProject.MS;

public static class Service
{
    private const string _password = "lnwc woat lnin oqvj";
    private const string _fromAdress = "elgun.q2003@gmail.com";

    public static void MailSend(string toAdress, string subject, string body)
    {
        MailMessage mail = new();
        mail.From = new MailAddress(_fromAdress);
        mail.To.Add(toAdress);
        mail.Body = body;
        mail.Subject = subject;
        mail.Attachments.Add(new Attachment("/Users/elgun668icloud.com/FOWP/ForOfficialWorkProject/bin/Debug/net7.0/A.txt"));

        //mail.Priority = MailPriority.High; 

        SmtpClient client = new("smtp.gmail.com",587)
        {
            Credentials = new NetworkCredential(_fromAdress, _password),
            EnableSsl = true
            //Timeout = 10000
        };
        client.Send(mail);
    }
}
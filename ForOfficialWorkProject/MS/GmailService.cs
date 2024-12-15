using System.Security.Cryptography;
using ForOfficialWorkProject.Exceptions;
using ForOfficialWorkProject.Helper;

namespace ForOfficialWorkProject.MS
{
    public enum GP
    {
        Gmail,
        Password
    }


    public class GmailService
    {
        public string? gmail { get; init; } = default!;
        public string? password { get; set; } = default!;

        public GmailService(string gmail, string password)
        {
            this.gmail = GmailAndPasswordCheck.GPCheck(GP.Gmail, gmail);
            string gmailcheckresult = GmailAndPasswordCheck.GPCheck(GP.Password, password);
            this.password = GmailAndPasswordCheck.GPCheck(GP.Password, password) is not null ? PasswordHash(gmailcheckresult) : null;
            if (this.gmail is null || this.password is null)
                throw new ArgumentMailNullException("Gmail or Password is null");
        }

        public override string ToString() => $"{gmail} {password}\n";
        string PasswordHash(string password)
        {
            var sb = new StringBuilder();
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
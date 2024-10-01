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
            this.password = GmailAndPasswordCheck.GPCheck(GP.Password, password);

            if (this.gmail is null || this.password is null)
                throw new ArgumentMailNullException("Gmail or Password is null");
        }

        public override string ToString() => $"{gmail} {password}\n";
    }
}
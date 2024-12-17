using ForOfficialWorkProject.MS;

namespace ForOfficialWorkProject.Models;

public class Admin
{
    public Admin(string name, string surname, GmailService gmailService)
    {
        this.name = name;
        this.surname = surname;
        this.gmailService = gmailService;
    }

    public string name { get; init; } = default!;
    public string surname { get; init; } = default!;
    public GmailService gmailService { get; set; } = default!;

    public override string ToString() => $"{name} {surname} {gmailService}\n";
}
using System.Security.Cryptography;

namespace ForOfficialWorkProject.Hash;

public class DataHash
{
    public static string PasswordHash(string password)
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

    public static bool Verify(string password, string hashedPassword) => PasswordHash(password) == hashedPassword ? true : false;
}
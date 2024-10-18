using ForOfficialWorkProject.MS;

namespace ForOfficialWorkProject.Helper
{
    public static class GmailAndPasswordCheck
    {
        public static string GPCheck(GP gp, string text)
        {
            var result = gp switch
            {
                GP.Gmail => GBResult(text),
                GP.Password => GBResult(text),
                _ => throw new ArgumentException(nameof(gp))
            };

            if (result is null)
                return null!;

            var sb = new StringBuilder();
            return sb.Append(result).ToString();
        }

        private static string GBResult(string text)
        {
            int digitCount = 0;
            int letterCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                    ++digitCount;
                else if (char.IsLetter(text[i]))
                    ++letterCount;
            }
            //UPDATE
            if (letterCount >= 4 && digitCount >= 4)
                return text;
            return null!;
        }
    }
}
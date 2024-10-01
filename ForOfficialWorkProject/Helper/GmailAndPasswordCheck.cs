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

            var sb = new StringBuilder();
            return sb.Append(result).ToString();
        }

        private static string GBResult(string text)
        {
            int numberCount = 0;
            int alphaCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                    numberCount++;
                else if (char.IsLetter(text[i]))
                    alphaCount++;
            }
             //UPDATE
            if (alphaCount <= 4 && numberCount <= 4)
                return "Wrong";
            return text;
        }
    }
}













#region Obselote method
//[Obsolete("This method is work cannot", true)]
//public static string GBResult(string text)
//{
//    int numberCount = 0;
//    int alphaCount = 0;

//    for (int i = 0; i < text.Length; i++)
//    {
//        if (((char)text[i] >= 48 || (char)text[i] <= 57))
//        {
//            numberCount += 1;
//            if (numberCount >= 4)
//                Console.WriteLine("Dogru giris");
//        }
//        else if ((char)text[i] >= 65 || (char)text[i] <= 90 || (char)text[i] >= 97 || (char)text[i] <= 122)
//        {
//            alphaCount += 1;
//            if (alphaCount >= 4)
//                Console.WriteLine("Dogru Giris");
//        }
//    }
//    return "";
//}
#endregion
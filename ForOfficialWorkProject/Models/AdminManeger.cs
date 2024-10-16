using DocumentFormat.OpenXml.Spreadsheet;
using ForOfficialWorkProject.Helper;
using ForOfficialWorkProject.MS;

namespace ForOfficialWorkProject.Models
{
    public static class AdminManeger
    {
        private static readonly object _psro = new object();

        public static void Add(string log, string jsonpath,
                               string mailAdress, string mailSubject,
                               IEnumerable<Product> objects)
        {
            if (objects is null) throw new ArgumentNullException(nameof(objects));
            lock (_psro)
                AddWithThread(log, jsonpath, mailAdress, mailSubject, objects);
        }

        private static void AddWithThread(string log, string jsonpath,
                                          string mailAdress, string mailSubject,
                                          IEnumerable<Product> objects)
        {
            DB.DB.JsonWrite(jsonpath, log, objects);
            foreach (var p in objects)
                Service.MailIsSend(mailAdress, mailSubject, p.ToString());
        }

        public static void Delete(in string path, in string log)
        {
            var jp = DB.DB.JsonRead<Product>(path) ?? new List<Product>();
            DB.DB.JsonWrite(path, log, jp);
        }

        public static void AllShow(string path)
        {
            var products = File.Exists(path)
            ? DB.DB.JsonRead<Product>(path)!.ToList() ?? new List<Product>()
            : throw new FileNotFoundException(nameof(path));

            var enumerator = products.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var pc = enumerator.Current;
                Console.WriteLine($"{pc}");
            }
        }

        public static void Edit(in string path, Product @object)
        {
            throw new NotImplementedException();
        }

        public static void Search(string search_text, in string path)
        {
            bool result = PathCheck.OpenOrClosed(path);

            if (!result) throw new FileNotFoundException(nameof(path));
            else
            {
                DB.DB.JsonRead<Product>(path)
                       .Where(p => p.Name!.Contains(search_text))
                        .ToList()
                        .ForEach(c => Console.WriteLine(c));
            }
        }

        public static void BudgetInOrOut(in string path)
        {
            throw new NotImplementedException();
        }
    }
}
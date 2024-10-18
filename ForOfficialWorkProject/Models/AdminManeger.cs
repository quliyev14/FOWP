using ForOfficialWorkProject.Helper;
using ForOfficialWorkProject.MS;


namespace ForOfficialWorkProject.Models
{
    public static class AdminManeger
    {
        private static readonly object _psro = new object();

        public static void Add(string log, string jsonpath,
                               string mailAdress, string mailSubject,
                               IEnumerable<Product>? objects)
        {
            if (objects is null) throw new ArgumentNullException(nameof(objects));
            lock (_psro)
                AddWithThread(log, jsonpath, mailAdress, mailSubject, objects);
        }

        private static void AddWithThread(string log, string jsonpath,
                                          string mailAdress, string mailSubject,
                                          IEnumerable<Product> products)
        {
            DB.DB.JsonWrite(jsonpath, log, products);
            MailSend(mailAdress, mailSubject, products);
        }

        private static void MailSend(string adress, string subject, IEnumerable<Product> products) =>
            products.ToList().ForEach(p => Service.MailIsSend(adress, subject, p.ToString()));

        public static void AllShow(string path)
        {
            var products = PathCheck.OpenOrClosed(path)
            ? DB.DB.JsonRead<Product>(path)!.ToList() ?? new List<Product>()
            : throw new FileNotFoundException(nameof(path));

            var enumerator = products.GetEnumerator();

            while (enumerator.MoveNext())
                Console.WriteLine($"{enumerator.Current}");
        }

        public static void Search(string search_text, in string path)
        {
            if (!PathCheck.OpenOrClosed(path)) throw new FileNotFoundException(nameof(path));
            DB.DB.JsonRead<Product>(path)
                 .Where(p => p.Name?
                 .Contains(search_text) == true)
                 .ToList()
                 .ForEach(c => Console.WriteLine($"{c}"));
        }

        public static void Delete(in string path, in string log)
        {
            var jp = DB.DB.JsonRead<Product>(path) ?? new List<Product>();
            DB.DB.JsonWrite(path, log, jp);
        }

        public static void Edit(in string path, Product @object)
        {
            throw new NotImplementedException();
        }

        public static void BudgetInOrOut(in string path)
        {
            throw new NotImplementedException();
        }
    }
}
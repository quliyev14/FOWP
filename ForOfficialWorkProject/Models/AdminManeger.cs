using ForOfficialWorkProject.Helper;
using ForOfficialWorkProject.MS;


namespace ForOfficialWorkProject.Models
{
    public static class AdminManeger
    {
        private static readonly object _psro = new();

        public static void Add(string log, string jsonpath,
                               string toAdress, string mailSubject,
                               IEnumerable<Product>? objects)
        {
            if (objects is null) throw new ArgumentNullException(nameof(objects));
            lock (_psro)
                AddWithThread(log, jsonpath, toAdress, mailSubject, objects);
        }

        private static void AddWithThread(string log, string jsonpath,
                                          string toAdress, string mailSubject,
                                          IEnumerable<Product> products)
        {
            DB.DB.JsonWrite(jsonpath, log, products);
            DB.DB.WriteDotTxt(products);
            MailSend(toAdress, mailSubject, products);
        }
        private static void MailSend(string toAdress, string subject, IEnumerable<Product> products)
        {
            var productDetails = string.Join(Environment.NewLine, products.Select(p => p.ToString()));

            Service.MailSend(toAdress, subject, productDetails);
        }

        public static void AllShow(string path)
        {
            var products = PathCheck.OpenOrClosed(path)
            ? DB.DB.JsonRead<Product>(path)!.ToList() ?? new List<Product>()
            : throw new FileNotFoundException(nameof(path));

            var enumerator = products.GetEnumerator();

            while (enumerator.MoveNext())
                Console.WriteLine($"{enumerator.Current}");
        }

        public static void Search(string search_text, string path)
        {
            try
            {
                if (!PathCheck.OpenOrClosed(path)) throw new FileNotFoundException(nameof(path));
                DB.DB.JsonRead<Product>(path)
                     .Where(p => p.Name?
                     .Contains(search_text) == true)
                     .ToList()
                     .ForEach(c => Console.WriteLine($"{c}"));

            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine($"{fnfe.Message}");
            }
        }

        public static void Delete(string path, string log, string id)
        {
            try
            {
                var jr = DB.DB.JsonRead<Product>(path).ToList() ?? throw new ArgumentNullException("Argument is null Exception");
                if (!PathCheck.OpenOrClosed(path)) throw new FileNotFoundException(nameof(path));
                var productRemove = jr.FirstOrDefault(p => p.Id == id) ?? throw new ArgumentException("Argument Exception");
                jr.Remove(productRemove);
                DB.DB.JsonWrite(path, log, jr);

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"{ane.Message}");
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine($"{fnfe.Message}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"{ae.Message}");
            }
        }

        public static void Edit(string path, Product @object)
        {
            throw new NotImplementedException();
        }
    }
}
using ForOfficialWorkProject.MS;

namespace ForOfficialWorkProject.Models
{
    public static class AdminManeger
    {
        public static void Add(string xlpath, string log, string jsonpath, string mailAdress, string mailSubject, List<Product> products)
        {
            if (products is null)
                throw new ArgumentNullException("Object is null");

            var th = new Thread(() =>
            {
                AddWithThread(xlpath, log, jsonpath, mailAdress, mailSubject, products);
            });
            th.Start();
        }

        private static void AddWithThread(string xlpath, string log, string jsonpath, string mailAdress, string mailSubject, List<Product> products)
        {
            DB.DB.JsonWrite(jsonpath, log, products);
            DB.DB.XlWrite(xlpath, jsonpath);
            products.ForEach(p => Service.MailIsSend(mailAdress, mailSubject, p.ToString()));
        }

        public static void Delete(in string path, in string log, Product product)
        {
            var jp = DB.DB.JsonRead<Product>(path) ?? new List<Product>();
            jp.Remove(product);
            DB.DB.JsonWrite(path, log, jp);
            Console.WriteLine("Operation succesfully");
        }

        public static void Edit(in string path, Product @object)
        {
            throw new NotImplementedException();
        }

        public static void Find(in string xlpath, string name)
        {
            DB.DB.XlRead(xlpath);
        }

        public static void AllShow(string path)
        {
            var products = File.Exists(path)
            ? DB.DB.JsonRead<Product>(path)!.ToList()
            ?? new List<Product>()
            : throw new FileNotFoundException(nameof(path));

            products!.ForEach(p => Console.WriteLine($"{p}"));
        }

        public static void BudgetInOrOut(in string path)
        {
            throw new NotImplementedException();
        }
    }
}
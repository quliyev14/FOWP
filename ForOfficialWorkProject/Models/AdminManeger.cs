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

            foreach (var product in products)
            {
                Service.MailIsSend(mailAdress,
                                   mailSubject,
                                   $" {product.Id}.  " +
                                   $" Code:{product.Code}  " +
                                   $" Firma name: {product.Firma}  " +
                                   $" Name: {product.Name}  " +
                                   $" Color: {product.Color}  " +
                                   $" Min age: {product.AgeRangeMin}  " +
                                   $" Max age: {product.AgeRangeMax}  " +
                                   $" Count: {products.Count}  " +
                                   $" Ici: {product.CountInPacket}-li,lu  " +
                                   $" Umumi gelen eded sayi: [{product.Count * product.CountInPacket}]  " +
                                   $" Price: {product.Price:C}  ");
            }
        }

        public static void Delete(in string path, Product @object)
        {
            throw new NotImplementedException();
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
            ?? throw new InvalidOperationException("Products could not be read!")
            : throw new FileNotFoundException(nameof(path));

            products!.ForEach(p => Console.WriteLine($"{p}"));
        }

        public static void BudgetInOrOut(in string path)
        {
            throw new NotImplementedException();
        }
    }
}
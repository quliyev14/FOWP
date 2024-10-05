using ForOfficialWorkProject.MS;

namespace ForOfficialWorkProject.Models
{
    public static class AdminManeger
    {
        public static void Add(string path, string pathLog, string mailAdress, string mailSubject, Product @object)
        {
            if (@object is null)
                throw new ArgumentNullException("Object is null");

            var th = new Thread(() =>
            {
                AddWithThread(path, pathLog, mailAdress, mailSubject, @object);
            });
            th.Start();
        }

        public static void AddWithThread(string path, string pathLog, string mailAdress, string mailSubject, Product @object)
        {
            DB.DB.JsonWrite(path, pathLog, @object);

            Service.MailIsSend(mailAdress,
                               mailSubject,
                               $" {@object.Id}.  " +
                               $" Code:{@object.Code}  " +
                               $" Firma name: {@object.FirmaName}  " +
                               $" Name: {@object.Name}  " +
                               $" Color: {@object.Color}  " +
                               $" Min age: {@object.AgeRangeMin}  " +
                               $" Max age: {@object.AgeRangeMax}  " +
                               $" Count: {@object.Count}  " +
                               $" Ici: {@object.CountInPacket}-li,lu  " +
                               $" Umumi gelen eded sayi: [{@object.Count * @object.CountInPacket}]  " +
                               $" Price: {@object.Price:C}  ");
        }

        public static void Delete(in string path, Product @object)
        {
            throw new NotImplementedException();
        }

        public static void Edit(in string path, Product @object)
        {
            throw new NotImplementedException();
        }

        public static void Find(in string path, Product @object)
        {
            throw new NotImplementedException();
        }

        public static void ALlShow(in string path)
        {
            var products = File.Exists(path)
            ? DB.DB.JsonRead<Product>(path)
            : throw new FileNotFoundException(nameof(path));

            products!.ForEach(p => Console.WriteLine($"{p}"));
        }

        public static void BudgetInOrOut(in string path)
        {
            throw new NotImplementedException();
        }
    }
}
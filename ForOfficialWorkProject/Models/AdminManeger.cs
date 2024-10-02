using ForOfficialWorkProject.MS;

namespace ForOfficialWorkProject.Models
{
    public static class AdminManeger
    {
        public static void Add(in string path, in string pathLog, in string mailAdress, in string mailSubject, Product obj)
        {
            if (obj is null)
                throw new ArgumentNullException("Object is null");
            else
            {
                DB.DB.JsonWrite(path, pathLog, obj);

                Service.MailIsSend(mailAdress,
                                   mailSubject,
                                   $"{obj.Id}. " +
                                   $" Code:{obj.Code}  " +
                                   $" Firma name: {obj.FirmaName}  " +
                                   $" Name: {obj.Name}  " +
                                   $" Color: {obj.Color}  " +
                                   $" Min age: {obj.AgeRangeMin}  " +
                                   $" Max age: {obj.AgeRangeMax}  " +
                                   $" Count: {obj.Count}  " +
                                   $" Ici: {obj.CountInPacket}-li,lu  " +
                                   $" Umumi gelen eded sayi: [{obj.Count * obj.CountInPacket}]  " +
                                   $" Price: {obj.Price:C}  ");
            }
        }

        public static void Delete(in string path, Product obj)
        {
            throw new NotImplementedException();
        }

        public static void Edit(in string path, Product obj)
        {
            throw new NotImplementedException();
        }

        public static void Find(in string path, Product obj)
        {
            throw new NotImplementedException();
        }

        public static void BudgetInOrOut(in string path)
        {
            throw new NotImplementedException();
        }
    }
}
namespace ForOfficialWorkProject.Models
{
    public static class AdminManeger
    {
        public static void Add(in string path, in string pathLog, Product obj)
        {
            if (obj is null)
                throw new ArgumentNullException("Object is null");
            else
                DB.DB.JsonWrite(path, pathLog, obj);
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
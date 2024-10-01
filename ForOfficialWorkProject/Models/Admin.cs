namespace ForOfficialWorkProject.Models
{
    public static partial class Admin
    {
        /*Admin class => {
1)prop => name,surname,mail
2)Method => Add, Delete,Edit, Find(filter [1.name, 2.#code]), BudgetInOrOut.
}*/

    }

    public static partial class Admin<T>
    {
        public static void Add(in string path, T obj)
        {
            throw new NotImplementedException();
        }

        public static void Delete(in string path, T obj)
        {
            throw new NotImplementedException();
        }

        public static void Edit(in string path, T obj)
        {
            throw new NotImplementedException();
        }

        public static void Find(in string path, T obj)
        {
            throw new NotImplementedException();
        }

        public static void BudgetInOrOut(in string path)
        {
            throw new NotImplementedException();
        }
    }
}
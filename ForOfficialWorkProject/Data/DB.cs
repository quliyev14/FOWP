using ForOfficialWorkProject.Helper;
using ForOfficialWorkProject.Models;

namespace ForOfficialWorkProject.DB
{
    public static class DB
    {
        private static readonly object _psro = new object();

        public static IEnumerable<T> JsonRead<T>(string path) =>
                PathCheck.OpenOrClosed(path)
                ? NetJSON.NetJSON.Deserialize<IEnumerable<T>>(File.ReadAllText(path))
                : throw new FileNotFoundException(nameof(path));

        public static void ProductWriteLog<T>(in string log, IEnumerable<T> objects) => WriteLog<T>(log, objects);

        private static void WriteLog<T>(in string log, IEnumerable<T> objects)
        {
            using (var sw = new StreamWriter(log, true))
            {
                var enumerator = objects.GetEnumerator();
                while (enumerator.MoveNext())
                    sw.WriteLine($"{enumerator.Current}");
                enumerator.Dispose();
            }
        }

        public static void JsonWrite<T>(string path, in string log, IEnumerable<T> objects)
        {
            var jsonOptions = new JsonSerializerOptions() { WriteIndented = true };
            if (!PathCheck.OpenOrClosed(path))
            {
                File.WriteAllText(path, JsonSerializer.Serialize(objects, jsonOptions));
                objects = JsonRead<T>(path)!;
            }
            File.WriteAllText(path, JsonSerializer.Serialize(objects, jsonOptions));
            ProductWriteLog(log, objects);
        }

        public static void WriteDotTxt(IEnumerable<Product> products)
        {
            var productDetails = string.Join(Environment.NewLine, products.Select(p => p.ToString()));

            using (var fs = new FileStream("A.txt", FileMode.Append, FileAccess.Write, FileShare.None))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(productDetails);
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
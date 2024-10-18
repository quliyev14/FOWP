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
                {
                    var ec = enumerator.Current;
                    sw.WriteLine($"{ec}");
                }
                enumerator.Dispose();
            }
        }

        public static void JsonWrite<T>(string path, in string log, IEnumerable<T> objects)
        {
            var jsonOptions = new JsonSerializerOptions() { WriteIndented = true };
            bool result = PathCheck.OpenOrClosed(path);
            if (!result)
            {
                File.WriteAllText(path, JsonSerializer.Serialize(objects, jsonOptions));
                objects = JsonRead<T>(path)!;
            }
            File.WriteAllText(path, JsonSerializer.Serialize(objects, jsonOptions));
            ProductWriteLog(log, objects);
        }

        [Obsolete("This method work can't", true)]
        private static void writelog(in string log, IEnumerable<Product> objects)
        {
            using (var sw = new StreamWriter(log, true))
            {
                foreach (var p in objects)
                    sw.WriteLine($"packet: {p.Count}\t" +
                                 $"/{p.CountInPacket}-li  price: /{p.Price:C}\t" +
                                 $"/Cemi gelen eded sayi: {p.CountInPacket * p.Count}\t" +
                                 $"/Total price => {(p.CountInPacket * p.Count) * p.Price:C}");
            }
        }
    }
}
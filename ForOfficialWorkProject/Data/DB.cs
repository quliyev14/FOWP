using ForOfficialWorkProject.Models;

namespace ForOfficialWorkProject.DB
{
    public static class DB
    {
        public static void JsonWrite(in string path, in string log, Product obj)
        {
            var exitsObj = new List<Product>();

            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonSerializer.Serialize(new List<Product>(), new JsonSerializerOptions() { WriteIndented = true }));
                exitsObj = JsonRead<Product>(path);
                exitsObj!.Add(obj);
                File.WriteAllText(path, JsonSerializer.Serialize(exitsObj, new JsonSerializerOptions() { WriteIndented = true }));
            }

            else
            {
                exitsObj = JsonRead<Product>(path);
                exitsObj!.Add(obj);
                File.WriteAllText(path, JsonSerializer.Serialize(exitsObj, new JsonSerializerOptions() { WriteIndented = true }));
            }
            ProductWriteLog(log, obj);
        }

        public static List<T>? JsonRead<T>(string path) => File.Exists(path)
            ? NetJSON.NetJSON.Deserialize<List<T>>(File.ReadAllText(path: path))
            : throw new FileNotFoundException(nameof(path));

        public static void ProductWriteLog(in string log, Product obj)
        {
            using (var sw = new StreamWriter(log))
                sw.WriteLine($"packet: {obj.Count} " +
                    $"/{obj.CountInPacket}-li  price: /{obj.Price:C}  " +
                    $"/Cemi gelen eded sayi: {obj.CountInPacket * obj.Count}  " +
                    $"/Total price => {(obj.CountInPacket * obj.Count) * obj.Price:C}");
        }
    }
}
namespace ForOfficialWorkProject.DB
{
    public static class DB
    {
        public static void JsonWrite<T>(in string path, in string logPath, T obj)
        {
            var exitsObj = new List<T>();

            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonSerializer.Serialize(new List<T>(), new JsonSerializerOptions() { WriteIndented = true }));
                exitsObj = JsonRead<T>(path);
                exitsObj!.Add(obj);
                File.WriteAllText(path, JsonSerializer.Serialize(exitsObj, new JsonSerializerOptions() { WriteIndented = true }));
            }

            else
            {
                exitsObj = JsonRead<T>(path);
                exitsObj!.Add(obj);
                File.WriteAllText(path, JsonSerializer.Serialize(exitsObj, new JsonSerializerOptions() { WriteIndented = true }));
            }
            WriteLog<T>(logPath, obj);
        }

        public static List<T>? JsonRead<T>(string path) => File.Exists(path)
            ? NetJSON.NetJSON.Deserialize<List<T>>(File.ReadAllText(path: path))
            : throw new FileNotFoundException(nameof(path));

        public static void WriteLog<T>(string log, T obj)
        {
            using (var write = new StreamWriter(log, true))
                write.WriteLine($"{obj}");
        }
    }
}
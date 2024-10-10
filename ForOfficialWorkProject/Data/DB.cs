using DocumentFormat.OpenXml.Spreadsheet;
using ForOfficialWorkProject.Models;

namespace ForOfficialWorkProject.DB
{
    public static class DB
    {
        private static readonly object _sync = new object();

        public static List<T>? JsonRead<T>(string path)
        {
            lock (_sync)
            {
                return File.Exists(path)
                ? NetJSON.NetJSON.Deserialize<List<T>>(File.ReadAllText(path))
                : throw new FileNotFoundException(nameof(path));
            }
        }

        public static void ProductWriteLog(in string log, List<Product> products)
        {
            lock (_sync)
            {
                WriteLog(log, products);
            } 
        }

        private static void WriteLog(in string log, List<Product> products)
        {
            using (var sw = new StreamWriter(log, true))
                products.ForEach(p => sw.WriteLine($"packet: {p.Count}\t" +
                        $"/{p.CountInPacket}-li  price: /{p.Price:C}\t" +
                        $"/Cemi gelen eded sayi: {p.CountInPacket * p.Count}\t" +
                        $"/Total price => {(p.CountInPacket * p.Count) * p.Price:C}"));
        }

        public static void JsonWrite(string path, in string log, List<Product> products)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonSerializer.Serialize(products, new JsonSerializerOptions() { WriteIndented = true }));
                products = JsonRead<Product>(path)!;
                File.WriteAllText(path, JsonSerializer.Serialize(products, new JsonSerializerOptions() { WriteIndented = true }));
            }
            else
                File.WriteAllText(path, JsonSerializer.Serialize(products, new JsonSerializerOptions() { WriteIndented = true }));
            ProductWriteLog(log, products);
        }

        public static void XlWrite(string xlpath, string jsonpath)
        {
            lock (_sync)
            {
                if (File.Exists(jsonpath))
                {
                    var workbook = File.Exists(xlpath) ? new XLWorkbook(xlpath) : new XLWorkbook();

                    var products = JsonRead<Product>(jsonpath);

                    var worksheet = workbook.Worksheets.Count > 0 ? workbook.Worksheet(1) : workbook.Worksheets.Add("Products");

                    int lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 0;

                    if (worksheet.Cell(1, 1).IsEmpty())
                    {
                        worksheet.Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Value = "Name";
                        worksheet.Cell(1, 2).Value = "Firma";
                        worksheet.Cell(1, 3).Value = "Code";
                        worksheet.Cell(1, 4).Value = "Color";
                        worksheet.Cell(1, 5).Value = "Min age";
                        worksheet.Cell(1, 6).Value = "Max age";
                        worksheet.Cell(1, 7).Value = "Count";
                        worksheet.Cell(1, 8).Value = "CIP";
                        worksheet.Cell(1, 9).Value = "Price";

                        lastRow = 1;
                    }

                    for (int i = 0; i < products!.Count; i++)
                    {
                        worksheet.Cell(lastRow + i + 1, 1).Value = products[i].Name;
                        worksheet.Cell(lastRow + i + 1, 2).Value = products[i].Firma;
                        worksheet.Cell(lastRow + i + 1, 3).Value = products[i].Code;
                        worksheet.Cell(lastRow + i + 1, 4).Value = products[i].Color;
                        worksheet.Cell(lastRow + i + 1, 5).Value = products[i].AgeRangeMin;
                        worksheet.Cell(lastRow + i + 1, 6).Value = products[i].AgeRangeMax;
                        worksheet.Cell(lastRow + i + 1, 7).Value = products[i].Count;
                        worksheet.Cell(lastRow + i + 1, 8).Value = products[i].CountInPacket;
                        worksheet.Cell(lastRow + i + 1, 9).Value = (double)products[i].Price;
                    }
                    workbook.SaveAs(xlpath);
                }
            }
        }

        public static void XlRead(string xlpath)
        {
            lock (_sync)
            {
                var products = new List<Product>();

                var workbook = new XLWorkbook(xlpath);
                var worksheet = workbook.Worksheets.First();//way1
                //var worksheet = workbook.Worksheet("Products");//way2
                int lastRow = worksheet.LastRowUsed()!.RowNumber();

                for (int row = 2; row <= lastRow; row++)
                    Console.Write($"{worksheet.Cell(row, 1).GetString()}\t" +
                        $"{worksheet.Cell(row, 2).GetString()}\t" +
                        $"{worksheet.Cell(row, 3).GetString()}\t" +
                        $"{worksheet.Cell(row, 4).GetString()}\t" +
                        $"{worksheet.Cell(row, 5).GetValue<int>()}\t" +
                        $"{worksheet.Cell(row, 6).GetValue<int>()}\t" +
                        $"{worksheet.Cell(row, 7).GetValue<int>()}\t" +
                        $"{worksheet.Cell(row, 8).GetValue<int>()}\t" +
                        $"{worksheet.Cell(row, 9).GetDouble()}\n");
            }
        }
    }
}
global using System;
global using System.Text;
global using System.Text.Json;
global using System.Net;
global using System.Net.Mail;
global using ClosedXML.Excel;
using ForOfficialWorkProject.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string path_product = "products.json";
        string products_log = "product.log";
        string path_xl = "product.xlsx";
        string adress = "elgun.q2003@gmail.com";
        string mail_subject = "Yeni gelen mallarin siyahisi";

        //Console.WriteLine(new GmailService("elgun2003@gmail.com","eeee1111"));

        var products = new List<Product>
        {
            new Product( "Jeans", "F-star", "F-000", "Black", 4, 9, 20,6, 4),
        };

        File.WriteAllText(path_product, JsonSerializer.Serialize(products,new JsonSerializerOptions() { WriteIndented = true}), Encoding.UTF8);
        Console.WriteLine("Successfuly");

        //Console.WriteLine(product.ToString());
        //Console.WriteLine(new Admin("Elgun", "Quliyev", new GmailService("elgun2003@gmail.com", "abcd1234")));

        //AdminManeger.Add(path_xl, products_log, path_product, adress, mail_subject, products);

        //DB.XlRead(path_xl);
        //AdminManeger.AllShow(path_product);
        //AdminManeger.ALlShow(path_product);
        //AdminManeger.Find(path_product, "a");

        Console.ReadKey();
    }
}


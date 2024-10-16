global using System;
global using System.Text;
global using System.Text.Json;
global using System.Net;
global using System.Net.Mail;
using ForOfficialWorkProject.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        string product_path = "products.json";
        string product_log = "product.log";
        string mail = "elgun.q2003@gmail.com";
        string mail_subject = "Yeni gelen mallarin siyahisi";

        //Console.WriteLine(new GmailService("elgun2003@gmail.com","eeee1111"));

        var products = new List<Product>
        {
            new Product( "Jeans", "F-star", "F-000", "Black", 4, 9, 20,6, 4),
        };

        //File.WriteAllText(product_path, JsonSerializer.Serialize(products, new JsonSerializerOptions() { WriteIndented = true }), Encoding.UTF8);
        //Console.WriteLine("Successfuly");

        //Console.WriteLine(product.ToString());
        //Console.WriteLine(new Admin("Elgun", "Quliyev", new GmailService("elgun2003@gmail.com", "abcd1234")));


        //AdminManeger.Add(product_log, product_path, mail, mail_subject, products);


        //AdminManeger.AllShow(product_path);



        //AdminManeger.Delete(product_path, product_log, new Product("Jeans", "F-star", "F-000", "Black", 4, 9, 20, 6, 0));


        AdminManeger.Find(product_path, "a");

        Console.ReadKey();
    }
}


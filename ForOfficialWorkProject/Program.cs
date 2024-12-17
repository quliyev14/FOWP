global using System;
global using System.Text;
global using System.Text.Json;
global using System.Net;
global using System.Net.Mail;
using ForOfficialWorkProject.Models;
using ForOfficialWorkProject.MS;
using ForOfficialWorkProject.DB;

internal class Program
{
    private static void Main(string[] args)
    {
        string product_path = "products.json";
        string product_log = "product.log";
        string mail = "elgun.gg2003@gmail.com"; // 
        string Subject = "Yeni gelen mallarin siyahisi";


        var products = new List<Product>
        {
            new Product( "Kofta", "Zara", "F-01-22", "White",11, 15, 15,5, 3),
        };


        // DB.JsonWrite(product_path, product_log, products);
        // DB.JsonRead<Product>(product_path);
        //AdminManeger.Add(product_log, product_path, mail, Subject, products);
         //AdminManeger.Delete(product_path, product_log, "f6d5175e-62c9-4d12-8fee-e5f0c5f0a5a6");
        // AdminManeger.AllShow(product_path);
        // AdminManeger.Edit(product_path, new Product());//
        // AdminManeger.Search("K", product_path);
        // GmailAndPasswordCheck.GPCheck(ForOfficialWorkProject.MS.GP.Gmail, "empty@gmail.com");
        // PathCheck.OpenOrClosed(product_path);
        // Service.MailIsSend(mail, mail_subject, products.ToString()!);

        //var gs = new GmailService("elgun2003@gmail.com", "200003");
        //Console.WriteLine(gs);

        //END 23/10/2024 23:16


        //Service.MailSend("elgun.gg2003@gmail.com", Subject, new string('-', 25));
        Console.ReadKey();
    }
}
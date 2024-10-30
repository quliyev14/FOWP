global using System;
global using System.Text;
global using System.Text.Json;
global using System.Net;
global using System.Net.Mail;
using ForOfficialWorkProject.Models;
using ForOfficialWorkProject.Helper;
using ForOfficialWorkProject.DB;
using ForOfficialWorkProject.MS;

internal class Program
{
    private static void Main(string[] args)
    {
        string product_path = "products.json";
        string product_log = "product.log";
        string mail = "empty@gmail.com"; // 
        string mail_subject = "Yeni gelen mallarin siyahisi";



        var products = new List<Product>
        {
            new Product( "Kofta", "Zara", "F-01-22", "White",11, 15, 15,5, 3),
        };

        // DB.JsonWrite(product_path, product_log, products);
        // DB.JsonRead<Product>(product_path);
        // AdminManeger.Add(product_log, product_path, mail, mail_subject, products);
        // AdminManeger.Delete(product_path, product_log, "f6d5175e-62c9-4d12-8fee-e5f0c5f0a5a6");
        // AdminManeger.AllShow(product_path);
        // AdminManeger.Edit(product_path, new Product());//
        // AdminManeger.Search("K", product_path);
        // GmailAndPasswordCheck.GPCheck(ForOfficialWorkProject.MS.GP.Gmail, "empty@gmail.com");
        // PathCheck.OpenOrClosed(product_path);
        // Service.MailIsSend(mail, mail_subject, products.ToString()!);

        //END 23/10/2024 23:16
        
        
        

        Console.ReadKey();
    }
}


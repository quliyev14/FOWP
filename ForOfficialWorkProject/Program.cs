global using System;
global using System.Text;
global using System.Text.Json;
global using System.Net;
global using System.Net.Mail;
global using ClosedXML.Excel;
using System.IO;
using ForOfficialWorkProject.Helper;
using ForOfficialWorkProject.Models;
using ForOfficialWorkProject.MS;
using ForOfficialWorkProject.DB;

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
            new Product(name: "Blouse",firmaName: "F-star",code: "F2103",color: "Blue",ageRangeMin: 4,ageRangeMax: 9,count: 20,countInPacket: 6,price: 4),
        };

        //Console.WriteLine(product.ToString());
        //Console.WriteLine(new Admin("Elgun", "Quliyev", new GmailService("elgun2003@gmail.com", "abcd1234")));

        //AdminManeger.Add(path_xl, products_log, path_product, products_log, adress, mail_subject, products);
        DB.XlRead(path_xl);
        //AdminManeger.ALlShow(path_product);
        //AdminManeger.Find(path_product, "a");

        Console.ReadKey();
    }
}


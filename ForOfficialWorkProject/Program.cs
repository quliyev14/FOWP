global using System;
global using System.Text;
global using System.Text.Json;
global using System.Net;
global using System.Net.Mail;
using ForOfficialWorkProject.Helper;
using ForOfficialWorkProject.Models;
using ForOfficialWorkProject.MS;

internal class Program
{
    private static void Main(string[] args)
    {
        string path_product = "product.json";
        string main_log = "Main.log";
        string adress = "elgun.q2003@gmail.com";
        string mail_subject = "Yeni gelen mallarin siyahisi";

        //Console.WriteLine(new GmailService("elgun2003@gmail.com","eeee1111"));

        var product = new Product(
               name: "Jeans",
               firmaName: "MAMHAYF",
               code: "4520",
               color: "Black",
               ageRangeMin: 6,
               ageRangeMax: 10,
               count: 12,
               countInPacket: 5,
               price: 6.15
           );

        //Console.WriteLine(product.ToString());

        //Console.WriteLine(new Admin("Elgun", "Quliyev", new GmailService("elgun2003@gmail.com", "abcd1234")));

        AdminManeger.Add(in path_product, in main_log, in adress, in mail_subject, product);



        Console.ReadKey();
    }
}


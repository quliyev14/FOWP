global using System;
global using System.Text;
global using System.Text.Json;
using System.Net;
using System.Net.Mail;
using ForOfficialWorkProject.Helper;
using ForOfficialWorkProject.Models;
using ForOfficialWorkProject.MS;

internal class Program
{
    private static void Main(string[] args)
    {
        string path_product = "product.json";
        string main_log = "main.log";
        string adress = "elgun.q2003@gmail.com";
        string mail_subject = "Yeni gelen mallarin siyahisi";

        //Console.WriteLine(new GmailService("elgun2003@gmail.com","eeee1111"));

        var product = new Product(
               name: "Jeans",
               firmaName: "Zilli",
               code: "F1234",
               color: "Black",
               ageRangeMin: 30,
               ageRangeMax: 35,
               count: 30,
               countInPacket: 6,
               price: 5.5
           );

        //Console.WriteLine(product.ToString());

        //Console.WriteLine(new Admin("Elgun", "Quliyev", new GmailService("elgun2003@gmail.com", "abcd1234")));

        AdminManeger.Add(in path_product, in main_log, adress, mail_subject, product);



        Console.ReadKey();
    }
}


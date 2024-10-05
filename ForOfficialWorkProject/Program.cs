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
        string path_product = "products.json";
        string main_log = "Main.log";
        string adress = "elgun.q2003@gmail.com";
        string mail_subject = "Yeni gelen mallarin siyahisi";

        //Console.WriteLine(new GmailService("elgun2003@gmail.com","eeee1111"));

        var product = new Product(
               name: "Sport",
               firmaName: "KONPAK GES",
               code: "211",
               color: "Black",
               ageRangeMin: 13,
               ageRangeMax: 16,
               count: 20,
               countInPacket: 4,
               price: 4.093
           );

        //Console.WriteLine(product.ToString());

        //Console.WriteLine(new Admin("Elgun", "Quliyev", new GmailService("elgun2003@gmail.com", "abcd1234")));

        //AdminManeger.Add(path_product, main_log, adress, mail_subject, product);
        AdminManeger.ALlShow(path_product);


        Console.ReadKey();
    }
}

